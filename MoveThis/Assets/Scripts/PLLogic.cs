using UnityEngine;
using UnityEngine.UI;
public class PLLogic : MonoBehaviour
{

    public Transform[] moveThing;
    public Transform[] NRJbarPos;

    public Transform blaster;
    public GameObject blastPrefap;

    public float horSpd;
    public float verSpd;

    public float NRJ;
    public int NRJState = 3;

    public float verNRJ = 50;

    public float NRJState0Min = -50;
    public float NRJState0Max = 0;

    public float NRJState1Max = 12.5f;
    public float NRJState2Max = 18.75f;
    public float NRJState3Max = 50;

    public float maxTrun = 25.0f;

    public float turnSpd;
    public float turnSpdNRJMod;



    public float horNRJSpeedBounusMod;
    float horNRJSpeedBonus;
  
    public float verNRJSpeedBonusMod;
    float verNRJSpeedBonus;
   
    public float shootingNRJCost;

    public float charge;
    public float chargeSpeed;
    public float maxCharge;
    static bool charged = false;

    public GameObject chargeObject;
    public ChargeBar chargeBar;
    
    public NRJBar NRJBar;
    string NRJTextString;
    public Text NRJTextUI;

    public float uiBonus = 160;



    void Start()
    {
        chargeBar.SetMaxCharge(maxCharge);
        chargeBar.SetChargeValue(charge);
        NRJBar.SetMaxNRJ(NRJState);
        NRJBar.SetNRJValue(NRJState);
    }

    void Update()
    {
        HorMove();
        VertMove();
        Shooting();
    }
    public void takeDMG(float DMG)
    {
        if(NRJ > 0)
        {
            NRJ = NRJ - DMG;
            NRJBar.SetNRJValue(NRJState);
        }

        //shake screen?

    }
    public void GainNRJ(float gainNRJ)
    {
        if (NRJ < 100)
        {
            NRJ = NRJ + gainNRJ;
            NRJBar.SetNRJValue(NRJState);
            if(NRJ < 100)
            {
                NRJ = 100;
            }
        }
    }
    public void HorMove()
    {
        horNRJSpeedBonus = NRJ * horNRJSpeedBounusMod;

        if (Input.GetAxis("hor") != 0) // rör spelaren med unitys input system genom att kolla alla inputs på horizentala axien 
                                       // Movething array följer listan i unity engine Hierarcy
        {
            moveThing[0].position += new Vector3(Input.GetAxis("hor") * Time.deltaTime * horSpd * horNRJSpeedBonus, 0, 0);
            moveThing[1].position += new Vector3(Input.GetAxis("hor") * Time.deltaTime * horSpd * horNRJSpeedBonus, 0, 0);
            moveThing[2].position += new Vector3(Input.GetAxis("hor") * Time.deltaTime * horSpd * horNRJSpeedBonus, 0, 0);
            moveThing[3].position += new Vector3(Input.GetAxis("hor") * Time.deltaTime * horSpd * horNRJSpeedBonus, 0, 0);
            moveThing[4].position += new Vector3(Input.GetAxis("hor") * Time.deltaTime * horSpd * horNRJSpeedBonus, 0, 0);
            moveThing[5].position += new Vector3(Input.GetAxis("hor") * Time.deltaTime * horSpd * horNRJSpeedBonus, 0, 0);

            NRJbarPos[0].position += new Vector3(-uiBonus * Input.GetAxis("hor") * Time.deltaTime * horSpd * horNRJSpeedBonus, 0, 0);

            if (moveThing[1].rotation.y < maxTrun && moveThing[1].rotation.y > -maxTrun)
            {

                moveThing[1].Rotate(new Vector3(0, -Input.GetAxis("hor") * Time.deltaTime * turnSpd * turnSpdNRJMod, 0));

            
            }        
        }
        else if (moveThing[1].rotation.y < 0)
        {
            moveThing[1].Rotate(new Vector3(0, Time.deltaTime * turnSpd * turnSpdNRJMod, 0));

        }
        else if (moveThing[1].rotation.y > 0)
        {
            moveThing[1].Rotate(new Vector3(0, Time.deltaTime * -turnSpd * turnSpdNRJMod, 0));

        }
    }

    public void VertMove()
    {
        verNRJ = NRJ - 50;

        NRJTextString = NRJ.ToString() + "/100";
        NRJTextUI.text = NRJTextString;

        if (verNRJ > NRJState0Min && verNRJ < -NRJState1Max)
        {
            NRJState = 0;
        }
        else if (verNRJ <= NRJState1Max && verNRJ > NRJState0Max)
        {
            NRJState = 1;
        }
        else if (verNRJ > NRJState1Max && verNRJ <= NRJState2Max)
        {
            NRJState = 2;
        }
        else if (verNRJ > NRJState2Max && verNRJ < NRJState3Max)
        {
            NRJState = 3;
        }

        NRJBar.SetNRJValue(NRJState);

        if (NRJState == 0)
        {
            verNRJSpeedBonus = verNRJ * verNRJSpeedBonusMod;
        }
        else if (NRJState == 1)
        {
            verNRJSpeedBonus = 0;
        }
        else if (NRJState > 1)
        {
            verNRJSpeedBonus = verNRJ * verNRJSpeedBonusMod;
        }
        moveThing[1].position += new Vector3(0, Time.deltaTime * verSpd * verNRJSpeedBonus, 0);
        NRJbarPos[1].position += new Vector3(0, uiBonus * Time.deltaTime * verSpd * verNRJSpeedBonus, 0);

    }

    public void Shooting()
    {
        if (charge >= maxCharge)
        {
            charged = true;
        }
        else
        {
            charged = false;
        }

        if (Input.GetKey(KeyCode.Space) && charged == false)
        {
            charge = charge + chargeSpeed;
            chargeBar.SetChargeValue(charge);
            chargeObject.SetActive(true);
        }
        else if (!Input.GetKey(KeyCode.Space) && charge > 0.0f)
        {
            charge = 0;
            chargeBar.SetChargeValue(charge);
            chargeObject.SetActive(true);

        }
        else if(charged == false)
        {
            chargeObject.SetActive(false);
        }

        if (Input.GetKeyUp(KeyCode.Space) && charged == true && NRJ >= shootingNRJCost)
        {
            NRJ = NRJ - shootingNRJCost;
            Instantiate(blastPrefap, blaster.position, blaster.rotation);
            charge = 0;
        }
        NRJBar.SetNRJValue(NRJState);
    }
}
