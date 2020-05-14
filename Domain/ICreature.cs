using System;

namespace TowerDefence.Domain
{
    public interface ICreature
    {
        MovingCommand Act(int x, int y);
        Action ActionInConflict(ICreature conflictedObject);
        bool IsAlive { get; set; }
        /* 
         * Destroy для пули если conflictedObject - Enemy
         * DecreaseHealth для Enemy если conflictedObject - пуля
         * DecreaseHealth для Castle если conflictedObject - Enemy(использовать Enemy.PunchPower)
        */
    }

}