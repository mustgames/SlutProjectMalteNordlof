using UnityEngine;
using UnityEngine.UI;
public class EarthParalaxMove : MonoBehaviour
{
    public RectTransform earthPos;
    public float earthSpd;
    public GameObject PL;

    void Update()
    {
         float NRJ = PL.GetComponent<PLLogic> ().NRJ;

        earthPos.position += new Vector3(Input.GetAxis("hor") * earthSpd * Time.deltaTime * NRJ, 0, 0);
    }
}
