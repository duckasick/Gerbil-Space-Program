using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class GravityBodyV2 : MonoBehaviour
{
    //public float gravityForce = 0;
    //public Vector3 gravityCenter = Vector3.zero;
    
    private List<GravityAreaV2> _gravityAreas;

    Rigidbody rb;
    
    public Vector3 GravityDirection
    {
        get
        {
            if (_gravityAreas.Count == 0) return Vector3.zero;
            _gravityAreas.Sort((area1, area2) => area1.Priority.CompareTo(area2.Priority));
            return _gravityAreas.Last().GetGravityDirection(this).normalized;
        }
    }
    
    public float GravityAreaforce
    {
        get
        {
            if (_gravityAreas.Count == 0) return 0;
            _gravityAreas.Sort((area1, area2) => area1.Priority.CompareTo(area2.Priority));
            return _gravityAreas.Last().gravityForce;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _gravityAreas = new List<GravityAreaV2>();

        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 gravityDirection = transform.position - GravityDirection;
        //Vector3 newDir = gravityDirection.normalized;

        rb.AddForce(GravityAreaforce * GravityDirection * Time.deltaTime, ForceMode.Acceleration);
        //transform.up = -GravityDirection;
    }

    public void AddGravityArea(GravityAreaV2 gravityArea)
    {
        _gravityAreas.Add(gravityArea);
    }

    public void RemoveGravityArea(GravityAreaV2 gravityArea)
    {
        _gravityAreas.Remove(gravityArea);
    }

}
