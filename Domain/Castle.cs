using System;

namespace TowerDefence.Domain
{
    public class Castle : ICreature
    {
        public int Health { get; private set; }
        public bool IsAlive { get => Health > 0; set { } }

        public Castle()
        {
            Health = 100;
        }

        public MovingCommand Act(int x, int y) => new MovingCommand();

        public Action ActionInConflict(ICreature conflictedObject)
        {
            return () =>
            {
                if (conflictedObject is Enemy)
                    GetDamageOrLoseLevel((conflictedObject as Enemy).PunchPower);
            };
        }

        private void GetDamageOrLoseLevel(int damage)
        {
            Health -= damage;
            if (!IsAlive)
                Game.LoseLevel();
        }
    }
}
