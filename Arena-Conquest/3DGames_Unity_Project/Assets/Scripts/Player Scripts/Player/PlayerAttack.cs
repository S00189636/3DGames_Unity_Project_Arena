using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public PickupState PickupState;
    public Weapon currentWeapon;

    // Update is called once per frame
    private void Start()
    {
    }
    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            currentWeapon= GetComponent<Pickup>().currentWeapon.GetComponent<Weapon>();
            PickupState = GetComponent<Pickup>().pickupState;
            if (PickupState == PickupState.HasWeapon)
            {
                currentWeapon.Fire((Camera.main.transform.forward + (Vector3.up * Camera.main.transform.rotation.x)));
                Destroy(currentWeapon);
            }
        }
    }
}
