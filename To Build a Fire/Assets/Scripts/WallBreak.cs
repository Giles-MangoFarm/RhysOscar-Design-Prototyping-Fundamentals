using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBreak : MonoBehaviour
{
    private Ray ray = new Ray(); //defines the ray 
    private RaycastHit hitObject; //gets the ray to hit an object
    public LayerMask layerToHit; //defines the layer the raycast will be looking to hit
    public float rayLength = 5f; //length of the ray

    void Update()
    {
        //if player clicks left mouse button, call the CastRay function
        if (Input.GetButtonDown("Fire1"))
        {
            CastRay();
        }
    }

    private void CastRay()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition); //ensures the ray emerges from the camera's center

        //if the ray hits an object on the defined layer, that object is destroyed 
        if (Physics.Raycast(ray, out hitObject, rayLength, layerToHit))
        {
            Destroy(hitObject.collider.gameObject);
        }
    }
}
