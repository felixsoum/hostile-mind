using System;

namespace HostileMind
{
    public class DialogOnStep : OnStepCommand
    {
        private string text;

        public DialogOnStep(string text)
        {
            this.text = text;
        }

        public void OnStep()
        {
            Dialog.SetText(text);
        }

        public OnStepCommand Clone()
        {
            return new DialogOnStep(text);
        }
    }
}

