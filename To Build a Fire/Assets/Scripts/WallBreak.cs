using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBreak : MonoBehaviour
{
    private Ray ray = new Ray(); //defines the ray 
    private RaycastHit hitObject;
    public LayerMask layerToHit;
    public float rayLength = 10f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            CastRay();
        }
    }

    private void CastRay()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hitObject, rayLength, layerToHit))
        {
            Destroy(hitObject.collider.gameObject);
        }
    }
}
