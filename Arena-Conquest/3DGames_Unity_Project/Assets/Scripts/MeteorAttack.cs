using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MeteorAttack : MonoBehaviour
{
    public GameObject MeteorPrefab;
    public float Damage;
    public float MeteorSpeed;
    public float CoolDown;
    public float numberOfAttacks;
    float timeToSpawn;
    float counter;
    public enum state { Spinning, Attacking, CoolDown }
    GameObject Player;
    public state current;


    private void Start()
    {
        Player = GameObject.Find("Player");
        timeToSpawn = Time.time + CoolDown;
    }

    private void Update()
    {
        switch (current)
        {
            case state.Spinning:
                Debug.Log("i am spinning now :D");
                break;
            case state.Attacking:
                if (timeToSpawn <= Time.time)
                {
                    Debug.Log("Boom!!" + counter);
                    GameObject projectile = Instantiate(MeteorPrefab, transform.position, transform.rotation);
                    projectile.transform.LookAt(Player.transform.position);
                    projectile.GetComponent<Projectile>().direction = projectile.transform.forward;
                    projectile.GetComponent<Projectile>().Speed = MeteorSpeed;
                    projectile.GetComponent<Rigidbody>().useGravity = false;
                    projectile.GetComponent<Projectile>().Shooter = this.gameObject;
                    projectile.GetComponent<Projectile>().Damage = Damage;
                    counter++;
                    timeToSpawn = Time.time + CoolDown;
                    if (counter >= numberOfAttacks)
                    {
                        counter = 0;
                        current = state.CoolDown;
                    }
                }
                break;
            case state.CoolDown:
                Debug.Log("making it larg again");
                Debug.Log("it's larg now ");
                current = state.Spinning;
                break;
        }
    }


    public void RainHell(int howManyTimes)
    {
        current = state.Attacking;
        numberOfAttacks = howManyTimes;
    }

}
