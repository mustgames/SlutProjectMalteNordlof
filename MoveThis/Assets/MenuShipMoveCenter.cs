using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuShipMoveCenter : MonoBehaviour
{
    public float spd;

    public float fovzoomInSpeed;
    public float playerScaleSpeed;

    public float maxTrun;
    public float turnSpd;

    public bool hitTrigger = false;

    public Camera cam;

    public GameObject shopUi;
    public GameObject menuFadeOut;

    public RectTransform pos;
    public Rigidbody2D rb;
    void Update()
    {
        if (pos.position.y < 1583)
        {           
            rb.AddForce(new Vector2(0, spd * Time.deltaTime));
        }else
        {
            pos.position = new Vector2(720, 1583);
            hitTrigger = true; 
        }

        if(hitTrigger == true)
        {
            if(cam.fieldOfView > 30.0f && pos.sizeDelta.x < 300)
            {
                cam.fieldOfView = cam.fieldOfView - fovzoomInSpeed * Time.deltaTime;        
                pos.sizeDelta = new Vector2(pos.sizeDelta.x + playerScaleSpeed * Time.deltaTime, pos.sizeDelta.y + playerScaleSpeed * Time.deltaTime);
            } else
            {
                shopUi.SetActive(true);

                menuFadeOut.SetActive(false);

            }
        }

        if (Input.GetAxis("hor") != 0)
        {
            if (pos.rotation.y < maxTrun && pos.rotation.y > -maxTrun)
            {
                pos.Rotate(new Vector3(0, -Input.GetAxis("hor") * Time.deltaTime * turnSpd, 0));
            }

        }            
        else if (pos.rotation.y < 0)
            {
                pos.Rotate(new Vector3(0, Time.deltaTime* turnSpd, 0));
            }
            else if (pos.rotation.y > 0)
            {
                pos.Rotate(new Vector3(0, Time.deltaTime * -turnSpd, 0));
            }
    }
}
