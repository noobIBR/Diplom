using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apply_material_to_toggle : MonoBehaviour
{
    public Material DefaultMaterial;

    void Start()
    {
        ApplyMaterialToObjects();
    }

    void ApplyMaterialToObjects()
    {
        GameObject[] ToggleObjects = GameObject.FindGameObjectsWithTag("Toggle");

        foreach (GameObject ToggleObject in ToggleObjects)
        {
            string objectName = ToggleObject.name;

            // Получение материала по названию объекта
            Material material = Resources.Load<Material>(objectName);
            if (material != null)
            {
                ApplyMaterialToObject(ToggleObject, material);
            }
            else
            {
                ApplyMaterialToObject(ToggleObject, DefaultMaterial);
            }
        }
    }

    void ApplyMaterialToObject(GameObject obj, Material material)
    {
        if (obj != null)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = material;
            }
            else
            {
                Debug.LogWarning("Object does not have a Renderer component.");
            }
        }
        else
        {
            Debug.LogWarning("Object is null.");
        }
    }
}
