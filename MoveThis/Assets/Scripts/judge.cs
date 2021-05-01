using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class judge : MonoBehaviour
{

    public bool gameIsRunning = true;

    public Transform PLPos;

    public Transform[] enemyPos;
    public GameObject[] enemyObj;

    int place;
    public Text placeText;

    public GameObject pauseText;
    public bool isPaused = false;

    public float winZone;
    public float killZone;

    public GameObject GUi;
    public GameObject winUi;
    public GameObject deathUi;

    string placeTextString;

    void Update()
    {
        checkLead();
        checkWin();
        checkDeath();
    }
    public void pauseButton()
    {
        if (isPaused == false)
        {
            Time.timeScale = 0;
            isPaused = true;
            pauseText.SetActive(true);
            GUi.SetActive(false);
        }else
        {
            isPaused = false;
            Time.timeScale = 1;
            pauseText.SetActive(false);
            GUi.SetActive(true);
        }
    }
    public void checkLead()
    {
        if (PLPos.position.y < enemyPos[0].position.y)
        {
            place++;
        }
        if (place < 4)
        {
            if (place == 1)
            {
                placeTextString = "1st";
            }
            if (place == 2)
            {
                placeTextString = "2nd";
            }
            if (place == 3)
            {
                placeTextString = "3rd";
            }
        }
        else
        {
            placeTextString = place.ToString() + "th";

        }
        placeText.text = placeTextString;
        place = 1;
    }

    public void checkWin()
    {
        if(PLPos.position.y > winZone)
        {
            Time.timeScale = 0;
            winUi.SetActive(true);
            GUi.SetActive(false);
        }
    }
    public void checkDeath()
    {
        if (PLPos.position.y < killZone)
        {
            Time.timeScale = 0;
            GUi.SetActive(false);
            gameIsRunning = false;
        }
        
        if(enemyPos[0].position.y < killZone)
        {
            enemyObj[0].SetActive(false);
        }
    }
}
