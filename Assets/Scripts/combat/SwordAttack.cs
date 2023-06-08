using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    //public Collider2D Hitbix;
    bool CanAttack = true;
    public int CooldownTimer;
    PlayerAnimation anim;

    private void Start()
    {
        //Hitbix.enabled = false;
        anim = GetComponent<PlayerAnimation>();
    }

    IEnumerator Cooldown()
    {
        //yield return new WaitForSeconds(0.1f);
        //Hitbix.enabled = false;
        CanAttack = false;
        yield return new WaitForSeconds(CooldownTimer);
        Debug.Log("reset");
        CanAttack = true;
    }
}
