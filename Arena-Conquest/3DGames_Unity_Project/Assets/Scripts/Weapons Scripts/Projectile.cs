using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Projectile : MonoBehaviour
{
    
    public string EnemyTag;
    public float Damage;
    public float Speed;
    public Vector3 direction { get; set; }
    public GameObject Shooter { get; set; }
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
        transform.parent = collision.transform;
        //Debug.Log($"{this.transform.name} - hit - {collision.transform.name}");
        if (collision.transform.tag.Contains(EnemyTag))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(Damage);
        }
    }

}
