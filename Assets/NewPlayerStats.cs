using UnityEngine;

public class NewPlayerStats : MonoBehaviour
{
    public float newMaxSpeed;
    public float newAcceleration;
    public float newDeceleration;
    public float newTurnSpeed;
    public float newJumpForce;

    private PlayerController pc;
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
<<<<<<< Updated upstream
        //print("AAAAAAAAAAAAAAAAAAAAAAA");
        if (other.TryGetComponent<PlayerController>(out PlayerController pc))
        {
            //print("BBBBBBBBBBBBBBBBBBBBBBB");
=======
        pc = other.GetComponent<PlayerController>();

>>>>>>> Stashed changes
            pc.UpdateValues(newMaxSpeed, newAcceleration, newDeceleration, newTurnSpeed, newJumpForce);
            print("fak");
    }
}
