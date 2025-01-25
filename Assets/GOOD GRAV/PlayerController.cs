using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private Transform _cam;
    [SerializeField] private Animator _animator;

    public Animator playerAnim;
    
    private float _groundCheckRadius = 0.3f;
    private float _speed = 8;
    public float _turnSpeed = 1500f;

    private Rigidbody _rigidbody;
    private Vector3 _direction;

    private GravityBody _gravityBody;

    public float acceleration;
    public float deceleration;
    public float currentSpeed = 0;
    public float maxSpeed;
    

    public float turnSpeed;

    public float timSpeed;

    public float jumpForce;

    Vector3 direction;

    bool justEntered;
    float a,b,c,d,e;

    bool isGrounded;
    
    void Start()
    {
        _rigidbody = transform.GetComponent<Rigidbody>();
        _gravityBody = transform.GetComponent<GravityBody>();
    }

    //Hoe snel
    //Hogere jump afhankelijk van speed
    //Turn
    //

    void Update()
    {
        playerAnim.SetFloat("Speed", timSpeed);
        _direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;
        isGrounded = Physics.CheckSphere(_groundCheck.position, _groundCheckRadius, _groundMask);
        if (justEntered && isGrounded)
        {
            justEntered = false;
            maxSpeed = a; acceleration = b; deceleration = c; turnSpeed = d; jumpForce = e;

        }
        _animator.SetBool("isJumping", !isGrounded);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            _rigidbody.AddForce(-_gravityBody.GravityDirection * (jumpForce * (timSpeed/100)), ForceMode.Impulse);
            _rigidbody.AddForce(-_gravityBody.GravityDirection * 4, ForceMode.VelocityChange);
        }
        if (isGrounded)
        {
            if (Input.GetKey(KeyCode.W)) {
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
            if (currentSpeed < 0) { currentSpeed = 0; }
        }

        timSpeed = map(currentSpeed, 0, maxSpeed, 0, 100);

        print(currentSpeed);
        print(timSpeed);

    }
    
    void FixedUpdate()
    {
        bool isRunning = _direction.magnitude > 0.1f;
        print(direction);
        if (isRunning && !Input.GetKey(KeyCode.S))
        {
            direction = transform.forward * _direction.z;

            Quaternion rightDirection = Quaternion.Euler(0f, _direction.x * (turnSpeed * Time.fixedDeltaTime), 0f);
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

    public void UpdateValues(float newSpeed, float newAcceleration, float newDeceleration, float newTurnSpeed, float newJumpForce)
    {
        justEntered = true;
        a = newSpeed; b = newAcceleration; c = newDeceleration; d = newTurnSpeed; e = newJumpForce;
    }

}
