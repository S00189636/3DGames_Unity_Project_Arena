using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlutonianAttack : MonoBehaviour
{
    AINAVMovement MovementRef { get { return GetComponent<AINAVMovement>(); } }
    public Animator Animator;
    bool destroy = false;
    public GameObject Explosion;
    private void Start()
    {
        GetComponent<Health>().OnDeath += PlutonianAttack_OnDeath;
    }

    private void PlutonianAttack_OnDeath()
    {
        Animator.SetTrigger("Death");
        MovementRef.StopMoving(EnemyState.Dead);
        destroy = true;

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
                transform.LookAt(MovementRef.PlayerPosition);
                break;

            case EnemyState.Dead:
                if (destroy)
                {
                    
                    print("this is not the End @£$% ");
                    Invoke("Explode",0.3f);
                    Destroy(this.gameObject, 0.75f);
                    destroy = false;
                }
                break;
        }
    }
    private void Explode()
    {
        Instantiate(Explosion, transform.position + (Vector3.up * (transform.localScale.y/2)), Quaternion.identity);
    }
}
