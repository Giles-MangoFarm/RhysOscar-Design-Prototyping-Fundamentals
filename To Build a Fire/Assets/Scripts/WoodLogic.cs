using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

public class WoodLogic : MonoBehaviour
{
    public Text woodDisplay; //the UI displaying the player's available wood
    public int woodCount = 0; //the number of wood the player has
    public int campFireCost = 5; //wood cost of creating a campfire
    private Vector3 mousePos; //gets the current mouse position
    private Vector3 objectPos; //gets the object position
    public GameObject campFire;
    private Ray ray = new Ray();
    private RaycastHit hitObject;
    public LayerMask layerToHit;
    public float rayLength = 5f;
    //public ColdSystem cS;

    // Start is called before the first frame update
    void Start()
    {
        /*campFire = GameObject.Find("Campfire");
        campFire.GetComponent<TheScriptOnCampfire>().TheFunctionOnCampfire();
        cS = FindObjectOfType<ColdSystem>();
        cS.playerIsFuckingFreezeing = true;*/
    }

    // Update is called once per frame
    void Update()
    {
        woodDisplay.text = "Wood: " + woodCount;

        //if the player has enough wood and inputs the right mouse button, create a campfire in front of the player at their feet
        if (Input.GetButtonDown("Fire2"))
        {
            if (woodCount >= 5)
            {
                mousePos = Input.mousePosition;
                mousePos.z = 2.0f;
                objectPos = Camera.main.ScreenToWorldPoint(mousePos);
                objectPos.y = 0.5f;
                Instantiate(campFire, objectPos, Quaternion.identity);

                woodCount = woodCount - campFireCost; //decreases the wood count by the cost of a campfire upon creating one
            }
        }

        //if the player inputs left mouse button, call the Cast Ray function
        if (Input.GetButtonDown("Fire1"))
        {
            CastRay();
        }
    }

    private void CastRay()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition); //ray is cast straight from the current camera position 

        if (Physics.Raycast(ray, out hitObject, rayLength, layerToHit))
        {
            Destroy(hitObject.collider.gameObject);
            woodCount++;
            //if the raycast hits wood layer, the wood object is destroyed and the player's wood count increases by 1
        }
    }
}
