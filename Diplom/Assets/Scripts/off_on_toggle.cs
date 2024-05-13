using UnityEngine;
public class off_on_toggle : MonoBehaviour
{

    public void ToggleObjects()
    {
        bool RendererEnabled = true;
        GameObject[] ObjectsToToggle = GameObject.FindGameObjectsWithTag("Toggle");
        GameObject[] ObjectsToSubToggle = GameObject.FindGameObjectsWithTag("SubToggle");
        offontoggle(ObjectsToToggle);
        offontoggle(ObjectsToSubToggle);
        RendererEnabled = !RendererEnabled;
        Debug.Log("Renderers and colliders " + (RendererEnabled ? "enabled" : "disabled"));
    }

    public void offontoggle(GameObject[] GameObject)
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
