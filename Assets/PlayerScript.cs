using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PlayerScript : MonoBehaviour
{
    

    [SerializeField] float accel;
    [SerializeField] float _turnSpeed;
    public float gravitySpeed;
    Vector3 fuck;

    Rigidbody rb;
    float d;
    public GameObject planet;

    private Vector3 _direction = Vector3.zero;

    private Vector3 gravityPos = Vector3.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        d = Time.deltaTime;
        //print(rb.linearVelocity);
        xMovement();
    }

    void xMovement()
    {


        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.forward * accel * d);
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.forward * -accel * d);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * accel * d);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * accel * d);
        }
    }
}
