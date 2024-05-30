using UnityEngine;

public class Camera_limit : MonoBehaviour
{
    public float MinX = -30f;
    public float MaxX = 30f;
    public float MinY = 15f;
    public float MaxY = 55f;
    public float MinZ = -10f;
    public float MaxZ = 10f;

    void LateUpdate()
    {
        Vector3 CurrentPosition = transform.position;
        CurrentPosition.x = Mathf.Clamp(CurrentPosition.x, MinX, MaxX);
        CurrentPosition.y = Mathf.Clamp(CurrentPosition.y, MinY, MaxY);
        CurrentPosition.z = Mathf.Clamp(CurrentPosition.z, MinZ, MaxZ);
        transform.position = CurrentPosition;
    }
}
