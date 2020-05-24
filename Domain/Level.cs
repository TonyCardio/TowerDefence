using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TowerDefence.Domain
{
    public class Level
    {
        public string Name { get; set; }
        public Field Field { get; set; }
        public List<Point> PathSpawnToCastle { get; set; }
        public int WavesCount { get; set; }
        public int EnemiesPerWave { get; set; }
        private Timer waveTimer = new Timer();
        public Timer spawnTimer = new Timer();
        private int enemiesLeftToSpawn;
        public bool IsLost { get; private set; }

        //public event Action EnemyWave;

        public Level(string name, Field field, List<Point> pathToCastle, int wavesCount, int enemiesPerWave = 6)
        {
            Name = name;
            Field = field;
            PathSpawnToCastle = pathToCastle;
            WavesCount = wavesCount;
            EnemiesPerWave = enemiesPerWave; // Добавить в Levels, LevelsLoader и этот конструктор
            waveTimer.Interval = 20000;
            spawnTimer.Interval = 1000;
            waveTimer.Tick += OnWaveStart;
            spawnTimer.Tick += OnSpawn;
        }

        public void Run()
        {
            waveTimer.Start();
        }

        private void OnWaveStart(object sender, EventArgs e)
        {
            if (WavesCount <= 0)
            {
                spawnTimer.Dispose();
                waveTimer.Dispose();
            }
            else
            {
                enemiesLeftToSpawn = EnemiesPerWave;
                spawnTimer.Start();
            }
        }

        private void OnSpawn(object sender, EventArgs e)
        {
            var enemy = enemiesLeftToSpawn < 2 * (EnemiesPerWave / 3) ?
                            enemiesLeftToSpawn < EnemiesPerWave / 3 ?
                            (Enemy)new HighSkeleton(PathSpawnToCastle) :
                            (Enemy)new ShortSkeleton(PathSpawnToCastle) :
                        (Enemy)new GreenMonster(PathSpawnToCastle);
            enemy.Health = 1;
            var spawn = Field.EnemySpawnPos;
            Field.Cells[spawn.X, spawn.Y].Creature = enemy;
            enemiesLeftToSpawn--;
            if (enemiesLeftToSpawn <= 0)
            {
                WavesCount--;
                if (WavesCount == 0)
                {
                    enemy.IsLastInlevel = true;
                    waveTimer.Stop();
                }
                spawnTimer.Stop();
            }
        }

        public void Lose() => IsLost = true;
    }
}
