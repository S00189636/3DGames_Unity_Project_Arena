﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Projectile : MonoBehaviour
{
    
    public string EnemyTag;
    public float Damage;
    public float Speed;
    Vector3 direction;
    public Vector3 Direction { get 
        {
            if (direction == Vector3.zero)
                return transform.forward;
            else return direction;
        }
        set { direction = value; }
    }
    public GameObject Shooter { get; set; }
    Rigidbody body { get { return this.GetComponent<Rigidbody>(); } }
    bool move = true;
    private void Update()
    {
        if (move)
        {
            body.velocity = Direction * Speed;
            //Debug.Log($"i am moving with this velocity : {body.velocity}");
        }
        //Debug.Log($"not moving :(");
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (move)
        {
            //Debug.Log($"we hit {collision.transform.name}");
            move = false;
            body.freezeRotation = true;
            body.constraints = RigidbodyConstraints.FreezeAll;
            body.velocity = Vector3.zero;
            body.useGravity = false;
            body.isKinematic = true;
            //transform.position = collision.transform.position;
            transform.parent = collision.transform;
            //Debug.Log($"{this.transform.name} - hit - {collision.transform.name}");
            if (collision.transform.tag.Contains(EnemyTag))
            {
                collision.gameObject.GetComponent<Health>().TakeDamage(Damage);
            }
        }
    }

}
