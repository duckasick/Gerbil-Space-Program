using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private Transform _cam;
    [SerializeField] private Animator _animator;

    public Animator playerAnim;
    public Animator movementAnim;
    
    private float _groundCheckRadius = 0.3f;
    private float _speed = 8;
    //public float _turnSpeed = 1500f;

    public Rigidbody _rigidbody;
    private Vector3 _direction;

    private GravityBody _gravityBody;

    public float acceleration;
    public float deceleration;
    public float currentSpeed = 0;
    public float maxSpeed;

    [HideInInspector] public float standarddecel;

    public float turnSpeed;

    public float timSpeed;

    public float jumpForce;

    Vector3 direction;
    private object velocity;

    bool justEntered;
    bool isGrounded;
    float a, b, c, d, e;

   [HideInInspector] public float _airTime = 0;

    public float forwardFactor;

    Vector3 fuck;


    void Start()
    {
        _rigidbody = transform.GetComponent<Rigidbody>();
        _gravityBody = transform.GetComponent<GravityBody>();
        standarddecel = deceleration;
    }

    //Hoe snel
    //Hogere jump afhankelijk van speed
    //Turn
    //

    private bool hasLanded = false;

    void Update()
    {
        //Reload scene
        if (Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (!isGrounded)
        {
            _airTime += Time.deltaTime;
            if (_airTime > 1)
            {
                playerAnim.SetBool("isFalling", true);
            }
        }
        else
        {
            playerAnim.SetBool("isFalling", false);
        }
        
        playerAnim.SetFloat("Speed", timSpeed);
        _direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;
        isGrounded = Physics.CheckSphere(_groundCheck.position, _groundCheckRadius, _groundMask);
        if (justEntered && isGrounded)
        {
            //print("wow updated");
            justEntered = false;
            maxSpeed += a; acceleration += b; deceleration = standarddecel + c; turnSpeed += d; jumpForce += e;


        }

        // Check if the player was in the air and just landed
        if (isGrounded && !hasLanded)
        {
            // Trigger the landing animation here
            movementAnim.SetTrigger("isLanding");

            // Set the flag to true to prevent it from triggering again
            hasLanded = true;
        }

        // If the player is no longer grounded (in the air), reset the flag
        if (!isGrounded && hasLanded)
        {
            hasLanded = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            movementAnim.SetTrigger("isJumping");
            playerAnim.SetTrigger("isJumping");
            Vector3 upJump = -_gravityBody.GravityDirection.normalized * (jumpForce * 1000 + 10) * (timSpeed / 100) * Time.deltaTime;
            Vector3 forwardJump = fuck * forwardFactor * jumpForce * 1000 * (timSpeed / 100) * Time.deltaTime;
            print(upJump);
            print(forwardJump);

            _rigidbody.AddForce(upJump, ForceMode.Impulse);
            _rigidbody.AddForce(forwardJump, ForceMode.Impulse);
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
        }
        if (!Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            currentSpeed -= deceleration * Time.deltaTime;
        }

        if (!isGrounded && justEntered == false) 
        {
            currentSpeed -= deceleration * Time.deltaTime;
            _rigidbody.linearVelocity = Vector3.MoveTowards(_rigidbody.linearVelocity, Vector3.zero, deceleration * 1.5f *Time.deltaTime);
        }

        if (currentSpeed < 0) { currentSpeed = 0; }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {

        }

        timSpeed = map(currentSpeed, 0, maxSpeed, 0, 100);


        //print(currentSpeed);
        //print(timSpeed);

    }

    void FixedUpdate()
    {
  
        bool isRunning = _direction.magnitude > 0.1f;
        //print(direction);
        if (isRunning && !Input.GetKey(KeyCode.S) && isGrounded)
        {
            direction = transform.forward * _direction.z;

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                fuck = fuck;
            }
            else { fuck = direction; }


            //print(direction);
            //print(fuck);


            Quaternion rightDirection = Quaternion.Euler(0f, _direction.x * (turnSpeed * Time.fixedDeltaTime), 0f);
            Quaternion newRotation = Quaternion.Slerp(_rigidbody.rotation, _rigidbody.rotation * rightDirection, Time.fixedDeltaTime * 3f);;
            _rigidbody.MoveRotation(newRotation);
        }
        _rigidbody.MovePosition(_rigidbody.position + transform.forward * (currentSpeed * Time.fixedDeltaTime));

        //if (Input.GetKey(KeyCode.W)) { _rigidbody.MovePosition(_rigidbody.position + direction.normalized * (currentSpeed * Time.fixedDeltaTime)); }
        //else if (!Input.GetKey(KeyCode.W)) { _rigidbody.MovePosition(_rigidbody.position + fuck.normalized * (currentSpeed * Time.fixedDeltaTime)); }
    }

    float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }

    public void UpdateValues(float newSpeed, float newAcceleration, float newDeceleration, float newTurnSpeed, float newJumpForce)
    {
        //print("start update");
        justEntered = true;
        a = newSpeed; b = newAcceleration; c = newDeceleration; d = newTurnSpeed; e = newJumpForce;
    }

}
