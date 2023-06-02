using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class MouseControl : MonoBehaviour
{
    public float sensitivity = 800f; // mouse sensitivity
    public float clampAngle = 90f; // limiting our vertical look angle
    public Transform playerObject; // stores the transform of the player container
    public Transform camera; // stores the transform of the camera

    private Vector2 mousePos; // stores the mouse position
    private float xRotation = 0f; // final vertical rotation value

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // locks the mouse to the center of the screen
    }

    // Update is called once per frame
    void Update()
    {
        GetMousePos(); // calls a function to get the mouse position
        FixXRotation(); // clamps looking up and down
        LookAt(); // looks at the mouse position
    }

    private void GetMousePos()
    {
        mousePos.x = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        mousePos.y = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        
    }

    private void FixXRotation()
    {
        xRotation -= mousePos.y;
        xRotation = Mathf.Clamp(xRotation, -clampAngle, clampAngle);
    }

    private void LookAt()
    {
        camera.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerObject.Rotate(Vector3.up * mousePos.x);
    }
}
