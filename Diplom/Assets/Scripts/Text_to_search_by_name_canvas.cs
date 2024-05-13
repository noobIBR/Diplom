using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class Text_to_search_canvas : MonoBehaviour
{
    public InputField InputField;
    public Text TextCanvas;
    public string Lang;

    public void OnSubmit()
    {
        string aud_name = InputField.text;
        string serverUrl = "https://localhost:7294/TextToSearchByNameCanvas";
        string url = $"{serverUrl}?aud_name={aud_name}";
        StartCoroutine(GetDataFromServer(url));
    }

    IEnumerator GetDataFromServer(string url)
    {
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Failed to fetch data: " + www.error);
        }
        else
        {
            string responseData = www.downloadHandler.text;
            Debug.Log("Response Data: " + responseData);
            ParseAndDisplayData(responseData, Lang);
        }
    }

    private void ParseAndDisplayData(string data, string lang)
    {
        string[] values_name;
        if (lang == "ru")
        {
            values_name = new string[] { "Наименование: ", "Корпус: ", "Этаж: ", "Номер помещения: " };
        }
        else
        {
            values_name = new string[] { "Name: ", "Campus: ", "Floor: ", "Room number: " };
        }
        string[] values = data.Split(',');
        string resultText = "";
        for (int i = 0; i < values.Length; i++)
        {
            if (!string.IsNullOrEmpty(values[i]))
            {
                resultText += values_name[i] + values[i] + "\n";
            }
        }
        TextCanvas.text = resultText;
    }
}
