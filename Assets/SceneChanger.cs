using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string scene;
    public void ChangeScene()
    {
        SceneManager.LoadScene(scene);
    }
}
