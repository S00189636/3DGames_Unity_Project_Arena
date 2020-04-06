using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Healthbar : MonoBehaviour
{
    public Transform bar;
    public Health Health;
    Vector3 barX = Vector3.one;
    private void Start()
    {
        barX.x = (Health.currentHealth / Health.FullHealth);
        Health.OnTakingDamage += Health_OnTakingDamage;
    }

    private void Health_OnTakingDamage(float amount)
    {
        barX.x -= (amount / Health.FullHealth) ;
        barX.x = Mathf.Clamp(barX.x, -0.001f, Health.FullHealth);
        bar.transform.localScale = barX;
    }
}
