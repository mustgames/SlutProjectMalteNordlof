using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class arrowScript : MonoBehaviour
{
    public GameObject rightArrow;
    public GameObject leftArrow;

    public GameObject[] enemy;

    public Transform[] enemyPos;
    public Transform PLpos;

    public float screenLenght = 5.2f;

    void Start()
    {
        rightArrow.SetActive(false);
        leftArrow.SetActive(false);
    }
    void Update()
    {
        if(enemy[0].activeSelf)
        {
            if(PLpos.position.x + screenLenght < enemyPos[0].position.x && enemyPos[0].position.y > PLpos.position.y)
            {
                rightArrow.SetActive(true);
            }
            else
            {
                rightArrow.SetActive(false);
            }
            if(enemyPos[0].position.x < PLpos.position.x - screenLenght && enemyPos[0].position.y > PLpos.position.y)
            {
                leftArrow.SetActive(true);
            }
            else
            {
                leftArrow.SetActive(false);
            }
        }

    }
}
