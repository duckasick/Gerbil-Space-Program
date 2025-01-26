using System;
using UnityEngine;

public class Fallhelp : MonoBehaviour
{
    public PlayerController pc;
    public GravityArea grav;

    private void Start()
    {
        pc = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if (pc._airTime > 7.5)
        {
            grav.enabled = true;
            grav.GRAVITY_FORCE = 800;
        }
        else
        {
            grav.GRAVITY_FORCE = 0;
            grav.enabled = false;
        }
    }
}
