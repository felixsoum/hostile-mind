using System;
using Microsoft.Xna.Framework;

namespace HostileMind
{
    public class VerticalPatrolAi : EnemyAi
    {
        private float moveMagnitude;
        private int timeSpentWaiting;
        private int currentWait = 0;

        public VerticalPatrolAi(float moveMagnitude = 300f, int timeSpentWaiting = 1000)
        {
            this.moveMagnitude = moveMagnitude;
            this.timeSpentWaiting = timeSpentWaiting;
        }

        public void Update(EnemyActor enemy)
        {
            if (enemy.Commands.Count > 0)
                return;

            currentWait = Math.Max(currentWait - Time.deltaTime, 0);
            if (currentWait > 0)
                return;

            enemy.AddCommand(new MoveActorCommand(new Vector2(0, moveMagnitude)));
            moveMagnitude *= -1.0f;
            currentWait = timeSpentWaiting;
        }
    }
}

