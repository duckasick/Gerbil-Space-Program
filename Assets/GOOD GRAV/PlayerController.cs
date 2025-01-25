using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private Transform _cam;
    [SerializeField] private Animator _animator;
    
    private float _groundCheckRadius = 0.3f;
    private float _speed = 8;
    private float _turnSpeed = 1500f;

    private Rigidbody _rigidbody;
    private Vector3 _direction;

    private GravityBody _gravityBody;

    public float acceleration;
    public float deceleration;
    public float currentSpeed = 0;
    public float maxSpeed;

    public float turnAccel;
    public float currentTurnSpeed;

    public float timSpeed;

    public float jumpForce;

    Vector3 direction;
    
    void Start()
    {
        _rigidbody = transform.GetComponent<Rigidbody>();
        _gravityBody = transform.GetComponent<GravityBody>();
    }


    void Update()
    {
        _direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;
        bool isGrounded = Physics.CheckSphere(_groundCheck.position, _groundCheckRadius, _groundMask);
        _animator.SetBool("isJumping", !isGrounded);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            float trueJumpForce = jumpForce * (timSpeed / 100);

            _rigidbody.AddForce(-_gravityBody.GravityDirection * jumpForce, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.W))
        {
            currentSpeed += acceleration * Time.deltaTime;
            if (currentSpeed > maxSpeed)
            {
                currentSpeed = maxSpeed;
            }
        }
        if (!Input.GetKey(KeyCode.W))
        {
            currentSpeed -= deceleration * Time.deltaTime;
        }
        /*if (Input.GetKey(KeyCode.S))
        {
            currentSpeed -= acceleration * Time.deltaTime * 1.5f;
        }
        */
        if (currentSpeed < 0) { currentSpeed = 0; }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            currentTurnSpeed += turnAccel;
        }
        else { currentTurnSpeed -= turnAccel * 3; if (currentTurnSpeed < 0) { currentTurnSpeed = 0; } }


        timSpeed = map(currentSpeed, 0, maxSpeed, 0, 100);

        print(currentSpeed);
        print(timSpeed);

    }
    
    void FixedUpdate()
    {
        bool isRunning = _direction.magnitude > 0.1f;

        if (isRunning && direction.y >= 0)
        {
            direction = transform.forward * _direction.z;

            Quaternion rightDirection = Quaternion.Euler(0f, _direction.x * (currentTurnSpeed * Time.fixedDeltaTime), 0f);
            Quaternion newRotation = Quaternion.Slerp(_rigidbody.rotation, _rigidbody.rotation * rightDirection, Time.fixedDeltaTime * 3f);;
            _rigidbody.MoveRotation(newRotation);
        }

        _rigidbody.MovePosition(_rigidbody.position + direction * (currentSpeed * Time.fixedDeltaTime));

        _animator.SetBool("isRunning", isRunning);
    }

    float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }

}
