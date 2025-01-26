using UnityEngine;
using UnityEngine.SceneManagement;

public class Killp : MonoBehaviour
{
    private PlayerController pc;
    private void OnTriggerExit(Collider other)
    {
        pc = other.GetComponent<PlayerController>();

        if (pc != null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
