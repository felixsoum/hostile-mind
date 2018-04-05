using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace HostileMind
{
    public class WaypointPatrolAi : EnemyAi
    {
        private Vector2[] waypoints;
        private int timeSpentWaiting = 1000;
        private int currentWait = 0;
        private int waypointIndex = 0;

        public WaypointPatrolAi(params Vector2[] waypoints)
        {
            this.waypoints = waypoints;
        }

        public void Update(EnemyActor enemy)
        {
            if (enemy.Commands.Count > 0)
                return;

            currentWait = Math.Max(currentWait - Time.deltaTime, 0);
            if (currentWait > 0)
                return;

            enemy.AddCommand(new MoveActorCommand(waypoints[waypointIndex++]));
            waypointIndex %= waypoints.Length;
            currentWait = timeSpentWaiting;
        }
    }
}

