using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Projectile : MonoBehaviour
{

    public string EnemyTag;
    public float Damage;
    public float Speed;
    public LayerMask IgnoreLayer;
    Vector3 direction;
    public GameObject EffectImpact;
    public bool DestroyOnImpact = false;
    public float DestroyAfter = 1;
    Rigidbody body { get { return this.GetComponent<Rigidbody>(); } }
    bool move = true;
    public Vector3 Direction
    {
        get
        {
            if (direction == Vector3.zero)
                return transform.forward;
            else return direction;
        }
        set
        {
            direction = value;
        }
    }
    private void Update()
    {
        if (move)
        {
            //newRotation = transform.rotation;
            transform.up = direction;
            //quaternion.lookrotation(direction);
            body.velocity = Direction * Speed;
            Speed -= 0.01f * Time.deltaTime;
            Mathf.Clamp(Speed, 0, 200);
            //transform.LookAt(body.velocity,-transform.up);
        }
        //Debug.Log($"not moving :(");
    }


    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.layer == IgnoreLayer)
        {
            Debug.Log($"Projectile: We hit: {collision.transform.name} - On layer: {collision.gameObject.layer}");
            return;
        }
        if (move)
        {
            move = false;
            body.freezeRotation = true;
            body.constraints = RigidbodyConstraints.FreezeAll;
            body.velocity = Vector3.zero;
            body.useGravity = false;
            body.isKinematic = true;

            //transform.position += collision.transform.position;
            //Debug.Log($"Projectile- not ignored : i am: {transform.name} - hit layer: {LayerMask.LayerToName(collision.gameObject.layer)}");
            if (collision.gameObject.tag == EnemyTag)
            {
                collision.gameObject.GetComponent<Health>()?.TakeDamage(Damage);
                transform.parent = collision.transform;
            }
            else
            {
                if (EffectImpact != null) Instantiate(EffectImpact, transform.position, Quaternion.identity, transform.parent);
            }
            Destroy();
        }
    }


    private void Destroy()
    {
        if (DestroyOnImpact) Destroy(this.gameObject);
        else Destroy(this.gameObject, DestroyAfter);
    }

}
