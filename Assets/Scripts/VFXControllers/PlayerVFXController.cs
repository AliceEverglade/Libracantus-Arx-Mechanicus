using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVFXController : MonoBehaviour
{
    [SerializeField] private List<GameObject> swordStrikeEffects;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject effect in swordStrikeEffects)
        {
            effect.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartSlashParticles()
    {
        foreach (GameObject effect in swordStrikeEffects)
        {
            effect.SetActive(true);
        }
    }

    public void StopSlashParticles()
    {
        foreach (GameObject effect in swordStrikeEffects)
        {
            effect.SetActive(false);
        }
    }
}
