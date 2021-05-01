using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOutline : MonoBehaviour
{
    public Transform playerPos;
    public Transform pos;
    public float verOffset;
    

    public GameObject outline;
    public float i = 0;
    public List<GameObject> collidedWith;
    public List<GameObject> collidedWith2;




    void Update()
    {

        pos.position = new Vector3(playerPos.position.x, playerPos.position.y + verOffset, playerPos.position.z);

        if (i>0)
        {
            outline.SetActive(true);
        }
        else
        {
            outline.SetActive(false);
        }
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.tag == "EnemyBlast")
        {
            if(!collidedWith.Contains(collision.gameObject))
            {
                collidedWith.Add(collision.gameObject);
                i++;
            }
        }
        if (collision.tag == "AshDroid")
        {
            if (!collidedWith.Contains(collision.gameObject))
            {
                collidedWith.Add(collision.gameObject);
                i++;
            }
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "EnemyBlast")
        {
            if (!collidedWith2.Contains(collision.gameObject))
            {
                collidedWith2.Add(collision.gameObject);
                i--;
            }
        }
        if (collision.tag == "AshDroid")
        {
            if (!collidedWith2.Contains(collision.gameObject))
            {
                collidedWith2.Add(collision.gameObject);
                i--;
            }
        }
    }
}