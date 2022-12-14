namespace Unit06.Game.Services
{
    public interface KeyboardService
    {
        /// <summary>
        /// Wheter or not the given key is down.
        /// </summary>
        /// <param name="key">The given key.</param>
        bool IsKeyDown(string key);

        /// <summary>
        /// Wheter or not the given key has been pressed.
        /// </summary>
        /// <param name="key">The given key.</param>
        bool IsKeyPressed(string key);

        /// <summary>
        /// Wheter or not the given key has been released.
        /// </summary>
        /// <param name="key">The given key.</param>
        bool IsKeyReleased(string key);

        /// <summary>
        /// Wheter or not the given key is up.
        /// </summary>
        /// <param name="key">The given key.</param>
        bool IsKeyUp(string key);
    }
}