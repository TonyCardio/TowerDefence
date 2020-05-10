using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TowerDefence.Domain
{
    public class FieldState
    {
        //public const int ElementSize = 32;
        //public List<CreatureAnimation> Animations = new List<CreatureAnimation>();

        public void BeginAct()
        {
            throw new NotImplementedException();
        }

        public void EndAct()
        {
            throw new NotImplementedException();
        }

        private static ICreature SelectWinnerCandidatePerLocation(List<ICreature>[,] creatures, int x, int y)
        {
            throw new NotImplementedException();
        }

        private List<ICreature>[,] GetCandidatesPerLocation()
        {
            throw new NotImplementedException();
        }
    }
}