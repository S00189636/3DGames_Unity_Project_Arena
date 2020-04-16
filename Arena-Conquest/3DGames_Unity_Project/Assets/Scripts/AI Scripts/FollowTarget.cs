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
            case EnemyState.Moving:
                if(Agent.destination != Player.transform.position)
                {
                    Move(Player.transform.position);

                    float Distance = Vector3.Distance(transform.position, Player.transform.position);
                    if (Distance <= AttackDistance)
                    {
                        StopMoving(EnemyState.Attacking);
                    }
                }
                break;
            case EnemyState.Attacking:
                float CurrentDistance = Vector3.Distance(transform.position, Player.transform.position);
                if (CurrentDistance > AttackDistance) //(CurrentDistance < VisionDistance )
                {
                    Agent.isStopped = false;
                    Move(Player.transform.position);
                }
                break;
            case EnemyState.Dead:
                break;
        }
    }
}
