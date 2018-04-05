using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HostileMind
{

    public static class Dialog
    {
        public delegate void ChoiceDelegate(int x);
        public static SpriteFont font;
        private static Vector2 position;
        private const int TIME_LEFT_TO_FADE = 1000;
        private static string text = "";
        private static int timeLeft;
        private const int TIME_PER_CHAR = 100;
        private const int MINIMUM_TIME_PER_TEXT = 4000;
        private static ChoiceDelegate choiceDelegate;
        private static int availableChoices = 0;

        static Dialog()
        {
//            SetText("Grumpy Wizards make toxic brew for the Evil Queen and Jack.\n" +
//                "The quick brown fox jumps over the lazy dog.");

            // This is the top left origin of the text
            position = new Vector2(16, Renderer.DEFAULT_SCREEN_HEIGHT - GameInfo.SCREEN_BAR_LENGTH + 8);
        }

        public static void Update()
        {
            if (availableChoices > 0)
            {
                if (Inputs.IsPressed(Keys.D1))
                    NotifyChoice(1);
                else if (Inputs.IsPressed(Keys.D2) && availableChoices >= 2)
                    NotifyChoice(2);
                else if (Inputs.IsPressed(Keys.D3) && availableChoices >= 3)
                    NotifyChoice(3);
                else if (Inputs.IsPressed(Keys.D4) && availableChoices >= 4)
                    NotifyChoice(4);
            }
            else
            {
                timeLeft = (int)MathHelper.Max(timeLeft - Time.deltaTime, 0);
            }
        }

        public static void Draw()
        {
            var color = Color.White;
            if (timeLeft < TIME_LEFT_TO_FADE)
                color *= (float)timeLeft / TIME_LEFT_TO_FADE;
            Renderer.DrawText(font, text, position, color);
        }

        public static void SetText(string text)
        {
            int time = (int)MathHelper.Max(MINIMUM_TIME_PER_TEXT, TIME_PER_CHAR * text.Length);
            SetText(text, time);
        }

        public static void SetText(string text, int timeInMillisec)
        {
            Dialog.text = text;
            timeLeft = timeInMillisec;
        }

        public static void SetChoice(ChoiceDelegate del, string choice1, string choice2)
        {
            availableChoices = 2;
            choiceDelegate = del;
            SetText("[1] " + choice1 + "\n[2] " + choice2);
			GameInfo.AddPlayerLock();
        }

        public static void SetChoice(ChoiceDelegate del, string choice1, string choice2, string choice3)
        {
            availableChoices = 3;
            choiceDelegate = del;
            SetText("[1] " + choice1 + "        [3] "+choice3+" \n[2] " + choice2);
            GameInfo.AddPlayerLock();
        }

        private static void NotifyChoice(int x)
        {
            availableChoices = 0;
            timeLeft = 0;
			GameInfo.RemovePlayerLock();
            choiceDelegate(x);
          
        }

        public static void Clear()
        {
            availableChoices = 0;
            text = "";
        }
    }
}

