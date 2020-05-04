using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackingState
{
    Nothing,
    All,
    NormalAttack,
    Spawning,
    StarAttack
}
public class MainBoss : MonoBehaviour
{

    public MeteorAttack MeteorAttack;
    public Transform AttackPosition;
    public float NormalDamage;
    public float normalFireRate;

    float timer;
    AttackingState CurrentState;
    public bool doit = true;
    AINAVMovement MovementRef { get { return GetComponent<AINAVMovement>(); } }

    public MeshRenderer BodyRenderer;
    private void Start()
    {

    }

    private void Update()
    {
        if (doit)
        {
            MovementRef.Move(AttackPosition.position);
            BodyRenderer.material.SetColor("_EmissiveColor", new Color32(255,0,83,255));
            doit = false;
        }

    }
}
