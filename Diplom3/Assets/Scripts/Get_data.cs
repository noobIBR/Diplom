using System.Collections;
using UnityEngine.UI;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class Get_data : MonoBehaviour
{
    public Text TextCanvas;
    public string Campus;
    private string Aud_num;
    public string Floor;
    public string Lang;

    private void Start()
    {
        Aud_num = gameObject.name;
    }
    public void OnMouseDown()
    {
        string serverUrl = "https://localhost:7171/PushData";
        string url = $"{serverUrl}?campus={Campus}&aud_num={Aud_num}&floor={Floor}&lang={Lang}";

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
            ParsingData(responseData, Lang);
        }
    }

    public void ParsingData(string data, string lang)
    {
        string resultText = "";
        string[] values_name;
        if (data == null)
        {
            if (lang == "ru")
                resultText = "Ничего не найдено";
            else
                resultText = "Data Not Found";
        }
        else
        {
            if (lang == "ru")
            {
                values_name = new string[] { "Наименование: ", "Тип помещения: ", "Корпус: ", "Этаж: ", "Номер помещения: ", "Кафедра: ", "Кол-во мест: ", "Оборудование: " };
            }
            else
            {
                values_name = new string[] { "Name: ", "Room type: ", "Campus: ", "Floor: ", "Room number: ", "Institute: ", "Number of seats: ", "Equipment: " };
            }
            string[] values = data.Split(',').Select(s => s.Trim()).ToArray();
            for (int i = 0; i < values.Length; i++)
            {
                if (!string.IsNullOrEmpty(values[i]))
                {
                    resultText += values_name[i] + values[i] + "\n";
                }
            }
        }

        TextCanvas.text = resultText;
    }
}
