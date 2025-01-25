using UnityEngine;

public class CenterGravity : GravityAreaV2
{
    public override Vector3 GetGravityDirection(GravityBodyV2 _gravityBody)
    {
        return (transform.position - _gravityBody.transform.position).normalized;
    }
}
