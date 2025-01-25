using UnityEngine;

public class CamScript : MonoBehaviour
{
    public GameObject planet;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(planet.transform.position);
    }
}
