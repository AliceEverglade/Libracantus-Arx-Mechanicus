using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    // Canvas's to turn them on & off (enter/exit)
    public Canvas PotionsShop;
    public Canvas BlackSmithShop;
    public Canvas ArtifactShop;
    public Canvas TowerShop;

    // Have nothing assigned (maybe need later to see if its on or off)
    private bool IsShowingPot;
    private bool IsShowingBS;
    private bool IsShowingArt;
    private bool IsShowingTow;

    // Public Buttons for Potion, Blacksmith & Atrifacts
    public Button PotionbuttonItem1, PotionbuttonItem2, PotionbuttonItem3, PotionbuttonItem4, PotionbuttonItem5, PotionbuttonExit;
    public Button BSButtonItem1, BSButtonItem2, BSButtonItem3, BSButtonItem4, BSButtonItem5, BSButtonExit;
    public Button ArtiButtonItem1, ArtiButtonItem2, ArtiButtonItem3, ArtiButtonItem4, ArtiButtonItem5, ArtiButtonExit;
    public Button TowButtonItem1, TowButtonItem2, TowButtonItem3, TowButtonItem4, TowButtonItem5, TowButtonExit;
        
    
    void Start()
    {
        // Start ButtonListeners Region
        #region Potion Listeners    
        PotionbuttonItem1.onClick.AddListener(TaskOnClick1);
        PotionbuttonItem2.onClick.AddListener(TaskOnClick2);
        PotionbuttonItem3.onClick.AddListener(TaskOnClick3);
        PotionbuttonItem4.onClick.AddListener(TaskOnClick4);
        PotionbuttonItem5.onClick.AddListener(TaskOnClick5);
        PotionbuttonExit.onClick.AddListener(TaskOnClickExit);
        #endregion

        #region BlackSmith Listeners
        BSButtonItem1.onClick.AddListener(TaskOnClickBS1);
        BSButtonItem2.onClick.AddListener(TaskOnClickBS2);
        BSButtonItem3.onClick.AddListener(TaskOnClickBS3);
        BSButtonItem4.onClick.AddListener(TaskOnClickBS4);
        BSButtonItem5.onClick.AddListener(TaskOnClickBS5);
        BSButtonExit.onClick.AddListener(TaskOnClickBSExit);
        #endregion

        #region Artifacts Listeners
        ArtiButtonItem1.onClick.AddListener(TaskOnClickArti1);
        ArtiButtonItem2.onClick.AddListener(TaskOnClickArti2);
        ArtiButtonItem3.onClick.AddListener(TaskOnClickArti3);
        ArtiButtonItem4.onClick.AddListener(TaskOnClickArti4);
        ArtiButtonItem5.onClick.AddListener(TaskOnClickArti5);
        ArtiButtonExit.onClick.AddListener(TaskOnClickArtiExit);
        #endregion
        
        #region Tower Listeners
        TowButtonItem1.onClick.AddListener(TaskOnClickTow1);
        TowButtonItem2.onClick.AddListener(TaskOnClickTow2);
        TowButtonItem3.onClick.AddListener(TaskOnClickTow3);
        TowButtonItem4.onClick.AddListener(TaskOnClickTow4);
        TowButtonItem5.onClick.AddListener(TaskOnClickTow5);
        TowButtonExit.onClick.AddListener(TaskOnClickTowExit);
        #endregion

    }
    
    //TaskOnClick Buttons
    #region Potion Buttons
    void TaskOnClick1()
    {
        Debug.Log("Potion Button 1 is pressed");
        Coins.countCoins -= 3;
    }
    void TaskOnClick2()
    {
        Debug.Log("Potion Button 2 is pressed");
        Coins.countCoins -= 5;
    }
    void TaskOnClick3()
    {
        Debug.Log("Potion Button 3 is pressed");
        Coins.countCoins -= 7;
    }
    void TaskOnClick4()
    {
        Debug.Log("Potion Button 4 is pressed");
        Coins.countCoins -= 13;
    }
    void TaskOnClick5()
    {
        Debug.Log("Potion Button 5 is pressed");
        Coins.countCoins -= 10;
    }

    void TaskOnClickExit()
    {
        Debug.Log("Potion Exit Button is pressed");        

        if (PotionsShop.enabled == true)
        {
            PotionsShop.enabled = !PotionsShop.enabled;
        }
        
    }
    #endregion

    #region BlackSmith Buttons
    void TaskOnClickBS1()
    {
        Debug.Log("BlackSmith Button 1 is pressed");
        Coins.countCoins -= 3;
    }

    void TaskOnClickBS2()
    {
        Debug.Log("BlackSmith Button 2 is pressed");
        Coins.countCoins -= 5;
    }

    void TaskOnClickBS3()
    {
        Debug.Log("BlackSmith Button 3 is pressed");
        Coins.countCoins -= 6;
    }

    void TaskOnClickBS4()
    {
        Debug.Log("BlackSmith Button 4 is pressed");
        Coins.countCoins -= 17;
    }

    void TaskOnClickBS5()
    {
        Debug.Log("BlackSmith Button 5 is pressed");
        Coins.countCoins -= 8;
    }

    void TaskOnClickBSExit()
    {
        Debug.Log("BlackSmith Exit Button is pressed");
        if (BlackSmithShop.enabled == true)
        {
            BlackSmithShop.enabled = !BlackSmithShop.enabled;
        }
    }
    #endregion

    #region Artifacts Buttons
    void TaskOnClickArti1()
    {
        Debug.Log("Artifact Button 1 is pressed");
        Coins.countCoins -= 3;
    }

    void TaskOnClickArti2()
    {
        Debug.Log("Artifact Button 2 is pressed");
        Coins.countCoins -= 7;
    }

    void TaskOnClickArti3()
    {
        Debug.Log("Artifact Button 3 is pressed");
        Coins.countCoins -= 14;
    }

    void TaskOnClickArti4()
    {
        Debug.Log("Artifact Button 4 is pressed");
        Coins.countCoins -= 20;
    }

    void TaskOnClickArti5()
    {
        Debug.Log("Artifact Button 5 is pressed");
        Coins.countCoins -= 8;
    }

    void TaskOnClickArtiExit()
    {
        Debug.Log("Artifact Exit Button is pressed");
        if (ArtifactShop.enabled == true)
        {
            ArtifactShop.enabled = !ArtifactShop.enabled;
        }
    }
    #endregion
   
    #region Tower Buttons
    void TaskOnClickTow1()
    {
        Debug.Log("Tower Button 1 is pressed");
        Coins.countCoins -= 10;
    }

    void TaskOnClickTow2()
    {
        Debug.Log("Tower Button 2 is pressed");
        Coins.countCoins -= 18;
    }

    void TaskOnClickTow3()
    {
        Debug.Log("Tower Button 3 is pressed");
        Coins.countCoins -= 8;
    }

    void TaskOnClickTow4()
    {
        Debug.Log("Tower Button 4 is pressed");
        Coins.countCoins -= 12;
    }

    void TaskOnClickTow5()
    {
        Debug.Log("Tower Button 5 is pressed");
        Coins.countCoins -= 5;
    }

    void TaskOnClickTowExit()
    {
        Debug.Log("Tower Exit Button is pressed");
        if (TowerShop.enabled == true)
        {
            TowerShop.enabled = !TowerShop.enabled;
        }
    }
    #endregion

}
