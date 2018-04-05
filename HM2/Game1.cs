#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

#endregion

namespace HostileMind
{
    public class Game1 : Game
    {
        public Game1()
            : base()
        {
            Renderer.Init(new GraphicsDeviceManager(this));
            Window.AllowUserResizing = true;
            Window.ClientSizeChanged += new EventHandler<EventArgs>(OnClientSizeChanged);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            Textures.Content = Content;
            Sounds.Content = Content;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            RoomPlans.Load();
            Renderer.CalculateViewport();
            Renderer.spriteBatch = new SpriteBatch(GraphicsDevice);
            Renderer.shareTechFont = Content.Load<SpriteFont>(@"Fonts\ShareTech-Regular");
            Dialog.font = Content.Load<SpriteFont>(@"Fonts\Fenix-Regular");

            Sounds.Load("door-open");
            Sounds.Load("item");
            Sounds.Load("push");
            Sounds.Load("steps");
            Sounds.Load("wood-smack");
            Sounds.Load("cell-ring");

            Textures.Load("items");
            Textures.Load("player");
            Textures.Load("enemy");
            Textures.Load("stone-sphere");
            Textures.Load("white");
            Textures.Load("frame");
            Textures.Load("floor-test");
            Textures.Load("door-test");
            Textures.Load("npc-doctor");
            Textures.Load("npc-gang");
            Renderer.White = Textures.Get("white");
            Renderer.Frame = Textures.Get("frame");

            PlayerActor.Init();

            GameDirector.TransitionTo(new IntroCinematic());
            Inputs.PreviousKeyboard = Keyboard.GetState();
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            Inputs.CurrentKeyboard = Keyboard.GetState();
            if (Inputs.IsDown(Keys.Escape))
                Exit();

            Time.Set(gameTime);
            GameDirector.Update();
            Inputs.PreviousKeyboard = Inputs.CurrentKeyboard;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            GameDirector.Draw();

            base.Draw(gameTime);
        }

        private void OnClientSizeChanged(object sender, EventArgs e)
        {
            Renderer.OnResize(Window.ClientBounds.Width, Window.ClientBounds.Height);
        }
    }
}
