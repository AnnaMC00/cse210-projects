using System;
using System.Collections.Generic;
using System.Data;
using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An update action that handles interactions between the actors. </para>
    /// <para>
    /// The responsibility of HandleCollisionsAction is to handle the situation when a player
    /// collides with the other, or if the player collides with itself, or the game is over.
    /// </para>
    /// </summary>
    public class HandleCollisionsAction : Action
    {
        private bool _isGameOver = false;

        /// <summary>
        /// Constructs a new instance of HandleCollisionsAction.
        /// </summary>
        public HandleCollisionsAction()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            if (_isGameOver == false)
            {
                HandleSegmentCollision(cast);
                HandleGameOver(cast);
            }
        }

        /// <summary>
        /// Updates the score and set the game over flac if the player
        /// collides with itself or the other player.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleSegmentCollision(Cast cast)
        {
            Player player1 = (Player)cast.GetActors("player")[0];
            Player player2 = (Player)cast.GetActors("player")[1];
            Actor player1Head = player1.GetPlayerFirstSegment();
            Actor player2Head = player2.GetPlayerFirstSegment();
            List<Actor> player1Trail = player1.GetTrail();
            List<Actor> player2Trail = player2.GetTrail();
            Score score1 = (Score)cast.GetActors("score")[0];
            Score score2 = (Score)cast.GetActors("score")[1];

            foreach (Actor segment in player1Trail)
            {
                // Player 1 collides with itself
                if (segment.GetPosition().Equals(player1Head.GetPosition()))
                {
                    _isGameOver = true;
                    score2.AddPoints(10);
                }
                // Player 2 collides
                if (segment.GetPosition().Equals(player2Head.GetPosition()))
                {
                    _isGameOver = true;
                    score1.AddPoints(10);
                }
            }

            foreach (Actor segment in player2Trail)
            {
                // Player 1 collides
                if (segment.GetPosition().Equals(player1Head.GetPosition()))
                {
                    _isGameOver = true;
                    score2.AddPoints(10);
                }
                // Player 2 collides with itself
                if (segment.GetPosition().Equals(player2Head.GetPosition()))
                {
                    _isGameOver = true;
                    score1.AddPoints(10);
                }
            }
        }

        /// <summary>
        /// Creates the game over's message.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleGameOver(Cast cast)
        {
            if (_isGameOver == true)
            {
                List<Actor> allSegments = new List<Actor>();
                Player player1 = (Player)cast.GetActors("player")[0];
                Player player2 = (Player)cast.GetActors("player")[1];
                allSegments.AddRange(player1.GetSegments());
                allSegments.AddRange(player2.GetSegments());

                // create a "game over" message
                int x = Constants.MAX_X / 2;
                int y = Constants.MAX_Y / 2;
                Point position = new Point(x, y);

                Actor message = new Actor();
                message.SetText("Game Over");
                message.SetPosition(position);
                cast.AddActor("message", message);

                // make everything white
                foreach (Actor segment in allSegments)
                {
                    segment.SetColor(Constants.WHITE);
                }
                player1.SetColor(Constants.WHITE);
                player2.SetColor(Constants.WHITE);
            }
        }
    }
}