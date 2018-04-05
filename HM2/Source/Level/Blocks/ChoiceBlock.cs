using System;

namespace HostileMind
{
    public class ChoiceBlock : Block
    {
        private string choice1;
        private string choice2;
        private string choice3 = "";
        public Dialog.ChoiceDelegate choiceDelegate;

        public ChoiceBlock(Sprite blockSprite, Tile occupantTile, Dialog.ChoiceDelegate choiceDelegate,
                           string choice1, string choice2)
            : base(blockSprite, occupantTile)
        {
            this.choiceDelegate = choiceDelegate;
            this.choice1 = choice1;
            this.choice2 = choice2;
        }

        public ChoiceBlock(Sprite blockSprite, Tile occupantTile, Dialog.ChoiceDelegate choiceDelegate,
                           string choice1, string choice2, string choice3)
            : base(blockSprite, occupantTile)
        {
            this.choiceDelegate = choiceDelegate;
            this.choice1 = choice1;
            this.choice2 = choice2;
            this.choice3 = choice3;
        }

        public override void OnPlayerAction(PlayerActor.Orientation orientation)
        {
            if (choice3 == "")
                Dialog.SetChoice(choiceDelegate, choice1, choice2);
            else
                Dialog.SetChoice(choiceDelegate, choice1, choice2, choice3);
        }
    }
}

