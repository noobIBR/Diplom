using UnityEngine;

public class Show_data_canvass : MonoBehaviour
{
    public GameObject CanvasToShow;
    private bool CanvasActive;
    public Texture2D CursorTexture;

    void OnMouseEnter()
    {
        Cursor.SetCursor(CursorTexture, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    void LateUpdate()
    {
        if (CanvasToShow.activeSelf && CanvasToShow != null && Camera.main != null)
        {
            CanvasToShow.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 10f;
            CanvasToShow.transform.LookAt(CanvasToShow.transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
        }
    }

    void OnMouseDown()
    {
        if (CanvasToShow != null)
        {
            CanvasToShow.SetActive(!CanvasToShow.activeSelf);
            CanvasActive = !CanvasActive;
        }
    }

    public void ResetCanvasActive()
    {
        CanvasActive = false;
    }
}
