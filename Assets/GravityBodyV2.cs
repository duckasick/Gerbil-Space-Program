using UnityEngine;
using static UnityEditor.PlayerSettings;

public class GravityBodyV2 : MonoBehaviour
{
    public float gravityForce = 0;
    public Vector3 gravityCenter = Vector3.zero;

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

        rb.AddForce(gravityForce * gravityDirection * Time.deltaTime, ForceMode.Acceleration);
        //transform.up = gravityDirection;
    }


}
