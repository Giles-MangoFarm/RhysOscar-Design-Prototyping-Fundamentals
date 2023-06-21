using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSpike : MonoBehaviour
{
    public GameObject hero;

    // Update is called once per frame
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            hero.GetComponent<ColdSystem>().InstaDeath();
            Debug.Log("You ded.");
        } 
    }
}
