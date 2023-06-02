using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    //public Collider2D Hitbix;
    bool CanAttack = true;
    public int CooldownTimer;
    public Animator anim;

    private void Start()
    {
        //Hitbix.enabled = false;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && CanAttack == true)
        {
            //Hitbix.enabled = true;
            Debug.Log("attack");
            anim.Play("");
            StartCoroutine(Cooldown());
        }
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
