using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Change_scene : MonoBehaviour
{
    public void LoadSceneByIndex(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }
}
