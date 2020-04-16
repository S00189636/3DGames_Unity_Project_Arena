using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlutonianAttack : MonoBehaviour
{
    AINAVMovement MovementRef { get { return GetComponent<AINAVMovement>(); } }

    private void Start()
    {
        GetComponent<Health>().OnDeath += PlutonianAttack_OnDeath;
    }

    private void PlutonianAttack_OnDeath()
    {
        MovementRef.EnemyCurrentState = EnemyState.Dead;
    }

    private void Update()
    {

        EnemyState currentState = MovementRef.EnemyCurrentState;
        switch (currentState)
        {
            case EnemyState.Moving:
                print("I will get you");
                break;

            case EnemyState.Attacking:
                print("Bam!! Bam!!");
                break;

            case EnemyState.Dead:
                print("this is not the End @£$% ");
                Destroy(this.gameObject);
                break;
        }
    }

}
