using System;
using Microsoft.Xna.Framework;

namespace HostileMind
{
    public class PushableBlock : Block
    {
        private bool isMoving = false;
        private Vector2 moveDestination;

        public PushableBlock(Tile occupiedTile, Sprite sprite)
            : base (sprite, occupiedTile)
        {
        }

        public PushableBlock(PushableBlock o)
            : base(o)
        {
            isMoving = o.isMoving;
            moveDestination = o.moveDestination;
        }

        public override Block Clone()
        {
            return new PushableBlock(this);
        }

        public override void Update()
        {
            if (isMoving)
            {
                var deltaPosition = moveDestination - Position;
                var movement = Vector2.Normalize(deltaPosition);
                movement.X *= PlayerActor.MOVE_SPEED_X * Time.deltaTime;
                movement.Y *= PlayerActor.MOVE_SPEED_Y * Time.deltaTime;

                if (Math.Abs(movement.X) > Math.Abs(deltaPosition.X))
                    Position = new Vector2(moveDestination.X, Position.Y);
                else
                    Position += new Vector2(movement.X, 0);

                if (Math.Abs(movement.Y) > Math.Abs(deltaPosition.Y))
                    Position = new Vector2(Position.X, moveDestination.Y);
                else
                    Position += new Vector2(0, movement.Y);

                if (moveDestination == Position)
                    isMoving = false;
            }
            base.Update();
        }

        public override void OnPlayerAction(PlayerActor.Orientation orientation)
        {
            // Do not allow pushing if the block is already moving
            if (isMoving)
                return;

            var targetPosition = Position;
            switch (orientation)
            {
                case PlayerActor.Orientation.LEFT:
                    targetPosition.X -= GameInfo.TILE_X;
                    break;
                case PlayerActor.Orientation.RIGHT:
                    targetPosition.X += GameInfo.TILE_X;
                    break;
                case PlayerActor.Orientation.UP:
                    targetPosition.Y -= GameInfo.TILE_Y;
                    break;
                case PlayerActor.Orientation.DOWN:
                    targetPosition.Y += GameInfo.TILE_Y;
                    break;
            }

            var room = GameInfo.CurrentRoom;
            if (room.IsBlockAt(targetPosition))
                return;

            var targetTile = room.GetTile(targetPosition);
            if (targetTile.IsPushableTo)
                MoveBlock(OccuppiedTile, targetTile);
        }

        private void MoveBlock(Tile origin, Tile destination)
        {
            Sounds.Get("push").Play();
            moveDestination = destination.Position;
            isMoving = true;
            OccuppiedTile = destination;
            destination.OccupantBlock = this;
            origin.OccupantBlock = null;
        }
    }
}

