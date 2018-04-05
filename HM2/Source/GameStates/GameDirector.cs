using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace HostileMind
{
    public static class GameDirector
    {
        private static GameState nullState = new NullState();
        private static GameState currentState = nullState;
        private static GameState nextState = nullState;

        private const int FADE_TIME_MAX = 2000;
        private static int currentFadeTime = 0;

        public static void TransitionTo(Level level)
        {
            TransitionTo(new LevelState(level));
        }

        public static void TransitionTo(GameState state)
        {
            if (IsTransitioning())
                return;

			GameInfo.AddPlayerLock();
            currentFadeTime = FADE_TIME_MAX;
            nextState = state;
        }

        public static void Update()
        {
			Cheat();

            if (currentFadeTime < FADE_TIME_MAX / 2 && nextState != nullState)
            {
				Reset();
                currentState = nextState;
                currentState.Load();
                nextState = nullState;
            }

            if (currentFadeTime > 0)
            {
                currentFadeTime = Math.Max(currentFadeTime - Time.deltaTime, 0);
            }

            currentState.Update();
        }

        public static void Draw()
        {
            currentState.Draw();
 
            if (currentFadeTime > 0)
                DrawFade();
        }

        private static void DrawFade()
        {
            Renderer.Begin(Renderer.Mode.GUI);
            float fadePercent = 1.0f - (float)Math.Abs((double)(currentFadeTime - FADE_TIME_MAX/2)/(FADE_TIME_MAX/2));
            Renderer.DrawRectangle(new Rectangle(0, GameInfo.SCREEN_BAR_LENGTH - 1, Renderer.DEFAULT_SCREEN_WIDTH, Renderer.DEFAULT_SCREEN_HEIGHT - 2*GameInfo.SCREEN_BAR_LENGTH + 2), Color.Black * fadePercent);
            Renderer.End();
        }

        public static bool IsTransitioning()
        {
            return nextState != nullState;
        }

        private static void Reset()
        {
            Dialog.Clear();
            PlayerItems.Clear();
            PlayerActor.Instance.Reset();
			GameInfo.ClearPlayerLock();
			Renderer.IsFrameActive = true;
        }

		private static void Cheat()
		{
            if (Inputs.IsPressed(Keys.F1))
                TransitionTo(new TutorialCinematic());
            else if (Inputs.IsPressed(Keys.F2))
                TransitionTo(new CarCinematic());
            else if (Inputs.IsPressed(Keys.F3))
                TransitionTo(new HospitalCinematic());
            else if (Inputs.IsPressed(Keys.F4))
                TransitionTo(new SubwayCinematic());
            else if (Inputs.IsPressed(Keys.F5))
                TransitionTo(new FinalCaseLevel());
            else if (Inputs.IsPressed(Keys.F6))
                TransitionTo(new EndingLevel());
            else if (Inputs.IsPressed(Keys.S))
                PlayerActor.Instance.MoveSpeed *= 2;
            else if (Inputs.IsPressed(Keys.D))
                PlayerActor.Instance.MoveSpeed /= 2;
            else if (Inputs.IsPressed(Keys.G))
                GameInfo.IsGodModeEnabled = !GameInfo.IsGodModeEnabled;
		}
    }
}

