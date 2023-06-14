using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WoodLogic : MonoBehaviour
{
    public Text woodDisplay;
    public int woodCount = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        woodDisplay.text = "Wood: " + woodCount;
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
