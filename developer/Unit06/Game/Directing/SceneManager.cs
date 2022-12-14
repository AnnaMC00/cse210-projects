using System;
using System.Collections.Generic;
using System.IO;
using Unit06.Game.Casting;
using Unit06.Game.Scripting;
using Unit06.Game.Services;


namespace Unit06.Game.Directing
{
    public class SceneManager
    {
        public static AudioService AudioService = new RaylibAudioService();
        public static KeyboardService KeyboardService = new RaylibKeyboardService();
        public static MouseService MouseService = new RaylibMouseService();
        public static PhysicsService PhysicsService = new RaylibPhysicsService();
        public static VideoService VideoService = new RaylibVideoService(Constants.GAME_NAME,
            Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT, Constants.WHITE);

        public SceneManager()
        {
        }

        public void PrepareScene(string scene, Cast cast, Script script)
        {
            if (scene == Constants.NEW_GAME)
            {
                PrepareNewGame(cast, script);
            }
            else if (scene == Constants.NEXT_STAGE)
            {
                PrepareNextStage(cast, script);
            }
            else if (scene == Constants.NEXT_LEVEL)
            {
                PrepareNextLevel(cast, script);
            }
            else if (scene == Constants.TRY_AGAIN)
            {
                PrepareTryAgain(cast, script);
            }
            else if (scene == Constants.IN_PLAY)
            {
                PrepareInPlay(cast, script);
            }
            else if (scene == Constants.GAME_OVER)
            {
                PrepareGameOver(cast, script);
            }
        }

        public void PrepareNewGame(Cast cast, Script script)
        {
            AddStats(cast);
            AddLevel(cast);
            AddScore(cast);
            AddLives(cast);
            AddPlayer(cast);
            AddFruits(cast);
            AddEnemies(cast);
            AddWalls(cast);
            AddDialog(cast, Constants.ENTER_TO_START);

            script.ClearAllActions();
            AddInitActions(script);
            AddLoadActions(script);

            ChangeSceneAction a = new ChangeSceneAction(KeyboardService, Constants.NEXT_LEVEL);
            script.AddAction(Constants.INPUT, a);

            AddOutputActions(script);
            AddUnloadActions(script);
            AddReleaseActions(script);
        }

        public void PrepareNextStage(Cast cast, Script script)
        {
            AddFruits(cast);
            AddDialog(cast, Constants.GO);

            script.ClearAllActions();

            TimedChangeSceneAction ta = new TimedChangeSceneAction(Constants.IN_PLAY, 0, DateTime.Now);
            script.AddAction(Constants.INPUT, ta);

            AddOutputActions(script);
        }

        private void PrepareNextLevel(Cast cast, Script script)
        {
            AddPlayer(cast);
            AddFruits(cast);
            AddEnemies(cast);
            AddWalls(cast);
            AddDialog(cast, Constants.READY_SET);

            script.ClearAllActions();

            TimedChangeSceneAction ta = new TimedChangeSceneAction(Constants.NEXT_STAGE, 0, DateTime.Now);
            script.AddAction(Constants.INPUT, ta);

            AddOutputActions(script);
        }

        public void PrepareTryAgain(Cast cast, Script script)
        {
            AddPlayer(cast);
            cast.ClearActors(Constants.DIALOG_GROUP);
            // AddDialog(cast, Constants.READY_SET);

            script.ClearAllActions();

            TimedChangeSceneAction ta = new TimedChangeSceneAction(Constants.IN_PLAY, 1, DateTime.Now);
            script.AddAction(Constants.INPUT, ta);

            AddOutputActions(script);
        }

        private void PrepareInPlay(Cast cast, Script script)
        {
            cast.ClearActors(Constants.DIALOG_GROUP);
            script.ClearAllActions();

            ControlPlayerAction action = new ControlPlayerAction(KeyboardService);
            script.AddAction(Constants.INPUT, action);

            AddUpdateActions(script);
            AddOutputActions(script);
        }

        private void PrepareGameOver(Cast cast, Script script)
        {
            AddDialog(cast, Constants.WAS_GOOD_GAME);

            script.ClearAllActions();

            TimedChangeSceneAction ta = new TimedChangeSceneAction(Constants.NEW_GAME, 2, DateTime.Now);
            script.AddAction(Constants.INPUT, ta);

            AddOutputActions(script);
        }

        // ------------------------------------------------------------------------------------
        // Casting Methods
        // ------------------------------------------------------------------------------------

        private void AddPlayer(Cast cast)
        {
            cast.ClearActors(Constants.PLAYER_GROUP);

            int x = (Constants.CENTER_X - Constants.PLAYER_WIDTH / 2 - Constants.PLAYER_WIDTH * 4) / 5 * 5;
            int y = (Constants.CENTER_Y - Constants.PLAYER_HEIGHT / 2) / 5 * 5;

            Point position = new Point(x, y);
            Point size = new Point(Constants.PLAYER_WIDTH, Constants.PLAYER_HEIGHT);
            Point velocity = new Point(0, 0);

            Body body = new Body(position, size, velocity);
            Animation animation = new Animation(Constants.PLAYER_IMAGE, Constants.PLAYER_RATE, 0);
            Player player = new Player(body, animation, false);

            cast.AddActor(Constants.PLAYER_GROUP, player);
        }

        private void AddFruits(Cast cast)
        {
            cast.ClearActors(Constants.FRUIT_GROUP);

            Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);
            int stage = stats.GetStage() % Constants.BASE_STAGES;
            string filename = string.Format(Constants.STAGE_FILE, stage);
            List<List<string>> rows = LoadFile(filename);

            for (int r = 0; r <rows.Count; r++)
            {
                for (int c = 0; c < rows[r].Count; c++)
                {
                    if (rows[r][c] == "f")
                    {
                        int x = Constants.FIELD_LEFT + c * Constants.CELL_SIZE;
                        int y = Constants.FIELD_TOP + r * Constants.CELL_SIZE;
                        int points = Constants.DEFAULT_FRUIT_POINTS + stage * 10;

                        Point position = new Point(x, y);
                        Point size = new Point(Constants.FRUIT_WIDTH, Constants.FRUIT_HEIGHT);
                        Point velocity = new Point(0, 0);

                        Body body = new Body(position, size, velocity);
                        Image image = new Image(Constants.FRUIT_IMAGE[stage - 1]);

                        Fruit fruit = new Fruit(body, image, points, false);
                        cast.AddActor(Constants.FRUIT_GROUP, fruit);
                    }
                }
            }
        }

        private void AddEnemies(Cast cast)
        {
            cast.ClearActors(Constants.ENEMY_GROUP);

            Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);
            int level = stats.GetLevel() % Constants.BASE_LEVELS;
            string filename = string.Format(Constants.LEVEL_FILE, level);
            List<List<string>> rows = LoadFile(filename);

            for (int r = 0; r <rows.Count; r++)
            {
                for (int c = 0; c < rows[r].Count; c++)
                {
                    if (rows[r][c][0].ToString() == "e")
                    {
                        int x = Constants.FIELD_LEFT + c * Constants.CELL_SIZE + 10;
                        int y = Constants.FIELD_TOP + r * Constants.CELL_SIZE + 5;

                        Point position = new Point(x, y);
                        Point size = new Point(Constants.ENEMY_WIDTH, Constants.ENEMY_HEIGHT);

                        Point velocity = new Point(0, 0);
                        if (rows[r][c][1].ToString() == "v")
                        {
                            velocity = Constants.ENEMY_VELOCITY_VERTICAL;
                        }
                        else if (rows[r][c][1].ToString() == "h")
                        {
                            velocity = Constants.ENEMY_VELOCITY_HORIZONTAL;
                        }
                        else
                        {
                            velocity = new Point(0, 0);
                        }

                        Body body = new Body(position, size, velocity);
                        Animation animation = new Animation(Constants.ENEMY_IMAGE, Constants.ENEMY_RATE, 0);

                        Enemy enemy = new Enemy(body, animation, false);
                        cast.AddActor(Constants.ENEMY_GROUP, enemy);
                    }
                }
            }
        }

        private void AddWalls(Cast cast)
        {
            cast.ClearActors(Constants.WALL_GROUP);

            Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);
            int level = stats.GetLevel() % Constants.BASE_LEVELS;
            string filename = string.Format(Constants.LEVEL_FILE, level);
            List<List<string>> rows = LoadFile(filename);

            for (int r = 0; r <rows.Count; r++)
            {
                for (int c = 0; c < rows[r].Count; c++)
                {
                    if (rows[r][c] == "w")
                    {
                        int x = Constants.FIELD_LEFT + c * Constants.WALL_WIDTH;
                        int y = Constants.FIELD_TOP + r * Constants.WALL_HEIGHT;

                        Point position = new Point(x, y);
                        Point size = new Point(Constants.WALL_WIDTH, Constants.WALL_HEIGHT);
                        Point velocity = new Point(0, 0);

                        Body body = new Body(position, size, velocity);
                        Image image = new Image(Constants.WALL_IMAGE);

                        Wall wall = new Wall(body, image, false);
                        cast.AddActor(Constants.WALL_GROUP, wall);
                    }
                }
            }
        }

        private void AddDialog(Cast cast, string message)
        {
            cast.ClearActors(Constants.DIALOG_GROUP);

            Text text = new Text(message, Constants.FONT_FILE, Constants.FONT_SIZE, 
                Constants.ALIGN_CENTER, Constants.BLACK);
            Point position = new Point(Constants.CENTER_X, Constants.CENTER_Y);
            
            Label label = new Label(text, position);
            cast.AddActor(Constants.DIALOG_GROUP, label);
        }

        private void AddLevel(Cast cast)
        {
            cast.ClearActors(Constants.LEVEL_GROUP);

            Text text = new Text(Constants.LEVEL_FORMAT, Constants.FONT_FILE, Constants.FONT_SIZE, 
                Constants.ALIGN_LEFT, Constants.BLACK);
            Point position = new Point(Constants.HUD_MARGIN, Constants.HUD_MARGIN);

            Label label = new Label(text, position);
            cast.AddActor(Constants.LEVEL_GROUP, label);
        }

        private void AddLives(Cast cast)
        {
            cast.ClearActors(Constants.LIVES_GROUP);

            Text text = new Text(Constants.LIVES_FORMAT, Constants.FONT_FILE, Constants.FONT_SIZE, 
                Constants.ALIGN_RIGHT, Constants.BLACK);
            Point position = new Point(Constants.SCREEN_WIDTH - Constants.HUD_MARGIN, 
                Constants.HUD_MARGIN);

            Label label = new Label(text, position);
            cast.AddActor(Constants.LIVES_GROUP, label);  
        }

        private void AddScore(Cast cast)
        {
            cast.ClearActors(Constants.SCORE_GROUP);

            Text text = new Text(Constants.SCORE_FORMAT, Constants.FONT_FILE, Constants.FONT_SIZE, 
                Constants.ALIGN_CENTER, Constants.BLACK);
            Point position = new Point(Constants.CENTER_X, Constants.HUD_MARGIN);
            
            Label label = new Label(text, position);
            cast.AddActor(Constants.SCORE_GROUP, label);
        }

        private void AddStats(Cast cast)
        {
            cast.ClearActors(Constants.STATS_GROUP);
            Stats stats = new Stats();
            cast.AddActor(Constants.STATS_GROUP, stats);
        }

        private List<List<string>> LoadFile(string filename)
        {
            List<List<string>> data = new List<List<string>>();
            using(StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    string row = reader.ReadLine();
                    List<string> columns = new List<string>(row.Split(',', StringSplitOptions.TrimEntries));
                    data.Add(columns);
                }
            }
            return data;
        }

        // ------------------------------------------------------------------------------------
        // Scripting Methods
        // ------------------------------------------------------------------------------------

        private void AddInitActions(Script script)
        {
            script.AddAction(Constants.INITIALIZE, new InitializeDevicesAction(AudioService, VideoService));
        }

        private void AddLoadActions(Script script)
        {
            script.AddAction(Constants.LOAD, new LoadAssetsAction(AudioService, VideoService));
        }
        
        private void AddOutputActions(Script script)
        {
            script.AddAction(Constants.OUTPUT, new StartDrawingAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawHudAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawWallAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawFruitAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawEnemyAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawPlayerAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawDialogAction(VideoService));
            script.AddAction(Constants.OUTPUT, new EndDrawingAction(VideoService));
        }

        private void AddUnloadActions(Script script)
        {
            script.AddAction(Constants.UNLOAD, new UnloadAssetsAction(AudioService, VideoService));
        }

        private void AddReleaseActions(Script script)
        {
            script.AddAction(Constants.RELEASE, new ReleaseDevicesAction(AudioService, VideoService));
        }

        private void AddUpdateActions(Script script)
        {
            script.AddAction(Constants.UPDATE, new MoveEnemyAction());
            script.AddAction(Constants.UPDATE, new MoveFruitAction());
            script.AddAction(Constants.UPDATE, new CollideEnemyWithWallAction(PhysicsService, AudioService));
            script.AddAction(Constants.UPDATE, new CollideFruitWithWallAction(PhysicsService, AudioService));
            script.AddAction(Constants.UPDATE, new CollidePlayerWithEnemyAction(PhysicsService, AudioService));
            script.AddAction(Constants.UPDATE, new CollidePlayerWithFruitAction(PhysicsService, AudioService));
            script.AddAction(Constants.UPDATE, new CollidePlayerWithWallAction(PhysicsService, AudioService));
            script.AddAction(Constants.UPDATE, new MovePlayerAction());
            script.AddAction(Constants.UPDATE, new CheckOverAction());
        }
    }
}