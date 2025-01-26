using UnityEngine;

public class pointadded : MonoBehaviour
{
    private PlayerController pc;
    public Transform check;
    private void OnTriggerEnter(Collider other)
    {
        pc = other.GetComponent<PlayerController>();

        if (pc != null)
        {
            pc.checkPoint = check;
        }
    }
}
