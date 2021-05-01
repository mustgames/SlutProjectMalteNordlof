using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Transform enemyPos;
    public Transform enemyNRJBarPos;
    public Transform enemyBlaster;

    public GameObject enemyBlast;
    
    public Rigidbody2D emptyRotationRB;
    public Transform emptyRotationPos;

    public Transform playerPos;

    public float enemySpd;
    public float enemyNRJ = 100;
    public float enemyNRJMod;
    public float enemyNRJModBonus;

    public float uiBonus = 160;

    public float enemyNRJState0Min = -50;
    public float enemyNRJState0Max = 0;
    public float enemyNRJState1Max = 10f;
    public float enemyNRJState2Max = 50f;
    public float enemyNRJState3Max = 100;

    public float enemyCharge;
    public float enemyChargeSpd;
    public float enemyChargeMax;

    public float enemyShootingCost;
    public float enemyShootingDeley;

    public int enemyNRJState = 3;

    public GameObject enemyobj;
    public GameObject enemyNRJBar;

    void Start()
    {
        enemyNRJBar.GetComponent<enemyNRJBar>().SetMaxEnemyNRJ(enemyNRJ);
        enemyNRJBar.GetComponent<enemyNRJBar>().SetEnemyNRJValue(enemyNRJ);
    }
    public void takeDMG(float DMG)
    {
        enemyNRJ = enemyNRJ - DMG;
        enemyNRJBar.GetComponent<enemyNRJBar>().SetEnemyNRJValue(enemyNRJ);

    }
    void Update()
    {
        EnemyMove();
        EnemyShooting();
    }
    void EnemyMove()
    {
        if (enemyNRJ > enemyNRJState0Min && enemyNRJ < -enemyNRJState1Max)
        {
            enemyNRJState = 0;
        }
        else if (enemyNRJ <= enemyNRJState1Max && enemyNRJ > enemyNRJState0Max)
        {
            enemyNRJState = 1;
        }
        else if (enemyNRJ > enemyNRJState1Max && enemyNRJ <= enemyNRJState2Max)
        {
            enemyNRJState = 2;
        }
        else if (enemyNRJ > enemyNRJState2Max && enemyNRJ < enemyNRJState3Max)
        {
            enemyNRJState = 3;
        }
        enemyNRJModBonus = enemyNRJ * enemyNRJMod;
        enemyPos.position += new Vector3(0, Time.deltaTime * enemyNRJModBonus * enemySpd, 0);

        enemyNRJBarPos.position += new Vector3(0, Time.deltaTime * enemyNRJModBonus * enemySpd * uiBonus, 0);
    }
    
    void EnemyShooting()
    {                
        Vector2 target = playerPos.position;
        Vector2 aimDirection = target - emptyRotationRB.position;
        float shootAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90;
        emptyRotationRB.rotation = shootAngle;

        if (enemyPos.position.y < playerPos.position.y + enemyShootingDeley)
        {
            enemyCharge += Time.deltaTime * enemyChargeSpd;

            if (enemyCharge > enemyChargeMax && enemyNRJ > enemyShootingCost)
            {


                Instantiate(enemyBlast, enemyBlaster.position, emptyRotationPos.rotation);
                enemyNRJ = enemyNRJ - enemyShootingCost;
                enemyNRJBar.GetComponent<enemyNRJBar>().SetEnemyNRJValue(enemyNRJ);
                enemyCharge = 0;
            }
        }
        else
        {
            if (enemyCharge > 0)
            {
                enemyCharge = enemyCharge - enemyChargeSpd;
            }
        }
    }
}
