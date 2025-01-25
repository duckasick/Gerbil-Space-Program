using UnityEngine;

public class Testrotate : MonoBehaviour
{
    public GravityAreaV2 planet;

    public GravityBodyV2 body;

    public Transform test;

    public float horizontalSpeed = 2.0F;

    public float verticalSpeed = 2.0f;

    public Transform cam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.up = -planet.GetGravityDirection(body);

        //float h = horizontalSpeed * Input.GetAxis("Mouse X");
        //float v = verticalSpeed * Input.GetAxis("Mouse Y");
        //transform.Rotate(0, h, 0);
        
        transform.rotation = Quaternion.LookRotation(new Vector3(cam.forward.x, 0, cam.forward.z), -planet.GetGravityDirection(body));
    }
}
