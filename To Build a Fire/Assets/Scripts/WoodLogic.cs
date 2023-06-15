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
    // Start is called before the first frame update
    void Start()
    {

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
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Wood")
        {
            woodCount++;
            Destroy(GameObject.FindWithTag("Wood"));
        }
    }
}
