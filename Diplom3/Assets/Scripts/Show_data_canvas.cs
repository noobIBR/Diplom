using UnityEngine;

public class Show_data_canvass : MonoBehaviour
{
    public GameObject CanvasToShow;
    private bool CanvasActive;
    public Texture2D CursorTexture;

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
