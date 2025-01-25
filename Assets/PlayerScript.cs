using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PlayerScript : MonoBehaviour
{
    /*
    [Header("Grounded")]
    public float iniAccelForce;
    public float iniSpeed;
    public float truAccelForce;
    public float groundFriction;
    public float groundSpeed;
    float maxSpeed;
    */

    [SerializeField] float accel;
    [SerializeField] float _turnSpeed;
    public float gravitySpeed;
    Vector3 fuck;

    Rigidbody rb;
    float d;

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
        _direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;
        xMovement();
    }

    void xMovement()
    {
        ///// X MOVEMENT
        // Reset Velocity
        //if (Input.GetKeyDown(KeyCode.A) && rb.linearVelocity.x > 0) { rb.linearVelocity = new Vector2(0, rb.linearVelocity.y); }
        //if (Input.GetKeyDown(KeyCode.D) && rb.linearVelocity.x < 0) { rb.linearVelocity = new Vector2(0, rb.linearVelocity.y); }

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeForce(new Vector3(0, accel * d, 0));
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddRelativeForce(new Vector3(0, accel * d, 0));
        }

        //Quaternion rightDirection = Quaternion.Euler(0f, _direction.x * (_turnSpeed * Time.fixedDeltaTime), 0f);
        //Quaternion newRotation = Quaternion.Slerp(rb.rotation, rb.rotation * rightDirection, Time.fixedDeltaTime * 3f); ;
        //rb.MoveRotation(newRotation);


        /*
        //Right
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (rb.linearVelocity.x < iniSpeed)
            {
                rb.AddRelativeForce(new Vector3(iniAccelForce * d, 0, 0), ForceMode.Force);
            }
            else
            {
                rb.AddRelativeForce(new Vector3(truAccelForce * d, 0, 0), ForceMode.Force);
            }
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (rb.linearVelocity.x > -iniSpeed)
            {
                rb.AddRelativeForce(new Vector3(-iniAccelForce * d, 0, 0), ForceMode.Force);
            }
            else
            {
                rb.AddRelativeForce(new Vector3(-truAccelForce * d, 0, 0), ForceMode.Force);
            }
        }

        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            if (rb.linearVelocity.x > -1 && rb.linearVelocity.x < 1)
            {
                rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);
            }
            else
            {
                if (rb.linearVelocity.x < 0)
                {
                    rb.AddRelativeForce(new Vector3(groundFriction * d, 0, 0), ForceMode.Force);
                }
                if (rb.linearVelocity.x > 0)
                {
                    rb.AddRelativeForce(new Vector3(-groundFriction * d, 0, 0), ForceMode.Force);
                }
            }
        }

        //Velocity cap;
        if (rb.linearVelocity.x < -maxSpeed) { rb.linearVelocity = new Vector2(-maxSpeed, rb.linearVelocity.y); }
        if (rb.linearVelocity.x > maxSpeed) { rb.linearVelocity = new Vector2(maxSpeed, rb.linearVelocity.y); }
        */
    }
}
