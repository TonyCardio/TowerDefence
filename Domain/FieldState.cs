using System;
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
        public Field Field;

        public FieldState(Field field)
        {
            Field = field;
        }
        public void BeginAct()
        {
            Animations.Clear();
            for (int x = 0; x < Field.Width; x++)
                for (int y = 0; y < Field.Height; y++)
                {
                    var creature = Field.Cells[x, y].Creature;
                    if (creature == null) continue;
                    var command = creature.Act(x, y);
                    Animations.Add(new Animation(creature, command, new Point(x, y), 0));
                }
        }

        public void EndAct()
        {
            throw new NotImplementedException();
        }

        private static ICreature SelectWinnerCandidatePerLocation(int x, int y)
        {
            throw new NotImplementedException();
        }

        private List<ICreature> GetCandidatesPerLocation(int x, int y)
        {
            var candidates = new List<ICreature>();
            foreach(var e in Animations)
                if (e.TargetLocation.Equals(new Point(x, y)))
                    candidates.Add(e.Creature);
            return candidates;
        }
    }
}