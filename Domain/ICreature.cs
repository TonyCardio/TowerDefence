using System;

namespace TowerDefence.Domain
{
    public interface ICreature
    {
        MovingCommand Act(int x, int y);
        Action ActionInConflict(ICreature conflictedObject);
        // Dispose для пули DecreaseHealth для Enemy
    }

}
