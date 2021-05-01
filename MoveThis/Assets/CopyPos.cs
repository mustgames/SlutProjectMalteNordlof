using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyPos : MonoBehaviour
{
    public Transform pos;
    public Transform targetPos;


    void Update()
    {
        pos.position = targetPos.position;
    }
}
