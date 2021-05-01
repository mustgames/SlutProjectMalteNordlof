using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlast : MonoBehaviour
{
    public Transform enemyBlastPos;

    public float moveIn;
    public float dmg;

    public GameObject enemyExsplosion;

    public Collider2D enemyBlastCollider;

    public Rigidbody2D rb;

    public float enemyBlastSpeed;

    public float NRJGain = 25;
    public GameObject player;

    void Update()
    {
        rb.AddForce(enemyBlastPos.up * enemyBlastSpeed * Time.deltaTime);
        if (enemyBlastPos.position.y > 11.5f)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D thingHit)
    {
        if (thingHit.tag == "Outline")
        {
            OutlineCollison outline = thingHit.GetComponent<OutlineCollison>();

            outline.GainNRJ(NRJGain);
        }

        if (thingHit.tag == "Player")
        {
            PLLogic player = thingHit.GetComponent<PLLogic>();

                player.takeDMG(dmg);
            
            Instantiate(enemyExsplosion, enemyBlastPos.position + new Vector3(0, moveIn, -1), enemyBlastPos.rotation);
            Destroy(gameObject);
        }

    }
}