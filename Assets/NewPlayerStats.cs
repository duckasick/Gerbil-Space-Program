using UnityEngine;

public class NewPlayerStats : MonoBehaviour
{
    public float newMaxSpeed;
    public float newAcceleration;
    public float newDeceleration;
    public float newTurnSpeed;
    public float newJumpForce;
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
        //print("AAAAAAAAAAAAAAAAAAAAAAA");
        if (other.TryGetComponent<PlayerController>(out PlayerController pc))
        {
            //print("BBBBBBBBBBBBBBBBBBBBBBB");
            pc.UpdateValues(newMaxSpeed, newAcceleration, newDeceleration, newTurnSpeed, newJumpForce);
        }
    }
}
