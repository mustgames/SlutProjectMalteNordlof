using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AshDroidTravel : MonoBehaviour
{
    public Transform pos;
    public Rigidbody2D ashDroidRB;

    public float speed;

    public float rotaionSpeed;

    public float enemyDmg;
    public float playerDmg;
    public float NRJGain;

    void Update()
    {

        speed = speed * Time.deltaTime;
        pos.position = new Vector3 (pos.position.x,pos.position.y + speed, pos.position.z);

        float rotaion = Random.Range(0,360); 
        rotaion = rotaion * rotaionSpeed * Time.deltaTime;
        ashDroidRB.rotation = rotaion;       
    }
    public void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        enemy enemy = collisionInfo.GetComponent<enemy>();
        if ( collisionInfo.tag == "enemy")
        {
            enemy.takeDMG(enemyDmg);
            Destroy(gameObject);
        }
        PLLogic player = collisionInfo.GetComponent<PLLogic>();
        if (collisionInfo.tag == "Player")
        {
            player.takeDMG(playerDmg);
            Destroy(gameObject);
        }
        if (collisionInfo.tag == "Outline")
        {
            OutlineCollison outline = collisionInfo.GetComponent<OutlineCollison>();

            outline.GainNRJ(NRJGain);
        }
    }
}
