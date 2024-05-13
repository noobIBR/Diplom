using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_change : MonoBehaviour
{
    public void LoadSceneByIndex(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }
}