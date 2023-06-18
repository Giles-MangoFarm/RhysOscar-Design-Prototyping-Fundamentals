using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

public class WoodLogic : MonoBehaviour
{
    public Text woodDisplay;
    public int woodCount = 0;
    public int campFireCost = 5;
    private Vector3 mousePos;
    private Vector3 objectPos;
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

        if (Input.GetButtonDown("Fire2"))
        {
            if (woodCount >= 5)
            {
                mousePos = Input.mousePosition;
                mousePos.z = 2.0f;
                objectPos = Camera.main.ScreenToWorldPoint(mousePos);
                objectPos.y = 0.5f;
                Instantiate(campFire, objectPos, Quaternion.identity);

                woodCount = woodCount - campFireCost;
            }
        }

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
            woodCount++;
        }
    }
}
