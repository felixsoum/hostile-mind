using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HostileMind
{
    public class CinematicState : GameState
    {
        public string Text { get; set; }
        public Sprite Image { get; set; }
        private int timeToEnd = 2000;
        private List<CinematicAction> actions = new List<CinematicAction>();

        public virtual void Load()
        {
            Text = "";
            Image = NullSprite.Instance;
        }

        public void Update()
        {
            while (actions.Count > 0)
            {
                var isActionDone = actions[0].Action();
                if (isActionDone || Inputs.IsPressed(Keys.Space))
                    actions.RemoveAt(0);

                if (!isActionDone || Inputs.IsPressed(Keys.Space))
                    return;
            }

            if (Inputs.IsPressed(Keys.Space))
                timeToEnd = 0;

            timeToEnd -= Time.deltaTime;
            if (timeToEnd < 0 || Inputs.IsPressed(Keys.Space))
                OnEnd();
        }

        public void Draw()
        {
            Renderer.Begin(Renderer.Mode.GUI);

            int imageX = Renderer.DEFAULT_SCREEN_WIDTH / 2;
            int imageY = Renderer.DEFAULT_SCREEN_HEIGHT / 3;
            Image.Draw(new Vector2(imageX, imageY));

            int textX = Renderer.DEFAULT_SCREEN_WIDTH / 2 - (int)Renderer.shareTechFont.MeasureString(Text).X / 2;
            int textY = Renderer.DEFAULT_SCREEN_HEIGHT * 2 / 3;
            Renderer.DrawText(Renderer.shareTechFont, Text, new Vector2(textX, textY), Color.White);
            Renderer.End();
        }

        public void Draw(Color c)
        {
            Renderer.Begin(Renderer.Mode.GUI);

            int imageX = Renderer.DEFAULT_SCREEN_WIDTH / 2;
            int imageY = Renderer.DEFAULT_SCREEN_HEIGHT / 3;
            Image.Draw(new Vector2(imageX, imageY));

            int textX = Renderer.DEFAULT_SCREEN_WIDTH / 2 - (int)Renderer.shareTechFont.MeasureString(Text).X / 2;
            int textY = Renderer.DEFAULT_SCREEN_HEIGHT * 2 / 3;
            Renderer.DrawText(Renderer.shareTechFont, Text, new Vector2(textX, textY), c);
            Renderer.End();
        }

        protected virtual void OnEnd()
        {
        }

        protected void AddImage(Sprite sprite)
        {
            actions.Add(new CinematicImageAction(this, sprite));
        }

        protected void ClearImage()
        {
            AddImage(NullSprite.Instance);
        }

        protected void AddSound(string sound)
        {
            actions.Add(new CinematicSoundAction(sound));
        }

        protected void AddText(string text)
        {
            actions.Add(new CinematicTextAction(this, text));
        }

        protected void ClearText()
        {
            actions.Add(new CinematicTextAction(this, ""));
        }

        protected void AddWait(int millisecToWait)
        {
            actions.Add(new CinematicWaitAction(millisecToWait));
        }
    }
}

