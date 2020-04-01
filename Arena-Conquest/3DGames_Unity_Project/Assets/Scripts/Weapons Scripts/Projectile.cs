using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Projectile : MonoBehaviour
{
    public GameObject Shooter;
    public float Damage;
    public float Speed;
    public Vector3 direction;
    Rigidbody body { get { return this.GetComponent<Rigidbody>(); } }
    bool move = true;
    private void Update()
    {

        if (move)
            body.velocity = direction * Speed;

    }


    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log($"we hit {collision.transform.name}");
        move = false;
        body.freezeRotation = true;
        body.velocity = Vector3.zero;
        body.useGravity = false;

        //Debug.Log($"{this.transform.name} - hit - {collision.transform.name}");
        if (collision.transform.tag.Contains("Enemy"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(Damage);
        }
    }

}
