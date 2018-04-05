using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HostileMind
{
    public class LevelState : GameState
    {
        private PlayerActor player;
        private Level level;
        private Texture2D frame;
        private const int FADE_TIME_MAX = 1000;
        private int currentFadeTime = 0;

        public LevelState(Level level)
        {
            this.level = level;
            player = PlayerActor.Instance;
            frame = Textures.Get("frame");
        }

        public void Load()
        {
            GameInfo.CurrentLevel = level;
            level.NotifyLoad();
            level.NotifyRoomCreation();
        }

        public void Update()
        {
            if (level.RoomTransition.IsActive)
            {
                if (currentFadeTime == 0)
                {
                    currentFadeTime = FADE_TIME_MAX;
                }
                else if (currentFadeTime < FADE_TIME_MAX / 2)
                {
                    level.ActivateRoomTransition();
                    level.RoomTransition.Deactivate();
                }
            }

            if (currentFadeTime > 0)
            {
                currentFadeTime = Math.Max(currentFadeTime - Time.deltaTime, 0);
            }
            else
            {
                UpdateActor(player);
                var currentRoom = level.CurrentRoom;
                foreach (var n in currentRoom.Npcs)
                    UpdateActor(n);
                level.Update();
            }

            Renderer.UpdateCamera();
            PlayerItems.Update();
            Dialog.Update();
        }

        public void Draw()
        {

            Renderer.Begin(Renderer.Mode.GAME);

            var currentRoom = level.CurrentRoom;
            currentRoom.Draw();
            if (currentFadeTime < FADE_TIME_MAX / 2 && !level.isHidingPlayer)
                player.Draw();
            Renderer.End();

            Renderer.Begin(Renderer.Mode.GUI);
            if (currentFadeTime > 0)
                DrawFade();
            Renderer.End();

            Renderer.Begin(Renderer.Mode.FRAME);
            PlayerItems.Draw();
            Renderer.End();

            Renderer.Begin(Renderer.Mode.GUI);
            if (currentFadeTime > 0)
                DrawFade();
            //            Time.DrawFps();
            Dialog.Draw();
            Renderer.End();

			Renderer.DrawFrame();
        }

        private void UpdateActor(Actor actor)
        {
            Vector2 previousPos = actor.Position;
            actor.Update();

            Vector2 actorMovement = actor.Position - previousPos;
            Vector2 collisionResolution = Vector2.Zero;

            var currentRoom = level.CurrentRoom;
            if (actorMovement.X > 0)
                collisionResolution.X = currentRoom.GetCollisionTowardsRight(actor.GetHitbox());
            else if (actorMovement.X < 0)
                collisionResolution.X = currentRoom.GetCollisionTowardsLeft(actor.GetHitbox());

            if (actorMovement.Y > 0)
                collisionResolution.Y = currentRoom.GetCollisionTowardsBottom(actor.GetHitbox());
            else if (actorMovement.Y < 0)
                collisionResolution.Y = currentRoom.GetCollisionTowardsTop(actor.GetHitbox());

            // Decide whether to resolve collision horizontally or vertically first
            if (Math.Abs(collisionResolution.X) < Math.Abs(collisionResolution.Y))
            {
                collisionResolution.Y = 0;
                collisionResolution.X %= GameInfo.TILE_X;
                actor.Position += collisionResolution;
                actorMovement = actor.Position - previousPos;
                collisionResolution = Vector2.Zero;

                if (actorMovement.Y > 0)
                    collisionResolution.Y = currentRoom.GetCollisionTowardsBottom(actor.GetHitbox());
                else if (actorMovement.Y < 0)
                    collisionResolution.Y = currentRoom.GetCollisionTowardsTop(actor.GetHitbox());
                collisionResolution.Y %= GameInfo.TILE_Y;
            }
            else
            {
                collisionResolution.X = 0;
                collisionResolution.Y %= GameInfo.TILE_Y;
                actor.Position += collisionResolution;
                actorMovement = actor.Position - previousPos;
                collisionResolution = Vector2.Zero;
                if (actorMovement.X > 0)
                    collisionResolution.X = currentRoom.GetCollisionTowardsRight(actor.GetHitbox());
                else if (actorMovement.X < 0)
                    collisionResolution.X = currentRoom.GetCollisionTowardsLeft(actor.GetHitbox());
                collisionResolution.X %= GameInfo.TILE_X;
            }
            actor.Position += collisionResolution;
        }

        private void DrawFade()
        {
            float fadePercent = 1.0f - (float)Math.Abs((double)(currentFadeTime - FADE_TIME_MAX/2)/(FADE_TIME_MAX/2));
            Renderer.DrawRectangle(new Rectangle(0, GameInfo.SCREEN_BAR_LENGTH - 1, Renderer.DEFAULT_SCREEN_WIDTH, Renderer.DEFAULT_SCREEN_HEIGHT - 2*GameInfo.SCREEN_BAR_LENGTH + 2), Color.Black*fadePercent);
        }
    }
}

