﻿using System;

namespace TowerDefence.Domain
{
    public class Castle : ICreature
    {
        public int Health { get; set; } = 100;

        public MovingCommand Act(int x, int y) => new MovingCommand();

        public Action ActionInConflict(ICreature conflictedObject)
        {
            return () =>
            {
                if (conflictedObject is Enemy)
                    Health -= (conflictedObject as Enemy).PunchPower;
            };
        }

        public bool IsAlive() => Health > 0;

    }
}
