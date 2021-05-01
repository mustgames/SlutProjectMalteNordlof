using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public string selectedShip;

    public RectTransform[] shipPos;
    public Rigidbody2D shipRB;

    public int selectedShipNumber = 0;

    public GameObject rightButton;
    public GameObject leftButton;

    public float middle = -25.4f;
    public float spd;

    public bool movingRight = false;
    public bool movingLeft = false;

    public 

    void Update()
    {
        if (selectedShipNumber == 0)
        {
            leftButton.SetActive(false);
        }
        else
        {
            leftButton.SetActive(true);
        }
        if (selectedShipNumber == 4)
        {
            rightButton.SetActive(false);
        }
        else
        {
            rightButton.SetActive(true);
        }

        if (movingRight)
        {
            if(selectedShipNumber == 1)
            {
                move0to1();
            }
            if (selectedShipNumber == 2)
            {
                move1to2();
            }
            if (selectedShipNumber == 3)
            {
                move2to3();
            }
            if (selectedShipNumber == 4)
            {
                move3to4();
            }
        }

        if (movingLeft)
        {
            if (selectedShipNumber == 0)
            {
                move1to0();
            }
            if (selectedShipNumber == 1)
            {
                move2to1();
            }
            if (selectedShipNumber == 2)
            {
                move3to2();
            }
            if (selectedShipNumber == 3)
            {
                move4to3();
            }
        }

    }

    public void RightButtonPressed()
    {
        selectedShipNumber++;
        movingRight = true;
    }
    public void LeftButtonPressed()
    {
        selectedShipNumber--;
        movingLeft = true;
    }

    public void move0to1 ()
    {
        if (shipPos[1].position.x >= middle)
        {
            shipRB.AddForce(new Vector2(-spd * Time.deltaTime, 0));
        }
        else
        {
            shipRB.velocity = Vector2.zero;
            movingRight = false;
        }
    }
    public void move1to2()
    {
        if (shipPos[2].position.x >= middle)
        {
            shipRB.AddForce(new Vector2(-spd * Time.deltaTime, 0));
        }
        else
        {
            shipRB.velocity = Vector2.zero;
            movingRight = false;
        }
    }
    public void move2to3()
    {
        if (shipPos[3].position.x >= middle)
        {
            shipRB.AddForce(new Vector2(-spd * Time.deltaTime, 0));
        }
        else
        {
            shipRB.velocity = Vector2.zero;
            movingRight = false;
        }
    }
    public void move3to4()
    {
        if (shipPos[4].position.x >= middle)
        {
            shipRB.AddForce(new Vector2(-spd * Time.deltaTime, 0));
        }
        else
        {
            shipRB.velocity = Vector2.zero;
            movingRight = false;
        }
    }


    public void move1to0()
    {
        if (shipPos[0].position.x <= middle)
        {
            shipRB.AddForce(new Vector2(spd * Time.deltaTime, 0));
        }
        else
        {
            shipRB.velocity = Vector2.zero;
            movingLeft = false;
        }
    }
    public void move2to1()
    {
        if (shipPos[1].position.x <= middle)
        {
            shipRB.AddForce(new Vector2(spd * Time.deltaTime, 0));
        }
        else
        {
            shipRB.velocity = Vector2.zero;
            movingLeft = false;
        }
    }
    public void move3to2()
    {
        if (shipPos[2].position.x <= middle)
        {
            shipRB.AddForce(new Vector2(spd * Time.deltaTime, 0));
        }
        else
        {
            shipRB.velocity = Vector2.zero;
            movingLeft = false;
        }
    }
    public void move4to3()
    {
        if (shipPos[3].position.x <= middle)
        {
            shipRB.AddForce(new Vector2(spd * Time.deltaTime, 0));
        }
        else
        {
            shipRB.velocity = Vector2.zero;
            movingLeft = false;
        }
    }
}
