using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using System.Linq;

public class Text_to_search_by_number_canvas : MonoBehaviour
{
    public InputField CampusInput;
    public InputField NumberInput;
    public Text TextCanvas;
    public string Lang;

    public void OnSubmit()
    {
        string campus = CampusInput.text;
        string aud_num = NumberInput.text;
        int floor_int = int.Parse(aud_num) / 100;
        string floor = floor_int.ToString();
        string serverUrl = "https://localhost:7294/TextToCanvas";
        string url = $"{serverUrl}?campus={campus}&floor={floor}&aud_num={aud_num}&lang={Lang}";
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
            values_name = new string[] { "Наименование: ", "Тип помещения: ", "Корпус: ", "Этаж: ", "Номер помещения: ", "Кафедра: ","Факультет: ", "Кол-во мест: ", "Оборудование: " };
        }
        else
        {
            values_name = new string[] { "Name: ", "Room type: ", "Campus: ", "Floor: ", "Room number: ", "Institute: ", "Department: ", "Number of seats: ", "Equipment: " };
        }
        string[] values = data.Split(',').Select(s => s.Trim()).ToArray();
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
