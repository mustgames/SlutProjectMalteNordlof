using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Blast : MonoBehaviour
{
    public float spd;
    public float dmg;
    public float moveIn;
    public GameObject exsplosion;
    public Rigidbody2D rb;
    public Transform trans;
    public Collider2D blastCollider;


    void Update()
    {
        rb.AddForce(new Vector2(0,spd * Time.deltaTime));

        if(trans.position.y > 11.5f)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D thingHit)
    {
        if (thingHit.tag == "enemy")
        {
            enemy enemy = thingHit.GetComponent<enemy>();
            if (enemy != null)
            {
                enemy.takeDMG(dmg);
            }
            Instantiate(exsplosion, trans.position + new Vector3(0, moveIn, -1), trans.rotation);
            Destroy(gameObject);
        }

    }
}
