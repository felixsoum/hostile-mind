using System;

namespace HostileMind
{
    public class SingleDialogOnStep : OnStepCommand //new
    {
        private string text;
        private bool stepped;

        public SingleDialogOnStep(string text)
        {
            this.text = text;
            stepped = false;
        }

        public void OnStep()
        {
            if (stepped == false)
            {
                Dialog.SetText(text);
                stepped = true;
            }
        }

        public OnStepCommand Clone()
        {
            var clone = new SingleDialogOnStep(text);
            clone.stepped = stepped;
            return clone;
        }
    }
}

