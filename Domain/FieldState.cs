﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TowerDefence.View;

namespace TowerDefence.Domain
{
    public class FieldState
    {
        //public const int ElementSize = 32;
        public List<Animation> Animations = new List<Animation>();
        public List<Animation> StaticObject = new List<Animation>();
        public Field Field;

        public FieldState(Field field)
        {
            Field = field;
        }
        public void BeginAct()
        {
            Animations.Clear();
            StaticObject.Clear();
            for (int x = 0; x < Field.Width; x++)
                for (int y = 0; y < Field.Height; y++)
                {
                    var cell = Field.Cells[x, y];
                    if (cell.Type == CellType.Empty || cell.Type == CellType.Road || cell.Type == CellType.EnemySpawn)
                        StaticObject.Add(new Animation(cell.Type, new Point(x, y)));
                    var creature = cell.Creature;
                    if (creature == null) continue;
                    var command = creature.Act(x, y);
                    Animations.Add(new Animation(creature, command, new Point(x, y), 0, cell.Type));
                }
        }

        public void EndAct()
        {
            var processedPoint = new HashSet<Point>();
            foreach (var animation in Animations.Where(a => !processedPoint.Contains(a.TargetLocation)))
            {
                SelectWinnerCandidatePerLocation(animation.TargetLocation.X,
                    animation.TargetLocation.Y);
                var prevLoc = animation.LocationOnField;
                var newLoc = animation.TargetLocation;
                Field.Cells[prevLoc.X, prevLoc.Y] = new Cell(animation.CellType, prevLoc);
                var nextCell = Field.Cells[newLoc.X, newLoc.Y];
                Field.Cells[newLoc.X, newLoc.Y] = new Cell(nextCell.Type, newLoc,
                    animation.Creature.IsAlive ? animation.Creature : null);
                processedPoint.Add(animation.TargetLocation);
            }
        }

        private void SelectWinnerCandidatePerLocation(int x, int y)
        {
            var candidates = GetCandidatesPerLocation(x, y);
            var alive = candidates.ToList();
            foreach (var candidate in candidates)
                foreach (var rival in alive)
                    if (candidate != rival)
                        candidate.ActionInConflict(rival)();
        }

        private List<ICreature> GetCandidatesPerLocation(int x, int y)
        {
            var candidates = new List<ICreature>();
            foreach (var e in Animations)
                if (e.TargetLocation.Equals(new Point(x, y)))
                    candidates.Add(e.Creature);
            return candidates;
        }
    }
}