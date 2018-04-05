using System;

namespace HostileMind
{
	public class ChoiceOnStep : OnStepCommand
    {
		private Dialog.ChoiceDelegate choiceDelegate;
		private string choice1;
		private string choice2;
		private bool isChoiceDone = false;

		public ChoiceOnStep(Dialog.ChoiceDelegate choiceDelegate, string choice1, string choice2)
        {
			this.choiceDelegate = choiceDelegate;
			this.choice1 = choice1;
			this.choice2 = choice2;
        }

		public void OnStep()
		{
			if (isChoiceDone)
				return;
			Dialog.SetChoice(choiceDelegate, choice1, choice2);
			isChoiceDone = true;
		}

        public OnStepCommand Clone()
        {
            var clone = new ChoiceOnStep(choiceDelegate, choice1, choice2);
            clone.isChoiceDone = isChoiceDone;
            return clone;
        }
    }
}

