using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Camera_move_mouse : MonoBehaviour
{
    private Vector3 LastMousePosition;

    public float DragSpeed = 2; 
    public float ScrollSpeed = 40;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LastMousePosition = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 DeltaMousePosition = Input.mousePosition - LastMousePosition;
            Vector3 movement = new Vector3(-DeltaMousePosition.x, 0f, -DeltaMousePosition.y) * DragSpeed * Time.deltaTime;
            transform.Translate(movement, Space.World);
            LastMousePosition = Input.mousePosition;
        }
        float ScrollInput = Input.GetAxis("Mouse ScrollWheel");
        Vector3 ScrollMovement = Vector3.up * ScrollInput * ScrollSpeed * Time.deltaTime;
        transform.Translate(ScrollMovement, Space.World);
    }
}
