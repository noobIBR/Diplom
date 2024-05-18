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
        string sceneName = $"C{campus}F{floor} {Lang}";
        SceneManager.LoadScene(sceneName);
    }
}
