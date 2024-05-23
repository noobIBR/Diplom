using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Get_data_to_search_by_number : MonoBehaviour
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
        string serverUrl = "https://localhost:7169/PushData";
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
                    ResultText += values_name[i] + values[i] + "\n";
                }
            }
        }

        TextCanvas.text = ResultText;
    }
}
