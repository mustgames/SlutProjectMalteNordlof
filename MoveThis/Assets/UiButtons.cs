using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiButtons : MonoBehaviour
{
    public GameObject menuUi;
    public GameObject menuUiFadeout;
    public GameObject ShopUi;
    public GameObject bottomButtons;
    public GameObject roadmapUi;
    public GameObject creditsUi;
    public GameObject settingsUi;



    public GameObject tutorialUi;
    public GameObject tutorial1Ui;
    public GameObject tutorial2Ui;



    public void PlayButton()
    {
        menuUi.SetActive(false);
        menuUiFadeout.SetActive(true);
    }
    public void MenuButton()
    {
        menuUi.SetActive(true);
        ShopUi.SetActive(false);

    }
    public void TutorialButton()
    {
        tutorialUi.SetActive(true);
        bottomButtons.SetActive(false);
        menuUi.SetActive(false);        
    }
    public void TutorialNextButton()
    {
        tutorial2Ui.SetActive(true);
        tutorial1Ui.SetActive(false);

    }
    public void TutorialToMenu()
    {
        menuUi.SetActive(true);
        bottomButtons.SetActive(true);
        tutorialUi.SetActive(false);
        roadmapUi.SetActive(false);
        creditsUi.SetActive(false);
        settingsUi.SetActive(false);

    }
    public void RoadmapButton()
    {
        roadmapUi.SetActive(true);
        menuUi.SetActive(false);
        bottomButtons.SetActive(false);
    }
    public void CreditsButton()
    {
        creditsUi.SetActive(true);
        menuUi.SetActive(false);
        bottomButtons.SetActive(false);
    }
    public void SettingsButton()
    {
        settingsUi.SetActive(true);
        menuUi.SetActive(false);
        bottomButtons.SetActive(false);
    }

}
