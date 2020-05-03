using UnityEngine;

public enum EnemyState
{
    Moving,
    Attacking,
    Dead
}

public class EnemyBase : MonoBehaviour
{
    public float FieldOfView = 45;
    public float VisionDistance = 50;
    public float AttackDistance;
    public string TargetTag = "Player";
    public LayerMask TargetMask;
    public Transform CenterPoint;
    public EnemyState EnemyCurrentState 
    { 
        get {return _EnemyCurrentState; }  
        set { _EnemyCurrentState = value; } 
    }
    protected  GameObject Target;
    protected EnemyState _EnemyCurrentState;
    protected bool TargetInFOV = false;
    public virtual void Start()
    {
        Target = GameObject.FindGameObjectWithTag(TargetTag);

    }

    public virtual void Update()
    {
        TrackTarget();
    }

    public void TrackTarget()
    {
        Collider[] TargetHits;
        TargetHits = Physics.OverlapSphere(CenterPoint.position, VisionDistance, TargetMask);

        if (TargetHits.Length > 0)
        {
            // Find direstion of target
            Vector3 PlayerDirection = TargetHits[0].transform.position - CenterPoint.position;
            // Calculates angle from z-axis to target position
            float Angle = Vector3.Angle(CenterPoint.forward, PlayerDirection);

            // Check if target is in FOV
            TargetInFOV = Angle <= FieldOfView;
        }
        else
        {
            TargetInFOV = false;
        }
    }

    private void OnDrawGizmos()
    {
        Vector3 Line1;
        Vector3 Line2;

        // Sphere Vision
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(CenterPoint.position, VisionDistance);

        // FOV
        Gizmos.color = Color.yellow;
        Line1 = Quaternion.AngleAxis(FieldOfView, CenterPoint.up) * CenterPoint.forward * VisionDistance;
        Line2 = Quaternion.AngleAxis(-FieldOfView, CenterPoint.up) * CenterPoint.forward * VisionDistance;

        // Draw FOV
        Gizmos.DrawRay(CenterPoint.position, Line1);
        Gizmos.DrawRay(CenterPoint.position, Line2);

        // Draw Line to target
        if (TargetInFOV)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(CenterPoint.position, ((Target.transform.position + Vector3.up) - CenterPoint.position).normalized * VisionDistance);
        }
        

    }
}
