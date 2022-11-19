using System.Collections.Generic;
using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An output action that draws all the actors.</para>
    /// <para>The responsibility of DrawActorsAction is to draw each of the actors.</para>
    /// </summary>
    public class DrawActorsAction : Action
    {
        private VideoService _videoService;

        /// <summary>
        /// Constructs a new instance of DrawActorAction using the given VideoService.
        /// </summary>
        public DrawActorsAction(VideoService videoService)
        {
            this._videoService = videoService;
        }

        /// <inheritdoc?>
        public void Execute(Cast cast, Script script)
        {
            Player player1 = (Player)cast.GetActors("player")[0];
            Player player2 = (Player)cast.GetActors("player")[1];
            List<Actor> segments1 = player1.GetSegments();
            List<Actor> segments2 = player2.GetSegments();
            Actor score1 = cast.GetActors("score")[0];
            Actor score2 = cast.GetActors("score")[1];
            List<Actor> messages = cast.GetActors("message");

            _videoService.ClearBuffer();
            _videoService.DrawActors(segments1);
            _videoService.DrawActors(segments2);
            _videoService.DrawActor(score1);
            _videoService.DrawActor(score2);
            _videoService.DrawActors(messages);
            _videoService.FlushBuffer();
        }
    }
}