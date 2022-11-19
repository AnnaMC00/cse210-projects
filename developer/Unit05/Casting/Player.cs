using System;
using System.Collections.Generic;
using System.Linq;


namespace Unit05.Game.Casting
{
    /// <summary>
    /// <para> A player who leaves a trail.
    /// <para>The responsibility of Player is to move and add a new segment to itself.</para>
    /// </summary>
    public class Player : Actor
    {
        private List<Actor> _segments = new List<Actor>();

        /// <summary>
        /// Constructs a new instance of Player.
        /// </summary>
        /// <param name"startPoint">The start point of the player. </param>
        public Player(Point startPoint, Color playerColor, int playerNumber)
        {
            this._position = startPoint;
            this._color = playerColor;
            this._playerNumber = playerNumber;
            PlayerStartSegment();
        }

        /// <summary>
        /// Gets the player segments
        /// </summary>
        /// <returns>All the segments, player and trail.</returns>
        public List<Actor> GetSegments()
        {
            return _segments;
        }

        /// <summary>
        /// Gets the players's trail segments.
        /// </summary>
        /// <returns>The trail segments in a List.</returns>
        public List<Actor> GetTrail()
        {
            return new List<Actor>(_segments.Skip(1).ToArray());
        }

        /// <summary>
        /// Gets the player's first segment.
        /// </summary>
        /// <returns>The first segment of the player.</player>
        public Actor GetPlayerFirstSegment()
        {
            return _segments[0];
        }

        /// <summary>
        /// Grows the player's trail by one segment.
        /// </summary>
        public void GrowTrail()
        {
            Actor trail = _segments.Last<Actor>();
            Point velocity = trail.GetVelocity();
            
            Actor segment = new Actor();
            segment.SetPosition(_position);
            segment.SetVelocity(velocity);
            segment.SetText("#");
            segment.SetColor(_color);
            _segments.Add(segment);
        }

        /// <inheritdoc/>
        public override void MoveNext()
        {
            foreach (Actor segment in _segments)
            {
                segment.MoveNext();
            }
            GrowTrail();

            for (int i = _segments.Count - 1; i > 0; i--)
            {
                Actor trailing = _segments[i];
                Actor previous = _segments[i - 1];
                Point velocity = previous.GetVelocity();
                trailing.SetVelocity(velocity);
            }
        }

        /// <summary>
        /// Turns the player in the given direction.
        /// </summary>
        /// <param name="velocity">The given direction.</param>
        public void TurnPlayer(Point direction)
        {
            _segments[0].SetVelocity(direction);
        }

        /// <summary>
        /// The player start segment.
        /// </summary>
        public void PlayerStartSegment()
        {
            Point velocity = new Point(0, -Constants.CELL_SIZE);

            Actor segment = new Actor();
            segment.SetPlayerNumber(_playerNumber);
            segment.SetPosition(_position);
            segment.SetVelocity(velocity);
            segment.SetText("@");
            segment.SetColor(_color);
            _segments.Add(segment);
        }
    }
}