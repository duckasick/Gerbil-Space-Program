using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private Transform _cam;
    [SerializeField] private Animator _animator;
    
    [SerializeField] private float _groundCheckRadius = 0.3f;
    [SerializeField] private float _speed = 8;
    [SerializeField] private float acceleration; 
    [SerializeField] private float _turnSpeed = 1500f;
    [SerializeField] private float _jumpForce = 50f;

    private Rigidbody rb;
    private Vector3 _direction;

    private GravityBody _gravityBody;
    float d;

    [SerializeField] float iniSpeed;
    [SerializeField] float iniAccelForce;
    [SerializeField] float truAccelForce;
    [SerializeField] float groundFriction;
    [SerializeField] float maxSpeed;
    
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        _gravityBody = transform.GetComponent<GravityBody>();
    }

    void Update()
    {
        _direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;
        bool isGrounded = Physics.CheckSphere(_groundCheck.position, _groundCheckRadius, _groundMask);
        _animator.SetBool("isJumping", !isGrounded);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(-_gravityBody.GravityDirection * _jumpForce, ForceMode.Impulse);
        }
        d = Time.deltaTime;
    }


    public void xMovement()
    {
        void xMovement()
        {

            //Forward & backwards
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.RightArrow))
            {
                if (rb.linearVelocity.x < iniSpeed)
                {
                    rb.AddRelativeForce(new Vector3(iniAccelForce * d, 0, 0));
                }
                else
                {
                    rb.AddRelativeForce(new Vector3(truAccelForce * d, 0, 0));
                }
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.LeftArrow))
            {
                if (rb.linearVelocity.x > -iniSpeed)
                {
                    rb.AddRelativeForce(new Vector3(-iniAccelForce * d, 0, 0));
                }
                else
                {
                    rb.AddRelativeForce(new Vector3(-truAccelForce * d, 0, 0));
                }
            }

            //No Input
            if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
            {
                if (rb.linearVelocity.x > -1 && rb.linearVelocity.x < 1)
                {
                    rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);
                }
                else
                {
                    if (rb.linearVelocity.x < 0)
                    {
                        rb.AddRelativeForce(new Vector3(groundFriction * d, 0, 0));
                    }
                    if (rb.linearVelocity.x > 0)
                    {
                        rb.AddRelativeForce(new Vector3(-groundFriction * d, 0, 0));
                    }
                }
            }

            //Velocity cap;
            if (rb.linearVelocity.x < -maxSpeed) { rb.linearVelocity = new Vector2(-maxSpeed, rb.linearVelocity.y); }
            if (rb.linearVelocity.x > maxSpeed) { rb.linearVelocity = new Vector2(maxSpeed, rb.linearVelocity.y); }
        }
    }

    public void AddGrav(float force, Vector3 pos)
    {
        Vector3 direction = transform.position - pos;
        Vector3 newDir = direction.normalized;
        rb.AddForce(force * newDir, ForceMode.Impulse);
    }
    
    void FixedUpdate()
    {
        bool isRunning = _direction.magnitude > 0.1f;
        
        if (isRunning)
        {
            Vector3 direction = transform.forward * _direction.x;
            rb.MovePosition(rb.position + direction * (_speed * Time.fixedDeltaTime));
            
            
            Quaternion rightDirection = Quaternion.Euler(0f, _direction.x * (_turnSpeed * Time.fixedDeltaTime), 0f);
            Quaternion newRotation = Quaternion.Slerp(rb.rotation, rb.rotation * rightDirection, Time.fixedDeltaTime * 3f);;
            rb.MoveRotation(newRotation);
        }

        _animator.SetBool("isRunning", isRunning);
    }
}