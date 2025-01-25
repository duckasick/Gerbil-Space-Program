using System.Collections.Generic;
using UnityEngine;

public class LineGravity : GravityAreaV2
{
    public Vector3 p1;
    public Vector3 p2;
    
    public override Vector3 GetGravityDirection(GravityBodyV2 _gravityBody)
    {
        return (GetClosestPointOnFiniteLine(_gravityBody.transform.position, p1, p2) - _gravityBody.transform.position).normalized;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(p1, p2);
    }
    
    // For finite lines:
    Vector3 GetClosestPointOnFiniteLine(Vector3 point, Vector3 line_start, Vector3 line_end)
    {
        Vector3 line_direction = line_end - line_start;
        float line_length = line_direction.magnitude;
        line_direction.Normalize();
        float project_length = Mathf.Clamp(Vector3.Dot(point - line_start, line_direction), 0f, line_length);
        return line_start + line_direction * project_length;
    }
}
