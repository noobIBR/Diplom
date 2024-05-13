using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_limitation : MonoBehaviour
{
    public float MinX = -10f; // Минимальное значение по оси X
    public float MaxX = 10f; // Максимальное значение по оси X
    public float MinY = 0f; // Минимальное значение по оси Y
    public float MaxY = 10f; // Максимальное значение по оси Y
    public float MinZ = -10f; // Минимальное значение по оси Z
    public float MaxZ = 10f; // Максимальное значение по оси Z

    void LateUpdate()
    {
        Vector3 CurrentPosition = transform.position;
        CurrentPosition.x = Mathf.Clamp(CurrentPosition.x, MinX, MaxX);
        CurrentPosition.y = Mathf.Clamp(CurrentPosition.y, MinY, MaxY);
        CurrentPosition.z = Mathf.Clamp(CurrentPosition.z, MinZ, MaxZ);
        transform.position = CurrentPosition;
    }
}
