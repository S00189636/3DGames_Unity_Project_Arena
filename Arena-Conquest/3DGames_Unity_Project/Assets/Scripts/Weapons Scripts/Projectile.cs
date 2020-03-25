using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Projectile : MonoBehaviour
{
    public GameObject Shooter;
    public float Damage;



    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log($"{this.transform.name} - hit - {collision.transform.name}");
        if (collision.transform.tag.Contains("Enemy"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(Damage);
        }
    }

}
