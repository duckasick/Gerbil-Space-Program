using UnityEngine;

public class GravidyScribp : MonoBehaviour
{
    public float gravityForce;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out PlayerController pc))
        {
            pc.AddGrav(gravityForce, new Vector3(transform.position.x, transform.position.y, transform.position.z));
        }
    }
}
