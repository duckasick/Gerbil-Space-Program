using UnityEngine;

public class NewPlayerStats : MonoBehaviour
{
    public float newMaxSpeed;
    public float newAcceleration;
    public float newDeceleration;
    public float newTurnSpeed;
    public float newJumpForce;


    private PlayerController pc;

    private bool doneonce = false;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        pc = other.GetComponent<PlayerController>();

        if (!doneonce)
        {
            pc.UpdateValues(newMaxSpeed, newAcceleration, newDeceleration, newTurnSpeed, newJumpForce);
            doneonce = true;
        }

        print("fak");
        pc.deceleration = 50;
        pc._rigidbody.linearVelocity = Vector3.zero;
    }
}
