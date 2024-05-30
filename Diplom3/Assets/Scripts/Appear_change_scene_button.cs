using UnityEngine;
using UnityEngine.UI;

public class Appear_change_scene_button : MonoBehaviour
{
    public Text ResultText;
    public Button Button;

    void Update()
    {
        string text = ResultText.text;
        if (string.IsNullOrEmpty(text) || (text.Contains("Ничего не найдено", System.StringComparison.OrdinalIgnoreCase) || text.Contains("Data Not Found", System.StringComparison.OrdinalIgnoreCase)))
        {
            Button.gameObject.SetActive(false);
        }
        else
        {
            Button.gameObject.SetActive(true);
        }
    }
}
