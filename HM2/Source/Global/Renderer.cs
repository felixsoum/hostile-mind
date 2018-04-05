using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HostileMind
{
    public static class Renderer
    {
        public enum Mode
        {
            GAME,
            GUI,
            FRAME
        }
        public static SpriteBatch spriteBatch;
        public static GraphicsDeviceManager graphics;
        public static Matrix Scale { get; set; }
        public const int DEFAULT_SCREEN_WIDTH = 800;//1024;
        public const int DEFAULT_SCREEN_HEIGHT = 600;//576;
        public static SpriteFont shareTechFont;
		public static Texture2D Frame { get; set; }
		public static Texture2D White { get; set; }
        public static Vector2 Camera { get; set; }
		public static bool IsFrameActive { get; set; }
        private static int gameplayHeight;
        private static Viewport defaultViewport;
        private static Viewport gameViewport;
        private static float widthRatio = 1.0f;
        private static float heightRatio = 1.0f;

        public static void Init(GraphicsDeviceManager graphicsDeviceManager)
        {
            graphics = graphicsDeviceManager;
            graphics.PreferredBackBufferWidth = DEFAULT_SCREEN_WIDTH;
            graphics.PreferredBackBufferHeight = DEFAULT_SCREEN_HEIGHT;
//            graphics.IsFullScreen = true;
            Scale = Matrix.Identity;
            Camera = Vector2.Zero;
            gameplayHeight = DEFAULT_SCREEN_HEIGHT - 2*GameInfo.SCREEN_BAR_LENGTH;
			IsFrameActive = true;
        }

        public static void CalculateViewport()
        {
            defaultViewport = graphics.GraphicsDevice.Viewport;
            gameViewport = defaultViewport;
            gameViewport.Height -= (int)(2*GameInfo.SCREEN_BAR_LENGTH*heightRatio);
            gameViewport.Y += (int)(GameInfo.SCREEN_BAR_LENGTH*heightRatio);
        }

        public static void OnResize(int width, int height)
        { 
            graphics.PreferredBackBufferWidth = width;
            graphics.PreferredBackBufferHeight = height;
            graphics.ApplyChanges();
            CalculateScale();
        }

        public static void UpdateCamera()
        {
            Vector2 nextCamera = Renderer.Camera;
            int width = DEFAULT_SCREEN_WIDTH;
            int height = gameplayHeight;
            var currentRoom = GameInfo.CurrentLevel.CurrentRoom;
            var player = PlayerActor.Instance;

            // Compare room and screen width
            if (currentRoom.ColumnCount * GameInfo.TILE_X < width)
            {
                nextCamera.X = -(width - currentRoom.ColumnCount * GameInfo.TILE_X) / 2;
            }
            else
            {
                // Player is at the left, right, or middle of room
                if (player.Position.X < width / 2)
                    nextCamera.X = 0;
                else if (currentRoom.ColumnCount * GameInfo.TILE_X - player.Position.X < width / 2)
                    nextCamera.X = currentRoom.ColumnCount * GameInfo.TILE_X - width;
                else
                    nextCamera.X = player.Position.X - width / 2;
            }

            // Compare room and screen height
            if (currentRoom.RowCount * GameInfo.TILE_Y < height)
            {
                nextCamera.Y = -(height - currentRoom.RowCount * GameInfo.TILE_Y) / 2;
            }
            else
            {
                // Player is at the top, bottom, or middle of room
//                if (player.Position.Y < 3*height/8)
//                    nextCamera.Y = -height / 8;
                if (player.Position.Y < height/4 + height/12)
                    nextCamera.Y = -height / 4 + height/12;
                else if (currentRoom.RowCount * GameInfo.TILE_Y - player.Position.Y < height / 2)
                    nextCamera.Y = currentRoom.RowCount * GameInfo.TILE_Y - height;
                else
                    nextCamera.Y = player.Position.Y - height / 2;
            }

            Camera = nextCamera;
        }

        public static void Begin(Mode mode)
        {
            graphics.GraphicsDevice.Viewport = (mode == Mode.GAME) ? gameViewport : defaultViewport;
            var blend = (mode != Mode.FRAME) ? BlendState.AlphaBlend : BlendState.NonPremultiplied;

            var translation = (mode == Mode.GAME) ? Matrix.CreateTranslation(-Camera.X, -Camera.Y, 0) : Matrix.Identity;
            spriteBatch.Begin(SpriteSortMode.BackToFront, blend, SamplerState.LinearClamp,
                              DepthStencilState.None, RasterizerState.CullCounterClockwise, null,
                              translation * Renderer.Scale);
        }

        public static void End()
        {
            spriteBatch.End();
            graphics.GraphicsDevice.Viewport = defaultViewport;
        }

		public static void DrawFrame()
		{
			if (!IsFrameActive)
				return;

            var frameColor = new Color(150, 33, 33);
            if (PlayerActor.Instance.LifeCount == 3)
                frameColor = new Color(33, 33, 33);
            else if (PlayerActor.Instance.LifeCount == 2)
                frameColor = new Color(100, 33, 33);

            if (GameInfo.IsGodModeEnabled)
                frameColor = new Color(255, 255, 255);
                
			Begin(Renderer.Mode.FRAME);
			spriteBatch.Draw(Frame, new Vector2(-1, GameInfo.SCREEN_BAR_LENGTH - 1), frameColor * 0.9f);
			End();
		}

        public static void DrawText(SpriteFont font, String text, Vector2 position, Color color)
        {
            spriteBatch.DrawString(font, text, position, color, 0,
                                   Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
        }

        public static void DrawRectangle(Rectangle rectangle, Color color)
        {
            spriteBatch.Draw(White, rectangle, color);
        }

        public static void DrawRectangle(Rectangle rectangle, Color color, float depth)
        {
            spriteBatch.Draw(White, rectangle, null, color, 0, Vector2.Zero, SpriteEffects.None, depth);
        }

        private static void CalculateScale()
        {
            int currentWidth = graphics.GraphicsDevice.Viewport.Width;
            int currentHeight = graphics.GraphicsDevice.Viewport.Height;
            widthRatio = (float)currentWidth / DEFAULT_SCREEN_WIDTH;
            heightRatio = (float)currentHeight / DEFAULT_SCREEN_HEIGHT;
            CalculateViewport();

            Scale = Matrix.CreateScale(widthRatio, heightRatio, 1);
        }
    }
}

