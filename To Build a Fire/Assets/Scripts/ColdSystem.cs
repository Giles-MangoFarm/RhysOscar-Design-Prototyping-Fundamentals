using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class ColdSystem : MonoBehaviour
{
    public float currentCold = 0f; //the player's current cold level
    public float maxCold = 30f; // the maximum possible cold level, reaching this means game over
    public float coldRate = 1f; // the rate at which cold increases
    public bool isCold; //whether cold is increasing or not

    public GameObject gameOverScreen;
    public GameObject gameOverText;
    public GameObject coldText1;
    public GameObject coldText2;
    public GameObject coldText3;
    public GameObject fireText;

    // Start is called before the first frame update
    void Start()
    {
        //at the start of the game, player is not cold and cold level is at 0
        isCold = false;
        currentCold = 0f;

        //at the start of the game, all UI is disabled
        gameOverScreen.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        coldText1.gameObject.SetActive(false);
        coldText2.gameObject.SetActive(false);
        coldText3.gameObject.SetActive(false);
        fireText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if player is cold, their cold level increases by 1 each second
        if (isCold == true)
        {
            currentCold += coldRate * Time.deltaTime;
        }

        //if the player's cold level reaches 30, it stops increasing and disables being cold
        if (currentCold >= maxCold)
        {
            isCold = false;
            currentCold = maxCold;

        }

        GameOver(); //calls to the GameOver function
        Damage(); //calls to the Damage function
       
    }

    void OnTriggerEnter(Collider col)
    {
        //if player touches Ice Water, they become cold, if they stay in the Ice Water their cold gain is doubled
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
            fireText.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider col)
    {
        //if player exits Ice Water, their cold gain returns to the normal rate
        if (col.gameObject.tag == "IceWater")
        {
            coldRate = 1f;
        }
    }

    void Damage()
    {
        //if the player's cold level reaches 5, the first warning text appears and disappears after 5 seconds
        if (currentCold >= 5f)
        {
            coldText1.gameObject.SetActive(true);
            if (currentCold >= 10f)
            {
                coldText1.gameObject.SetActive(false);
            }
        }
        //if the player's cold level reaches 15, the first warning text appears and disappears after 5 seconds
        if (currentCold >= 15f)
        {
            coldText2.gameObject.SetActive(true);
            if (currentCold >= 20f)
            {
                coldText2.gameObject.SetActive(false);
            }
        }
        //if the player's cold level reaches 25, the first warning text appears and disappears after 5 seconds
        if (currentCold >= 25f)
        {
            coldText3.gameObject.SetActive(true);
            if (currentCold == maxCold)
            {
                coldText3.gameObject.SetActive(false);
            }
        }
        //if cold is set back to 0 by a campfire, any on-screen messages are disabled
        if (currentCold == 0)
        {
            coldText1.gameObject.SetActive(false);
            coldText2.gameObject.SetActive(false);
            coldText3.gameObject.SetActive(false);
        }
    }

    

    void GameOver()
    {   //if the player reaches maximum cold level, death UI appears 
        if (currentCold == maxCold)
        {
            gameOverScreen.gameObject.SetActive(true);
            gameOverText.gameObject.SetActive(true);
        }
    }
}
