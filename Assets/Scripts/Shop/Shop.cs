using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject ShopScreenOpen;
    [SerializeField] private GameObject ShopGameObject;
    [SerializeField] private GameObject Player;
    [SerializeField] public BoxCollider2D _SBC2D;
    public GameObject pauseMenuUI;
    public GameObject pauseMenuUI2;
    public GameObject ButtonsUI;
    
    
    [SerializeField] public PlayerMove _PM1;
    public static bool GameIsPaused = false;

    public bool ShopOpen = false;

    public void Start()
    {
        ShopScreenOpen.SetActive(false);
        _PM1 = Player.GetComponent<PlayerMove>();
        _SBC2D = ShopGameObject.GetComponent<BoxCollider2D>();
        
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Shop Open");
            ShopOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Shop Close");
            ShopOpen = false;
            _PM1.enabled = true;
            _SBC2D.enabled = true;

            
        }
    }

    public void Update()
    {
        if (ShopOpen == true)
        {
            if (Input.GetKeyDown("space"))
            {
                ShopScreenOpen.SetActive(true);
                Debug.Log("Shop Has Been Accesed");
                _PM1.enabled = false;
                Time.timeScale = 0f;
                GameIsPaused = true;
                pauseMenuUI.SetActive(false);
                pauseMenuUI2.SetActive(false);
                pauseMenuUI2.SetActive(false);
                ButtonsUI.SetActive(false);
                
                _SBC2D.enabled = false;
                // make it like the pause menu, where it stops time when you press the button and brings up the menu
            }
        }   
    }

    public void Resume ()
    {
        ShopScreenOpen.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        _PM1.enabled = true;
        _SBC2D.enabled = true;
        pauseMenuUI.SetActive(false);
        ButtonsUI.SetActive(false);
        pauseMenuUI2.SetActive(true);
    }
}
