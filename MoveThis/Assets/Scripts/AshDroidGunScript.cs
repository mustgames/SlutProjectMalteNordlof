using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AshDroidGunScript : MonoBehaviour
{

    public float spawnRate;
    public float spawn;
    public Transform gunPos;
    public Vector3 startPos;
    public float xOffsetMin;
    public float xOffsetMax;

    public Transform playerPos;

    public GameObject AshDroid;

    
    void Update()
    {
        startPos.y = gunPos.position.y;
        startPos.z = gunPos.position.z;


        spawn = spawn + spawnRate * Time.deltaTime;
        if (spawn > 100)
        {
            startPos.x = gunPos.position.x + Random.Range(xOffsetMin,xOffsetMax);
            Instantiate(AshDroid, startPos, gunPos.rotation);
            spawn = 0;
        }
    }
}
