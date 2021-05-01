using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public float spd;

    public RectTransform[] pos;
    public Rigidbody2D rb;
    public float fovzoomInSpeed;
    public float playerScaleSpeed;
    public Camera cam;
    public GameObject shopMenuUI;
    public GameObject shopMenuFadeout;
    public GameObject BottomButtons;
    public GameObject BottomButtonsFadeOut;




    public bool trigger = false;
    void Update()
    {
        if(trigger)
        {
            if (cam.fieldOfView < 60.0f && pos[0].sizeDelta.x > 100)
            {
                cam.fieldOfView = cam.fieldOfView + fovzoomInSpeed * Time.deltaTime;
                pos[0].sizeDelta = new Vector2(pos[0].sizeDelta.x + playerScaleSpeed * -Time.deltaTime, pos[0].sizeDelta.y + playerScaleSpeed * -Time.deltaTime);
                pos[1].sizeDelta = new Vector2(pos[1].sizeDelta.x + playerScaleSpeed * -Time.deltaTime, pos[1].sizeDelta.y + playerScaleSpeed * -Time.deltaTime);
                pos[2].sizeDelta = new Vector2(pos[2].sizeDelta.x + playerScaleSpeed * -Time.deltaTime, pos[2].sizeDelta.y + playerScaleSpeed * -Time.deltaTime);
                pos[3].sizeDelta = new Vector2(pos[3].sizeDelta.x + playerScaleSpeed * -Time.deltaTime, pos[3].sizeDelta.y + playerScaleSpeed * -Time.deltaTime);
                pos[4].sizeDelta = new Vector2(pos[4].sizeDelta.x + playerScaleSpeed * -Time.deltaTime, pos[4].sizeDelta.y + playerScaleSpeed * -Time.deltaTime);

            }
            else
            {
                rb.AddForce(new Vector2(0, spd * Time.deltaTime));
            }

            if(pos[0].position.y >= Screen.height)
            {
                Debug.Log("won");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    public void FlyAway()
    {
        trigger = true;
        shopMenuUI.SetActive(false);
        shopMenuFadeout.SetActive(true);
        BottomButtons.SetActive(false);
        BottomButtonsFadeOut.SetActive(true);

    }
}
