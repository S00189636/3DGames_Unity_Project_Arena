using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public PickupState PickupState;
    //public GameObject currentWeapon;
    public float power = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            PickupState = GetComponent<Pickup>().pickupState;
            if (PickupState == PickupState.HasWeapon)
            {
                GetComponent<Pickup>().currentWeapon.GetComponent<Rigidbody>().AddForce( power * (Camera.main.transform.forward + (Vector3.up * Camera.main.transform.rotation.x) ),ForceMode.Impulse);
                GetComponent<Pickup>().currentWeapon.GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }
}
