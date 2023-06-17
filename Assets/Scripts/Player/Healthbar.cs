using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class Healthbar : MonoBehaviour
{
    
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;
    public GameObject target;

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
        target = player;
    }

    private void Start()
    {
        totalhealthBar.fillAmount = target.GetComponent<PlayerStats>().CurrentHP / 200;
    }
    private void Update()
    {
        currenthealthBar.fillAmount = target.GetComponent<PlayerStats>().CurrentHP / 200;

        if(target.GetComponent<PlayerStats>().CurrentHP <= 0)
        {
            SceneManager.LoadScene("MenuC");
        }

    }
}
