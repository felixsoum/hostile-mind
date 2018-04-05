using System;

namespace HostileMind
{
    public class InspectableBlock : Block
    {
        private string inspectionText;

        public InspectableBlock(string inspectionText, Sprite blockSprite, Tile occupantTile)
            : base(blockSprite, occupantTile)
        {
            this.inspectionText = inspectionText;
        }

        public InspectableBlock(string inspectionText, Tile occupantTile)
            : base(occupantTile)
        {
            this.inspectionText = inspectionText;
        }

        public override void OnPlayerAction(PlayerActor.Orientation orientation)
        {
            Dialog.SetText(inspectionText);
        }
    }
}

