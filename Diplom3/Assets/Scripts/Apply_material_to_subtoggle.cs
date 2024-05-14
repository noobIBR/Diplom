using System.Collections;
using UnityEngine.Networking;
using UnityEngine;

public class Apply_material_to_subtoggle : MonoBehaviour
{
    public int CampusNum;

    void Start()
    {
        ApplyMaterialToObjects();
    }

    void ApplyMaterialToObjects()
    {
        GameObject[] SubToggleObjects = GameObject.FindGameObjectsWithTag("SubToggle");

        foreach (GameObject SubToggleObject in SubToggleObjects)
        {
            StartCoroutine(GetAudtypeidFromServer(SubToggleObject));
        }
    }

    IEnumerator GetAudtypeidFromServer(GameObject obj)
    {
        string ServerUrl = "https://localhost:7169/ApplyMaterial";
        string ObjectName = obj.name;
        string url = $"{ServerUrl}?objectName={ObjectName}&campusNum={CampusNum}";

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error while fetching audtypeid: " + www.error);
            }
            else
            {
                string ResponseData = www.downloadHandler.text;
                int audtypeid = int.Parse(ResponseData);
                string audtypeidstring = audtypeid.ToString();
                ApplyMaterialToObject(obj, audtypeidstring);
            }
        }
    }
    void ApplyMaterialToObject(GameObject obj, string MaterialName)
    {
        Material material = Resources.Load<Material>(MaterialName);
        if (material != null)
        {
            obj.GetComponent<Renderer>().material = material;
        }
        else
        {
            Debug.LogWarning("Material " + MaterialName + " not found in resources.");
        }
    }
}
