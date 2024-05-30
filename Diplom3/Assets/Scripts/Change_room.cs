using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Change_room : MonoBehaviour
{
    public Text AllValues;
    public Text TextCanvas;
    public string Lang;
    private int ÑurrentOffset = 0;
    private string[] Values;

    public void OnSubmit()
    {
        ParseAllValues();
        DisplayNextValues(Lang); 

    }

    private void ParseAllValues()
    {
        Values = AllValues.text.Split(new[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries)
                               .Where(value => !string.IsNullOrWhiteSpace(value)).ToArray();
    }

    private void DisplayNextValues(string lang)
    {
        string ResultText = "";
        if (lang == "ru")
        {
            int startIndex = FindIndexOfValueStartingWith("Íàèìåíîâàíèå: ", ÑurrentOffset);
            if (startIndex != -1)
            {
                int endIndex = FindIndexOfValueStartingWith("Íîìåğ ïîìåùåíèÿ: ", startIndex);
                if (endIndex == -1)
                    endIndex = Values.Length - 1;
                for (int i = startIndex; i <= endIndex; i++)
                {
                    ResultText += Values[i] + "\n";
                }
                ÑurrentOffset = (endIndex + 1) % Values.Length;
            }
        }
        else
        {
            int startIndex = FindIndexOfValueStartingWith("Name: ", ÑurrentOffset);
            if (startIndex != -1)
            {
                int endIndex = FindIndexOfValueStartingWith("Room number: ", startIndex);
                if (endIndex == -1)
                    endIndex = Values.Length - 1;
                for (int i = startIndex; i <= endIndex; i++)
                {
                    ResultText += Values[i] + "\n";
                }
                ÑurrentOffset = (endIndex + 1) % Values.Length;
            }
        }
        TextCanvas.text = ResultText;
    }

    private int FindIndexOfValueStartingWith(string Prefix, int StartIndex)
    {
        for (int i = StartIndex; i < Values.Length; i++)
        {
            if (Values[i].StartsWith(Prefix))
            {
                return i;
            }
        }
        return -1;
    }

}
