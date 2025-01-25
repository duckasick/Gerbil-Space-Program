using UnityEngine;

public class Testrotate : MonoBehaviour
{
    public GravityAreaV2 planet;

    public GravityBodyV2 body;

    public Transform test;

    public float horizontalSpeed = 2.0F;

    public float verticalSpeed = 2.0f;

    public Transform cam;
    public float angle = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        angle += 5 * h * Time.deltaTime;
        //transform.Rotate(0, h, 0);
        transform.localRotation = Quaternion.Euler(transform.localRotation.x,angle, transform.localRotation.z);

        transform.position = body.transform.position;
        transform.up = -planet.GetGravityDirection(body);


        //transform.rotation = Quaternion.LookRotation(new Vector3(cam.forward.x, 0, cam.forward.z), -planet.GetGravityDirection(body));
    }
}
