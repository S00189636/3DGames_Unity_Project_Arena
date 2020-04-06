using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void Death();
public delegate void TakingDamage(float amount);
public class Health : MonoBehaviour
{
    public float FullHealth;
    [SerializeField]
    public float currentHealth { get; private set; }
    public event Death OnDeath;
    public event TakingDamage OnTakingDamage ;

    private void Start()
    {
        currentHealth = FullHealth;
    }
    public void TakeDamage(float amount)
    {

        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, -0.1f, FullHealth);
        if (OnTakingDamage != null)
            OnTakingDamage(amount);
        if (currentHealth <= 0)
        {
            if (OnDeath != null)
                OnDeath();
        }
    }



}
