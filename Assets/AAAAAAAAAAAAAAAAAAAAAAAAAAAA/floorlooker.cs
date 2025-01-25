using UnityEngine;

public class floorlooker : MonoBehaviour
{
    public GravityAreaV2 planet;
    
    public GravityBodyV2 body;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(planet.transform);
        
        transform.position = body.transform.position;

    }
}
