using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MadeByScreenScript : MonoBehaviour
{
    public float waitTime1;
    public float waitTime2;
    public float waitTime3;


    public float time;
    public float spd;

    public GameObject moveText;
    public GameObject fadeIn;
    public GameObject fadeOut;

    void Update()
    {
        if(waitTime1 < time)
        {
            moveText.SetActive(true);
        }
        if (waitTime2 < time)
        {
            fadeOut.SetActive(true);
            fadeIn.SetActive(false);

        }
        if (waitTime3 < time)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        time = time + spd * Time.deltaTime;

    }
}
