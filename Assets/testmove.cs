using System;
using UnityEngine;

public class testmove : MonoBehaviour
{
    public Transform bingbong;
    public float acc = 5f;
    public Rigidbody rb;


    private void FixedUpdate()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            rb.AddForce(bingbong.forward * acc * Time.deltaTime);
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            rb.AddForce(-bingbong.forward * acc * Time.deltaTime);
        }
    }
}
