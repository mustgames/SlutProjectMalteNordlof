using UnityEngine;

public class OutlineCollison : MonoBehaviour
{
    public float NRJGain = 25;
    public NRJBar NRJBar;

    public GameObject player;

    public GameObject blink;

    public Transform pos;
    public void GainNRJ(float gainNRJ)
    {
        player = GameObject.Find("PL");
        GameObject.Find("PL").GetComponent<PLLogic>().NRJ = GameObject.Find("PL").GetComponent<PLLogic>().NRJ + NRJGain;
        NRJBar.SetNRJValue(GameObject.Find("PL").GetComponent<PLLogic>().NRJ);
        Instantiate(blink, pos.position, pos.rotation);
    }
}
