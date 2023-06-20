using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //directional inputs for player movement
    public KeyCode forward;
    public KeyCode back;
    public KeyCode left;
    public KeyCode right;

    public CharacterController charController;
    public float movementSpeed = 6f;
    private float maxSpeed = 0;

    // Awake is called before Start
    void Awake()
    {
        maxSpeed = movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        MoveInputCheck(); //constantly checks for player input
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    void MoveInputCheck()
    {
        float x = Input.GetAxis("Horizontal"); //gets the x input value
        float z = Input.GetAxis("Vertical"); //gets the z input value

        Vector3 move = Vector3.zero;

        if (Input.GetKey(forward) || Input.GetKey(back) || Input.GetKey(left) || Input.GetKey(right))
        {
            move = transform.right * x + transform.forward * z; //calculate the move vector (direction)
        }

        MovePlayer(move); //run the MovePlayer function with the vector3 value move 
    }

    void MovePlayer(Vector3 move)
    {
        charController.Move(move * maxSpeed * Time.deltaTime); //moves the GameObject using the character controller
    }
}
