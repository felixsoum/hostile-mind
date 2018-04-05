using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HostileMind
{
    public class RoomBuilder
    {
        private Room RoomProduct { get; set; }

        public RoomBuilder()
            : this(null)
        {
        }

        public RoomBuilder(Room roomProduct)
        {
            RoomProduct = roomProduct;
        }

        public void AddUnlockedDoor(RoomIndex index, DoorSprite.Orientation orientation, string texture = "door-wood")
        {
            var tile = RoomProduct.GetTile(index.I, index.J);
            tile.OccupantBlock = new DoorBlock(new DoorSprite(texture, orientation), tile);
        }

        public void AddItemLockedDoor(RoomIndex index, DoorSprite.Orientation orientation, Item.ItemType item, string lockedText, string texture = "door-wood")
        {
            var tile = RoomProduct.GetTile(index.I, index.J);
            tile.OccupantBlock = new DoorBlock(new DoorSprite(texture, orientation), tile, lockedText, item);
        }

        //fire
        public void AddFire(RoomIndex index, Item.ItemType item, string text, string texture)
        {
            var tile = RoomProduct.GetTile(index.I, index.J);
            tile.OccupantBlock = new FireBlock(new Sprite(Textures.Get(texture)), tile, text, item);
        }
        //

        public void AddLinkedItemLockedDoor(RoomIndex index1, DoorSprite.Orientation orientation1, Item.ItemType item1, string lockedText1,
                                            RoomIndex index2, DoorSprite.Orientation orientation2, Item.ItemType item2, string lockedText2,
                                            string texture1 = "door-wood", string texture2 = "door-wood")
        {
            var tile1 = RoomProduct.GetTile(index1.I, index1.J);
            var tile2 = RoomProduct.GetTile(index2.I, index2.J);
            var door1 = new DoorBlock(new DoorSprite(texture1, orientation1), tile1, lockedText1, item1);
            var door2 = new DoorBlock(new DoorSprite(texture2, orientation2), tile2, lockedText2, item2);
            door1.Connect(door2);
            door2.Connect(door1);
            tile1.OccupantBlock = door1;
            tile2.OccupantBlock = door2;
        }

        public void AddPermanentLockedDoor(RoomIndex index, DoorSprite.Orientation orientation, string lockedText, string texture = "door-wood")
        {
            var tile = RoomProduct.GetTile(index.I, index.J);
            tile.OccupantBlock = new DoorBlock(new DoorSprite(texture, orientation), tile, lockedText, false);
        }

		public void AddChoice(Dialog.ChoiceDelegate choiceDelegate, string choice1, string choice2, RoomIndex currentIndex)
		{
			var tile = RoomProduct.GetTile(currentIndex.I, currentIndex.J);
			tile.AddOnStepCommand(new ChoiceOnStep(choiceDelegate, choice1, choice2));
		}

        public void AddDialogToTile(string text, RoomIndex index)
        {
            var tile = RoomProduct.GetTile(index);
            tile.AddOnStepCommand(new DialogOnStep(text));
        }

        public void AddDialogToTile(string text, int i, int j) //new
        {
            var tile = RoomProduct.GetTile(i, j);
            tile.AddOnStepCommand(new DialogOnStep(text));
        }

        public void AddSingleDialogToTile(string text, RoomIndex index) //new
        {
            var tile = RoomProduct.GetTile(index);
            tile.AddOnStepCommand(new SingleDialogOnStep(text));
        }

        public void AddCommandToTile(Actor actor, ActorCommand command, RoomIndex index)
        {
            var tile = RoomProduct.GetTile(index);
            tile.AddOnStepCommand(new ActorCommandOnStep(actor, command));
        }

        public void AddRoomTransition(Type roomType, RoomIndex currentIndex, RoomIndex nextIndex)
        {
            AddRoomTransition(roomType, currentIndex.I, currentIndex.J, nextIndex.I, nextIndex.J);
        }

        public void AddRoomTransition(Type roomType, int currentX, int currentY, int targetX, int targetY)
        {
            var tile = RoomProduct.GetTile(currentX, currentY);
//            tile.AddHighlight(Color.Gold * 0.25f);
            tile.AddOnStepCommand(new RoomTransitionOnStep(roomType.Name, RoomIndex.ToVector(targetX, targetY)));
            tile.PushableLockCount++;
        }

		public void AddStateTransition(GameState state, RoomIndex currentIndex)
		{
			var tile = RoomProduct.GetTile(currentIndex.I, currentIndex.J);
			tile.AddOnStepCommand(new StateTransitionOnStep(state));
		}

		public void AddBlockMessage(Block.BlockMessage m, RoomIndex currentIndex, Type roomType, RoomIndex nextIndex)
		{
			var tile = RoomProduct.GetTile(currentIndex);
			tile.AddOnStepCommand(new BlockMessageOnStep(roomType.Name, nextIndex, m));
		}

        public void ClearFloor(RoomIndex index)
        {
            ClearFloor(index.I, index.J);
        }

        public void ClearFloor(int x, int y)
        {
            var tiles = RoomProduct.GetTiles();
            tiles[x, y].ClearFloor();
        }

        public void ClearOnStep(RoomIndex index)
        {
            ClearOnStep(index.I, index.J);
        }

        public void ClearOnStep(int x, int y)
        {
            var tiles = RoomProduct.GetTiles();
            tiles[x, y].ClearOnStepCommand();
        }
        public void ClearWall(RoomIndex index)
        {
            RoomProduct.GetTile(index).ClearWall();
        }

        public void FillEdges()
        {
            var tiles = RoomProduct.GetTiles();

            for (int i = 0; i < RoomProduct.ColumnCount; i++)
            {
                tiles[i, 0].ClearFloor();
                tiles[i, RoomProduct.RowCount - 1].ClearFloor();
            }

            for (int i = 1; i < RoomProduct.RowCount - 1; i++)
            {
                tiles[0, i].ClearFloor();
                tiles[RoomProduct.ColumnCount - 1, i].ClearFloor();
            }
        }

		public void FillFloor(string textureName)
		{
			FillFloor(textureName, 0, 0, RoomProduct.ColumnCount, RoomProduct.RowCount);
		}


		public void FillFloor(string textureName, RoomIndex index)
		{
			FillFloor(textureName, index.I, index.J);
		}

		public void FillFloor(string textureName, int startI, int startJ)
		{
			var tex = Textures.Get(textureName);
			int tileWidth = tex.Width / GameInfo.TILE_X;
			int tileHeight = tex.Height / GameInfo.TILE_Y;
			FillFloor(textureName, startI, startJ, tileWidth, tileHeight);
		}

		public void FillFloor(string textureName, RoomIndex index, int width, int height)
		{
			FillFloor(textureName, index.I, index.J, width, height);
		}

		public void FillFloor(string textureName, int startI, int startJ, int width, int height)
        {
			var tex = Textures.Get(textureName);
			int tileWidth = tex.Width / GameInfo.TILE_X;
			int tileHeight = tex.Height / GameInfo.TILE_Y;
			var floorSprite = new Sprite(tex, tileWidth, tileHeight);
			var tiles = RoomProduct.GetTiles();
			for (int i = startI; i < startI + width; i++)
            {
				for (int j = startJ; j < startJ + height; j++)
                {
                    var tile = tiles[i, j];
                    tile.Floor = new Sprite(floorSprite);

					int frameIndex = (i - startI) % tileWidth + tileWidth * ((j - startJ) % tileHeight);
                    tile.Floor.SetFrame(frameIndex);
                }
            }
        }

        public LightSource AddLightSource(RoomIndex index, float radius = 3f, float intensity = 1f)
        {
            return AddLightSource(index.I, index.J, radius, intensity);
        }

        public LightSource AddLightSource(int x, int y, float radius = 3f, float intensity = 1f)
        {
            RoomProduct.IsLightingEnabled = true;
            var lightSource = new LightSource(
                new Vector2(x * GameInfo.TILE_X + GameInfo.TILE_X/2f, y * GameInfo.TILE_Y + GameInfo.TILE_Y/2f),
                radius, intensity);
            RoomProduct.AddLightSource(lightSource);
            return lightSource;
        }

        public void RemoveLightSource(LightSource lightSource)
        {
            RoomProduct.RemoveLightSource(lightSource);
        }

        public void AddRepeatingBlock(string textureName, RoomIndex index, int width, int height,
                                      string inspectionText = "")
        {
            var tex = Textures.Get(textureName);
            int tileWidth = tex.Width / GameInfo.TILE_X;
            int tileHeight = tex.Height / GameInfo.TILE_Y;
            var floorSprite = new Sprite(tex, tileWidth, tileHeight);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    var tile = RoomProduct.GetTile(index.I + i, index.J + j);
                    tile.OccupantBlock = BlockFactory.Create(tile, inspectionText);
                    tile.Floor = new Sprite(floorSprite);
                    int frameIndex = i % tileWidth + tileWidth * (j % tileHeight);
                    tile.Floor.SetFrame(frameIndex);
                }
            }
        }

        public void AddBlock(string textureName, RoomIndex index, int height, string inspectionText = "", bool isFlipped = false)
        {
            var blockSprite = new Sprite(Textures.Get(textureName));

            if (isFlipped)
                blockSprite.IsFlipped = true;

            for (int i = 0; i < blockSprite.GetFrameWidth()/GameInfo.TILE_X; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    var tile = RoomProduct.GetTile(index.I + i, index.J - j);

                    if (i == 0 && j == 0)
                        tile.OccupantBlock = BlockFactory.Create(tile, inspectionText, blockSprite);
                    else
                        tile.OccupantBlock = BlockFactory.Create(tile, inspectionText);
                }
            }
        }

        public void AddBlock(string textureName, RoomIndex index, int height, Dialog.ChoiceDelegate choiceDelegate,
                             string choice1, string choice2, bool isFlipped = false)
        {
            var blockSprite = new Sprite(Textures.Get(textureName));

            if (isFlipped)
                blockSprite.IsFlipped = true;
            var tile = RoomProduct.GetTile(index.I, index.J);

            tile.OccupantBlock = BlockFactory.Create(tile, blockSprite, choiceDelegate, choice1, choice2);
        }

        public void AddBlock(string textureName, RoomIndex index, int height, Dialog.ChoiceDelegate choiceDelegate,
                             string choice1, string choice2, string choice3, bool isFlipped = false)
        {
            var blockSprite = new Sprite(Textures.Get(textureName));

            if (isFlipped)
                blockSprite.IsFlipped = true;
            var tile = RoomProduct.GetTile(index.I, index.J);

            tile.OccupantBlock = BlockFactory.Create(tile, blockSprite, choiceDelegate, choice1, choice2, choice3);
        }


        public void AddBlock(string textureName, RoomIndex index, int height, Item.ItemType item,
                             string collectText, bool isFlipped = false)
        {
            var blockSprite = new Sprite(Textures.Get(textureName));

            if (isFlipped)
                blockSprite.IsFlipped = true;
            var tile = RoomProduct.GetTile(index.I, index.J);

            tile.OccupantBlock = BlockFactory.Create(tile, blockSprite, item, collectText);
        }

        public void AddBlock(string textureName, RoomIndex index, int height, Item.ItemType item,
                             string collectText, PlayerActor.Orientation orientation, bool isFlipped = false)
        {
            var blockSprite = new Sprite(Textures.Get(textureName));

            if (isFlipped)
                blockSprite.IsFlipped = true;
            var tile = RoomProduct.GetTile(index.I, index.J);

            tile.OccupantBlock = BlockFactory.Create(tile, blockSprite, item, collectText, orientation);
        }

        public void AddBlock(string textureName, RoomIndex index, int height, Item.ItemType item, Item.ItemType itemNeeded,
                             string lockedText, string collectText, bool isFlipped = false)
        {
            var blockSprite = new Sprite(Textures.Get(textureName));

            if (isFlipped)
                blockSprite.IsFlipped = true;
            var tile = RoomProduct.GetTile(index.I, index.J);

            tile.OccupantBlock = BlockFactory.Create(tile, blockSprite, item, itemNeeded, lockedText, collectText);
        }

        public void AddBlock(string textureName, RoomIndex index, int height, Item.ItemType item, Item.ItemType itemNeeded,
                             string lockedText, string collectText, PlayerActor.Orientation orientation, bool isFlipped = false)
        {
            var blockSprite = new Sprite(Textures.Get(textureName));

            if (isFlipped)
                blockSprite.IsFlipped = true;
            var tile = RoomProduct.GetTile(index.I, index.J);

            tile.OccupantBlock = BlockFactory.Create(tile, blockSprite, item, itemNeeded, lockedText, collectText, orientation);
        }

        public void AddItemTile(Item.ItemType itemType, RoomIndex roomIndex)
        {
            AddItemTile(itemType, roomIndex.I, roomIndex.J);
        }

        public void AddItemTile(Item.ItemType itemType, int x, int y)
        {
            var tile = new ItemTile(RoomProduct.GetTile(x, y), itemType);
            RoomProduct.SetTile(tile, x, y);
        }

        public void AddPushableBlock(string textureName, RoomIndex index)
        {
            AddPushableBlock(textureName, index.I, index.J);
        }

        public void AddPushableBlock(string textureName, int i, int j)
        {
            var tile = RoomProduct.GetTile(i, j);
            tile.OccupantBlock = BlockFactory.CreatePushable(tile, textureName);
        }

        public void AddPushableItemBlock(string textureName, RoomIndex index, Item.ItemType itemNeeded, string text)
        {
            AddPushableItemBlock(textureName, index.I, index.J, itemNeeded, text);
        }

        public void AddPushableItemBlock(string textureName, int i, int j, Item.ItemType itemNeeded, string text)
        {
            var tile = RoomProduct.GetTile(i, j);
            tile.OccupantBlock = BlockFactory.CreatePushableItem(tile, textureName, itemNeeded, text);
            
        }
        
        public void AddWall(string textureName, RoomIndex index)
        {
            AddWall(textureName, index.I, index.J);
        }

        public void AddWall(string textureName, int x, int y)
        {
            AddWall(textureName, x, x, y);
        }

        public void AddWall(string textureName, int startX, int endX, int y)
        {
            var wallSprite = new Sprite (Textures.Get (textureName), 2, 1);
            for (int i = startX; i <= endX; i++)
            {
                var cloneSprite = new Sprite(wallSprite);
                cloneSprite.SetFrame((i - startX) % 2);
                RoomProduct.GetTile(i, y).AddWall(cloneSprite);
            }
        }

        public void AutomaticWall(string textureName)
        {
            var tiles = RoomProduct.GetTiles();
            for (int i = 0; i < RoomProduct.ColumnCount; i++)
            {
                for (int j = 0; j < RoomProduct.RowCount; j++)
                {
                    if (j == 0)
                    {
                        if (tiles[i, j].Floor != NullSprite.Instance)
                            AddWall(textureName, i, j);
                    }
                    else
                    {
                        if (tiles[i, j].Floor != NullSprite.Instance && tiles[i, j - 1].Floor == NullSprite.Instance)
                            AddWall(textureName, i, j);
                    }
                }
            }
        }
    }
}

