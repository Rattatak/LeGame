﻿namespace LeGame.Core.Factories
{
    using System.Collections.Generic;

    using LeGame.Enumerations;
    using LeGame.Interfaces;
    using LeGame.Models;

    using Microsoft.Xna.Framework;

    public static class LevelFactory
    {
        public static ILevel MakeLevel(ICharacter player, Maps map = Maps.Random)
        {
            while (map == Maps.Random)
            {
                map = (Maps)GlobalVariables.Rng.Next(2, 6);
            }

            ILevel newLevel = new Level($@"{GlobalVariables.ContentDir}Maps\{map}.txt", player);
            player.Position = GetNewPlayerPosition(player.Position);

            if (map == Maps.BloodyMapW)
            {
                IEnumerable<ICharacter> enemies = EnemyFactory.MakeRandomEnemies();
                newLevel.Enemies.AddRange(enemies);
                //TODO figure a way to avoid hardcoding here
                player.Position = new Vector2(600,240);
            }

            foreach (ICharacter enemy in newLevel.Enemies)
            {
                enemy.Level = newLevel;
            }

            if (map == Maps.HouseMap)
            {
                newLevel.Assets.AddRange(ItemFactory.MakeTestItems());
            }

            return newLevel;
        }

        private static Vector2 GetNewPlayerPosition(Vector2 position)
        {
            Vector2 newPlayerPosition = position;

            if (position.X < 100)
            {
                newPlayerPosition = new Vector2(position.X + 540, position.Y);
            }
            else if (position.X > 540)
            {
                newPlayerPosition = new Vector2(position.X - 540, position.Y);
            }
            else if (position.Y < 100)
            {
                newPlayerPosition = new Vector2(position.X, position.Y + 395);
            }
            else if (position.Y > 395)
            {
                newPlayerPosition = new Vector2(position.X, position.Y - 395);
            }

            return newPlayerPosition;
        }
    }
}
