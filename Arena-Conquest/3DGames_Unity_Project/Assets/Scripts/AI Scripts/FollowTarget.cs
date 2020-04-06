using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : AINAVMovement
{
    
    
    public override void Update()
    {
        base.Update();

        switch (EnemyCurrentState)
        {
            case EnemyState.Idle:
                if (TargetInFOV)
                {
                    Move(Player.transform.position);
                }
                break;
            case EnemyState.Moving:
                if (!TargetInFOV)
                {
                    // Patrol
                }
                else if(Agent.destination != Player.transform.position)
                {
                    Move(Player.transform.position);

                    float Distance = Vector3.Distance(transform.position, Player.transform.position);
                    if (Distance <= AttackDistance)
                    {
                        StopMoving(EnemyState.Attacking);
                    }
                }
                break;
            case EnemyState.LastSpottedTracking:
                break;
            case EnemyState.Patrolling:
                break;
            case EnemyState.Attacking:

                float CurrentDistance = Vector3.Distance(transform.position, Player.transform.position);

                if (CurrentDistance > AttackDistance) //(CurrentDistance < VisionDistance )
                {
                    Agent.isStopped = false;
                    EnemyCurrentState = EnemyState.Moving;
                }
                break;
            case EnemyState.Dead:
                break;
            default:
                break;
        }
    }
}
