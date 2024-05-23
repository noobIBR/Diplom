using UnityEngine;
using UnityEngine.UI;

public class Appear_change_room_button : MonoBehaviour
{
    public Text AllValues;
    public Button Button;

    private void Update()
    {
        string[] lines = AllValues.text.Split(new[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        if (lines.Length > 5)
        {
            Button.gameObject.SetActive(true);
        }
        else
        {
            Button.gameObject.SetActive(false);
        }
    }
}
