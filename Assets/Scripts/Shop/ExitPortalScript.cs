using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitPortalScript : MonoBehaviour
{
    [SerializeField] private GameObject ExitScreenOpen;
    [SerializeField] private GameObject ExitGameObject;
    [SerializeField] private GameObject Player;
    [SerializeField] public BoxCollider2D _EBC2D;
    public GameObject pauseMenuUI;
    public GameObject pauseMenuUI2;
    public GameObject ButtonsUI;
    public GameObject InventoryUI;
    public GameObject InventoryUI2;
    public GameObject ButtonsUI2;
    
    
    [SerializeField] public PlayerMove _PM1;
    public static bool GameIsPaused = false;

    public bool ExitOpen = false;

    public void Start()
    {
        ExitScreenOpen.SetActive(false);
        _EBC2D = ExitGameObject.GetComponent<BoxCollider2D>();
        
    }

    private void OnEnable()
    {
        PlayerStats.onReferenceSet += SetPlayerRef;
    }

    private void OnDisable()
    {
        PlayerStats.onReferenceSet += SetPlayerRef;
    }

    private void SetPlayerRef(GameObject player)
    {
        Player = player;
        _PM1 = Player.GetComponent<PlayerMove>();
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Shop Open");
            ExitOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Shop Close");
            ExitOpen = false;
            _PM1.enabled = true;
            _EBC2D.enabled = true;

            
        }
    }

    public void Update()
    {
        if (ExitOpen == true)
        {
            if (Input.GetKeyDown("space"))
            {
                ExitScreenOpen.SetActive(true);
                Debug.Log("Shop Has Been Accesed");
                _PM1.enabled = false;
                
                GameIsPaused = true;
                pauseMenuUI.SetActive(false);
                pauseMenuUI2.SetActive(false);
                ButtonsUI.SetActive(false);
                InventoryUI.SetActive(false);
                InventoryUI2.SetActive(false);
                ButtonsUI2.SetActive(false);
                
                _EBC2D.enabled = false;
                // make it like the pause menu, where it stops time when you press the button and brings up the menu
            }
        }   
    }

    public void Resume ()
    {
        ExitScreenOpen.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        _PM1.enabled = true;
        _EBC2D.enabled = true;
        pauseMenuUI.SetActive(false);
        ButtonsUI.SetActive(false);
        pauseMenuUI2.SetActive(true);
        InventoryUI.SetActive(false);
        ButtonsUI2.SetActive(false);
        InventoryUI2.SetActive(true);
    }
}
