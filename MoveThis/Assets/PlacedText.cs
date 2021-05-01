using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlacedText : MonoBehaviour
{
    public Text target;
    public Text text;
    void Update()
    {
        text.text = target.text;
    }
}
