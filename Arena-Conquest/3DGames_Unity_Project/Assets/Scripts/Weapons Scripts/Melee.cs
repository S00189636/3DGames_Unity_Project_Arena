using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : Weapon
{
    public float Range;
    public Transform CenterPoint;
    public LayerMask EnemyLayerMask;
    public Animator Animator;

    protected override void Start()
    {
        base.Start();
        CenterPoint = transform.parent;
        WeaponType = WeaponType.Melee;
    }

    public override void Fire(Vector3 direction)
    {
        Animator.SetTrigger("Attack");
        Collider[] colliders = new Collider[5];
        colliders = Physics.OverlapSphere(transform.position, Range,EnemyLayerMask);
        foreach (var item in colliders)
        {
            Health targetHealth = item.transform.GetComponent<Health>();
            if (targetHealth != null)
            {
                targetHealth.TakeDamage(Damage);
                // play animation
                print("Hit -" + item.transform.name);
                break;
            }
            continue;
        }



        //RaycastHit hit;
        ////if(Physics.SphereCast(CenterPoint.position,Range, direction,out hit, Range, EnemyLayerMask))
        //if(Physics.SphereCast(transform.position,Range, direction,out hit, Range, EnemyLayerMask))
        //{
        //    Health targetHealth = hit.transform.GetComponent<Health>();
        //    if(targetHealth != null)
        //    {
        //        targetHealth.TakeDamage(Damage);
        //        // play animation
        //        print("Hit -"+hit.transform.name);
        //    }
        //}
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
