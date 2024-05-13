using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Loading_animation : MonoBehaviour
{
    public Text LoadingText;
    public Text ResultText;
    public string LoadText;

    public void StartLoading()
    {
        if (string.IsNullOrEmpty(ResultText.text))
        {
            StartCoroutine(LoadingCoroutine());
        }
    }

    private IEnumerator LoadingCoroutine()
    {
        LoadingText.gameObject.SetActive(true);
        ResultText.gameObject.SetActive(false);
        while (true)
        {
            LoadingText.text = LoadText;
            yield return new WaitForSeconds(0.1f);
            LoadingText.text = LoadText + ".";
            yield return new WaitForSeconds(0.1f);
            LoadingText.text = LoadText + "..";
            yield return new WaitForSeconds(0.1f);
            LoadingText.text = LoadText + "...";
            yield return new WaitForSeconds(0.1f);
            if (!string.IsNullOrEmpty(ResultText.text))
            {   
                LoadingText.gameObject.SetActive(false);
                ResultText.gameObject.SetActive(true);
                yield break;
            }
        }
    }
}
