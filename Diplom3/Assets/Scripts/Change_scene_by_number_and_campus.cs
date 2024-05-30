using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Change_scene_by_number_and_campus : MonoBehaviour
{
    public InputField CampusInput;
    public InputField NumberInput;
    public string Lang;
    public void LoadScene()
    {
        string campus = CampusInput.text;
        string aud_num = NumberInput.text;
        int floor_int = int.Parse(aud_num) / 100;
        string floor = floor_int.ToString();
        string[] Exceptions = { "401à", "401á", "402", "403à", "404", "403â", "405", "406", "407", "408" };
        if (Exceptions.Contains(aud_num) && campus == "6")
            floor = "5";
        string sceneName = $"C{campus}F{floor} {Lang}";
        SceneManager.LoadScene(sceneName);
    }
}
