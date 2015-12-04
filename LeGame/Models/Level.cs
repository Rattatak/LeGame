﻿using System.Collections.Generic;
using LeGame.Interfaces;
using LeGame.Models.Characters;
using LeGame.Models.LevelAssets;
using Microsoft.Xna.Framework.Content;

namespace LeGame.Models
{
    public class Level 
    {
        Character character;
        List<Asset> assets = new List<Asset>();
        List<Tile> tiles = new List<Tile>();

        public Level(string path, Character character, ContentManager content)
        {
            this.Character = character;

            AssetBuilder assetBuilder = new AssetBuilder(content, path);
            
            this.assets = assetBuilder.Assets;

            //should use method GenerateTiles
            this.Tiles = assetBuilder.Tiles;
        }

        public Character Character
        {
            get { return character; }
            private set { character = value; }
        }

        public List<Asset> Assets
        {
            get { return assets; }
            private set { this.assets = value; }
        }

        public List<Tile> Tiles
        {
            get { return tiles; }
            private set{this.tiles = value;}

        }
    }
}
