using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public float mouseSensitivity = 1000f;
    public float topClamp = -90f;
    public float bottomClamp = 90f;

    private float xRotation = 0f;
    private float yRotation = 0f;
    
    void Start()
    {
        //Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Update()
    {
        //Getting input from the mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        
        //looking up and down
        xRotation -= mouseY;
        
        //set limit for looking up and down
        xRotation = Mathf.Clamp(xRotation, topClamp, bottomClamp);
        
        //looking left and right
        yRotation += mouseX;
        
        //apply looking movement to player
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
