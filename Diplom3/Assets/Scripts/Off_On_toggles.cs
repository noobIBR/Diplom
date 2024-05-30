using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class off_on_toggles : MonoBehaviour
{

    public void FindToggleObjects()
    {
        bool RendererEnabled = true;
        GameObject[] ObjectsToToggle = GameObject.FindGameObjectsWithTag("Toggle");
        GameObject[] ObjectsToSubToggle = GameObject.FindGameObjectsWithTag("SubToggle");
        OffOnToggle(ObjectsToToggle);
        OffOnToggle(ObjectsToSubToggle);
        RendererEnabled = !RendererEnabled;
        Debug.Log("Renderers and colliders " + (RendererEnabled ? "enabled" : "disabled"));
    }

    public void OffOnToggle(GameObject[] GameObject)
    {
        foreach (GameObject obj in GameObject)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.enabled = !renderer.enabled;
            }
            else
            {
                Debug.LogWarning("Renderer component not found on object with tag 'Toggle': " + obj.name);
            }

            Collider collider = obj.GetComponent<Collider>();
            if (collider != null)
            {
                collider.enabled = !collider.enabled;
            }
            else
            {
                Debug.LogWarning("Collider component not found on object with tag 'Toggle': " + obj.name);
            }
        }
    }
}
