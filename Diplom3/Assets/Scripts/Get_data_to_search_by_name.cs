using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Get_data_to_name : MonoBehaviour
{
    public InputField NameInput;
    public Text AllValues;
    public Text TextCanvas;
    public string Lang;

    public void OnSubmit()
    {
        string Name = NameInput.text;
        string serverUrl = "https://localhost:7171/PushDataByName";
        string url = $"{serverUrl}?get_aud_name={Name}&lang={Lang}";
        StartCoroutine(GetDataFromServerByName(url));
    }

    IEnumerator GetDataFromServerByName(string url)
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
            ParsingData(responseData, Lang);
        }
    }

    public void ParsingData(string data, string lang)
    {
        string ResultText = "";
        string[] values_name;
        if (data == "")
        {
            if (lang == "ru")
                ResultText = "Ничего не найдено";
            else
                ResultText = "Data Not Found";
        }
        else
        {
            if (lang == "ru")
            {
                values_name = new string[] { "Наименование: ", "Тип помещения: ", "Корпус: ", "Этаж: ", "Номер помещения: " };
            }
            else
            {
                values_name = new string[] { "Name: ", "Room type: ", "Campus: ", "Floor: ", "Room number: " };
            }
            string[] values = data.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            int i = 0;
            int j = 0;
            string TextCanvasResult = "";
            while (i < values.Length)
            {
                if (j == 5) j = 0;
                if (!string.IsNullOrEmpty(values[i].Trim()))
                {
                    ResultText += values_name[j] + values[i] + "\n";
                    if (i < 5)
                    {
                        TextCanvasResult += values_name[j] + values[i] + "\n";
                    }
                }
                i++;
                j++;
            }
            TextCanvas.text = TextCanvasResult;
            AllValues.text = ResultText;
            Debug.Log("AllValues: " + ResultText);
        }
    }
}
