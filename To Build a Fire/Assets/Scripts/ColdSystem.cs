using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class ColdSystem : MonoBehaviour
{
    public float currentCold = 0f; //the player's current cold level
    public float maxCold = 25f; // the maximum possible cold level, reaching this means game over
    public float coldRate = 1f; // the rate at which cold increases
    public bool isCold; //whether cold is increasing or not

    public GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        //at the start of the game, player is not cold and cold level is at 0
        isCold = false;
        currentCold = 0f;

        gameOverScreen.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if player is cold, their cold level increases by 1 each second
        if (isCold == true)
        {
            currentCold += coldRate * Time.deltaTime;
        }

        //if the player's cold level reaches 25, it stops increasing and disables being cold
        if (currentCold >= maxCold)
        {
            isCold = false;
            currentCold = maxCold;

        }
        GameOver();
    }

    void OnTriggerEnter(Collider col)
    {
        //if player touches Ice Water, they become cold
        if (col.gameObject.tag == "IceWater")
        {
            isCold = true;
            coldRate = 2f;
        }




        //if player touches a Camp Fire, they are no longer cold and their cold level goes back to 0
        if (col.gameObject.tag == "CampFire")
        {
            isCold = false;
            currentCold = 0f;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "IceWater")
        {
            coldRate = 1f;
        }
    }

    void GameOver()
    {
        if (currentCold == maxCold)
        {
            gameOverScreen.gameObject.SetActive(true);
        }
    }
}
