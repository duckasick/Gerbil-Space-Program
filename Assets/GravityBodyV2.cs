using Unity.Burst.Intrinsics;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class GravityBodyV2 : MonoBehaviour
{
    public float gravityForce = 0;
    public Vector3 gravityCenter = Vector3.zero;
    public Vector3 downOffset;

    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 gravityDirection = transform.position - gravityCenter;
        Vector3 newDir = gravityDirection.normalized;

        rb.AddForce(gravityForce * newDir * Time.deltaTime, ForceMode.Acceleration);
        //transform.up = gravityDirection;


        Quaternion lookAt = Quaternion.LookRotation(gravityCenter);
        Quaternion correction = Quaternion.Euler(downOffset.x, downOffset.y, downOffset.z);

        transform.LookAt(gravityCenter);



    }


}
