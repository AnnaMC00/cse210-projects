using System.Collections.Generic;
using Unit06.Game.Casting;


namespace Unit06
{
    public class Constants
    {
        // -----------------------------------------------------------------------
        // GENERAL GAME CONSTANTS
        // -----------------------------------------------------------------------

        // GAME
        public static string GAME_NAME = "Go! IceCream";
        public static int FRAME_RATE = 60;

        // SCREEN
        public static int SCREEN_WIDTH = 1100;
        public static int SCREEN_HEIGHT = 760;
        public static int CENTER_X = SCREEN_WIDTH / 2;
        public static int CENTER_Y = SCREEN_HEIGHT / 2;
        public static int CELL_SIZE = 50;

        // FIELD
        public static int FIELD_TOP = 60;
        public static int FIELD_BOTTOM = SCREEN_HEIGHT;
        public static int FIELD_LEFT = 0;
        public static int FIELD_RIGHT = SCREEN_WIDTH;

        // FONT
        public static string FONT_FILE = "Assets/Fonts/zorque.otf"; // cambiar
        public static int FONT_SIZE = 32; // cambiar

        // SOUND
        
            // AGREGAR LOS SONIDOS

        // TEXT
        public static int ALIGN_LEFT = 0;
        public static int ALIGN_CENTER = 1;
        public static int ALIGN_RIGHT = 2;

        // COLORS
        public static Color BLACK = new Color(0, 0, 0);
        public static Color WHITE = new Color(255, 255, 255);
        public static Color PURPLE = new Color(255, 0, 255);

        // KEYS
        public static string LEFT = "left";
        public static string RIGHT = "right";
        public static string UP = "up";
        public static string DOWN = "down";
        public static string SPACE = "space";
        public static string ENTER = "enter";
        public static string PAUSE = "p";

        // SCENES
        public static string NEW_GAME = "new_game";
        public static string TRY_AGAIN = "try_again";
        public static string NEXT_LEVEL = "next_level";
        public static string NEXT_STAGE = "next_stage";
        public static string IN_PLAY = "in_play";
        public static string GAME_OVER = "game_over";

        // LEVEL
        public static string LEVEL_FILE = "Assets/Data/Levels/level-{0:000}.txt";
        public static int BASE_LEVELS = 2;

        // STAGES
        public static string STAGE_FILE = "Assets/Data/Stages/stage-{0:000}.txt";
        public static int BASE_STAGES = 4;

        // -----------------------------------------------------------------------
        // SCRIPTING CONSTANTS
        // -----------------------------------------------------------------------

        // PHASES
        public static string INITIALIZE = "initialize";
        public static string LOAD = "load";
        public static string INPUT = "input";
        public static string UPDATE = "update";
        public static string OUTPUT = "output";
        public static string UNLOAD = "unload";
        public static string RELEASE = "release";

        // -----------------------------------------------------------------------
        // CASTING CONSTANTS
        // -----------------------------------------------------------------------

        // STATS
        public static string STATS_GROUP = "stats";
        public static int DEFAULT_LIVES = 3;
        public static int MAXIMUM_LIVES = 5;

        // HUD
        public static int HUD_MARGIN = 15;
        public static string LEVEL_GROUP = "level";
        public static string LIVES_GROUP = "lives";
        public static string SCORE_GROUP = "score";
        public static string LEVEL_FORMAT = "LEVEL: {0}";
        public static string LIVES_FORMAT = "LIVES: {0}";
        public static string SCORE_FORMAT = "SCORE: {0}";

        // PLAYER
        public static string PLAYER_GROUP = "player";
        public static List<string> PLAYER_IMAGE = new List<string>() {
            "Assets/Images/006.png",
            "Assets/Images/007.png",
            "Assets/Images/008.png"
            };
        public static int PLAYER_RATE = 8;
        public static int PLAYER_WIDTH = 20;
        public static int PLAYER_HEIGHT = 50;
        public static int PLAYER_VELOCITY = 5;

        // FRUIT
        public static string FRUIT_GROUP = "fruits";
        public static List<string> FRUIT_IMAGE = new List<string>() {
            "Assets/Images/001.png",
            "Assets/Images/002.png",
            "Assets/Images/003.png"
            };
        public static int FRUIT_WIDTH = 35;
        public static int FRUIT_HEIGHT = 35;
        public static int DEFAULT_FRUIT_POINTS = 20;

        // ENEMY
        public static string ENEMY_GROUP = "enemies";
        public static List<string> ENEMY_IMAGE = new List<string>() {
            "Assets/Images/004.png",
            "Assets/Images/005.png"
            };
        public static int ENEMY_WIDTH = 27;
        public static int ENEMY_HEIGHT = 35;
        public static int ENEMY_RATE = 8;
        public static Point ENEMY_VELOCITY_HORIZONTAL = new Point(2, 0);
        public static Point ENEMY_VELOCITY_VERTICAL = new Point(0, 2);

        // WALL
        public static string WALL_GROUP = "walls";
        public static string WALL_IMAGE = "Assets/Images/000.png";
        public static int WALL_WIDTH = 50;
        public static int WALL_HEIGHT = 50;

        // DIALOG
        public static string DIALOG_GROUP = "dialogs";
        public static string ENTER_TO_START = "PRESS ENTER TO START";
        public static string READY_SET = "READY?.. SET..";
        public static string GO = "GO";
        public static string WAS_GOOD_GAME = "GAME OVER";
        public static string PLAY_AGAIN = "TRY AGAIN?";
    }
}