using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class AINAVMovement : EnemyBase
{

    public NavMeshAgent Agent;
    public Vector3 PlayerPosition { 
        get 
        {
            if (Player == null ) return Vector3.zero;
            Vector3 playerPosition = Player.transform.position;
            playerPosition.y += 0.5f;
            return playerPosition; 
        }
    }
    public override void Start()
    {
        base.Start();
        Agent = GetComponent<NavMeshAgent>();
    }

    public void Move(Vector3 _destination)
    {
        Agent.SetDestination(_destination);
        EnemyCurrentState = EnemyState.Moving;
    }

    public void StopMoving(EnemyState _enemState)
    {
        Agent.isStopped = true;
        EnemyCurrentState = _enemState;
    }

    public void ResumeMoving()
    {
        Agent.isStopped = false;
        EnemyCurrentState = EnemyState.Moving;
    }
    
    
}
