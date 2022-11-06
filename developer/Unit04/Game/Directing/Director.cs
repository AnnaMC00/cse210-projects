using System;
using System.Collections.Generic;
using Unit04.Game.Casting;
using Unit04.Game.Services;


namespace Unit04.Game.Directing
{
    /// <summary>
    /// <para>A person who directs the game.</para>
    /// <para>
    /// The responsibility of DIrector is to control the sequence of play.
    /// </para>
    /// </summary>
    public class Director
    {
        private KeyboardService _keyboardService = null;
        private VideoService _videoService = null;
        private int _scoreBannerPoints = 0;

        /// <summary>
        /// Constructs a new instance of Director using the given KeyboarService and VideoService.
        /// </summary>
        /// <param name="keyboardService">THe given KeyboardService.</param>
        /// <param name="videoService">The given VideoService.</param>
        public Director(KeyboardService keyboardService, VideoService videoService)
        {
            this._keyboardService = keyboardService;
            this._videoService = videoService;
            
        }

        /// <summary>
        /// Starts the game by running the main game loop for the given cast.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        public void StartGame(Cast cast)
        {
            _videoService.OpenWindow();
            while (_videoService.IsWindowOpen())
            {
                GetInputs(cast);
                DoUpdates(cast);
                DoOutputs(cast);
            }
            _videoService.CloseWindow();
        }

        /// <summary>
        /// Gets directional input from the keyboard and applies it to the robot.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        private void GetInputs(Cast cast)
        {
            Actor player = cast.GetFirstActor("player");
            Point velocity = _keyboardService.GetDirection();
            player.SetVelocity(velocity);
        }

        /// <summary>
        /// Updates the robot's position and resolves any collisions with artifacts.\
        /// </summary>
        /// <param name="cast">The given cast.</param>
        private void DoUpdates(Cast cast) // AGREGAR MENOS 1 EL VELOCOTY ASI VA CAYENDO!
        {
            Random random = new Random();
            Actor banner = cast.GetFirstActor("banner");
            Actor player = cast.GetFirstActor("player");
            List<Actor> rocksAndDiamonds = cast.GetActors("rocksAndDiamonds");

            for (int i = 0; i < random.Next(10); i++)
            {
                RocksAndDiamonds rocksOrDiamonds = new RocksAndDiamonds();
                rocksOrDiamonds.SetText(rocksOrDiamonds.RandomRockOrDiamond());
                rocksOrDiamonds.SetFontSize(20);
                rocksOrDiamonds.SetColor(rocksOrDiamonds.RandomColor());
                rocksOrDiamonds.SetPosition(rocksOrDiamonds.StartPosition(_videoService.GetWidth(), _videoService.GetHeight(), 20));
                cast.AddActor("rocksAndDiamonds", rocksOrDiamonds);
            }
            int maxX = _videoService.GetWidth();
            int maxY = _videoService.GetHeight();
            player.MoveNext(maxX, maxY);

            foreach (RocksAndDiamonds actor in rocksAndDiamonds)
            {
                if (player.GetPosition().Equals(actor.GetPosition()))
                {
                    int points = actor.GetScorePoint();
                    _scoreBannerPoints += points;
                    banner.SetText($"Score: {_scoreBannerPoints}");
                    cast.RemoveActor("rocksAndDiamonds", actor);
                }
                Point zeroPoint = new Point(0, 0);
                if (actor.GetPosition().Equals(zeroPoint))
                {
                    cast.RemoveActor("rocksAndDiamonds", actor);
                }

                actor.SetPosition(actor.ItemFall(actor.GetPosition()));
            }
        }

        /// <summary>
        /// Draws the actors on the screen.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        public void DoOutputs(Cast cast)
        {
            List<Actor> actors = cast.GetAllActors();
            _videoService.ClearBuffer();
            _videoService.DrawActors(actors);
            _videoService.FlushBuffer();
        }
    }
}