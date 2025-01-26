using System;
using UnityEngine;

public class a : MonoBehaviour
{
    private PlayerController pc;
    public SceneChanger scenec;
    private void OnTriggerEnter(Collider other)
    {
        pc = other.GetComponent<PlayerController>();

        if (pc != null)
        {
            scenec.ChangeScene();
        }
    }
}
