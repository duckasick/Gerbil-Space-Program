using UnityEngine;

public class FlatGravity : GravityAreaV2
{
    public override Vector3 GetGravityDirection(GravityBodyV2 _gravityBody)
    {
        return -transform.up;
    }
}
