using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeObj : MonoBehaviour
{
    public float life;
    void Update()
    {
        life--;
        if(life <0)
        {
            Destroy (gameObject);
        }
    }
}
