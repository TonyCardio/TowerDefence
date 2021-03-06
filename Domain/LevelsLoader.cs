﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace TowerDefence.Domain
{
    public static class LevelsLoader
    {
        public static readonly DirectoryInfo LevelsFolder = new DirectoryInfo(
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Levels"));

        public static IEnumerable<string> GetLevelsNames()
        {
            return LevelsFolder.GetFiles("*", SearchOption.AllDirectories)
                .Where(info => info.Name.EndsWith(".txt"))
                .Select(file => Path.GetFileNameWithoutExtension(file.Name));
        }

        public static Level LoadLevelByName(string levelName)
        {
            var levelFile = LevelsFolder.GetFiles($"{levelName}.txt", SearchOption.AllDirectories).Single();
            var levelInputData = File.ReadAllText(levelFile.FullName);
            return LoadLevelFromLines(levelInputData.Split('|'), levelName);
        }

        public static Level LoadLevelFromLines(string[] mapWaves, string levelName)
        {
            var map = mapWaves[0].Split(new[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            var height = map.Length;
            var width = map.Any() ? map[0].Length : 0;
            var cells = new Cell[width, height];
            var castlePos = new HashSet<Point>();
            var spawnPos = new HashSet<Point>();
            try
            {
                for (var y = 0; y < height; y++)
                    for (var x = 0; x < width; x++)
                    //Если будут траблы с координатами, то они здесь))
                    {
                        var type = (CellType)int.Parse(map[y][x].ToString());
                        if (type == CellType.Castle) castlePos.Add(new Point(x, y));
                        if (type == CellType.EnemySpawn) spawnPos.Add(new Point(x, y));
                        cells[x, y] = new Cell(type, new Point(x, y));
                    }
            }
            catch (Exception e)
            {
                throw new ArgumentException("Make sure input map is rectangular and consists only of 0 to 3 digits", e);
            }
            var waves = int.Parse(mapWaves[1]);
            if (castlePos.Count > 1 || spawnPos.Count > 1)
                throw new ArgumentException("Make sure input map contains one Castle and Spawn point");
            var field = new Field(cells, castlePos.FirstOrDefault(), spawnPos.FirstOrDefault());
            var path = CreateEnemiesPath(field);
            return new Level(levelName, field, path, waves);
        }

        private static List<Point> CreateEnemiesPath(Field field)
        {
            var path = Extensions.BFS(field, field.EnemySpawnPos, field.CastlePos);
            var result = new List<Point>();
            result.Add(path.Value);
            while ((path?.Previous ?? null) != null)
            {
                result.Add(path.Previous.Value);
                path = path.Previous;
            }
            result.Reverse();
            return result.Count != 1 ? result : throw new ArgumentException("Can`t find path to Castle");
        }
    }

}
