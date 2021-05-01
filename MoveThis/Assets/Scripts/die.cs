using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class die : MonoBehaviour
{
    public Transform pos;
    public Transform outlinePos;

    public float yOffset;
    public float life;
    void Start()
    {
        outlinePos = GameObject.FindGameObjectWithTag("Outline").transform;
    }
    void Update()
    {
        pos.position = new Vector3 (outlinePos.position.x, outlinePos.position.y + yOffset, outlinePos.position.z);
        
        life--;
        if(life < 0)
        {
            Destroy(gameObject);
        }
    }
}
