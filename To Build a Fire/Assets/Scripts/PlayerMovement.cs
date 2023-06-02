using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public KeyCode forward;
    public KeyCode back;
    public KeyCode left;
    public KeyCode right;

    public UnityEngine.CharacterController charController;
    public float movementSpeed = 12f;

    public float m_gravity = -9.81f;
    private Vector3 velocity;

    private float maxSpeed = 0;

    

    // Awake is called before Start
    void Awake()
    {
        maxSpeed = movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        MoveInputCheck();
    }

    void MoveInputCheck()
    {
        float x = Input.GetAxis("Horizontal"); //Gets the x input value
        float z = Input.GetAxis("Vertical"); // gets the z input value

        Vector3 move = Vector3.zero;

        if (Input.GetKey(forward) || Input.GetKey(back) || Input.GetKey(left) || Input.GetKey(right))
        {
            move = transform.right * x + transform.forward * z; // calculate the move vector (direction)
        }

        MovePlayer(move); // Run the MovePlayer function with the vector3 value move 
        
    }

    void MovePlayer(Vector3 move)
    {
        charController.Move(move * maxSpeed * Time.deltaTime); //moves the GameObject using the character controller

        velocity.y += m_gravity * Time.deltaTime; // gravity affects the jump velocity

        charController.Move(velocity * Time.deltaTime); // actually move the player up
    }

   
}
