using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AnimationStates animState;
    [SerializeField] private PlayerStats stats;

    bool CanAttack = true;
    public AnimationStates AnimState
    {
        get => animState;
        set
        {
            if (animState != value)
            {
                animState = value;
                animator.Play(animState.ToString() + animDirection.ToString());
            }
        }
    }

    [SerializeField] private AnimationDirection animDirection;
    public AnimationDirection AnimDirection
    {
        get => animDirection;
        set
        {
            if (animDirection != value)
            {
                animDirection = value;
                animator.Play(animState.ToString() + animDirection.ToString());
            }
        }
    }

    public bool isAttacking = false;
    public enum AnimationStates
    {
        PlayerIdle,
        PlayerWalk,
        PlayerAttack
    }
    public enum AnimationDirection
    {
        Up,
        UpSide,
        Side,
        DownSide,
        Down
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        stats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        SetDirection();
        if(Input.GetKeyDown(KeyCode.F) && CanAttack == true)
        {
            isAttacking = true;
            AnimState = AnimationStates.PlayerAttack;
            StartCoroutine(CooldownSword());
        }
    }

    

    IEnumerator CooldownSword()
    {
        CanAttack = false;
        yield return new WaitForSeconds(1f);
        CanAttack = true;
    }

    private void SetDirection()
    {
        if (!isAttacking)
        {
            Vector2Int direction = new Vector2Int((int)math.abs(Input.GetAxisRaw("Horizontal")), (int)Input.GetAxisRaw("Vertical"));
            (int, int) dirTuple = new(direction.x, direction.y);
            switch (dirTuple)
            {
                case (0, 0):
                    break;
                case (0, 1):
                    AnimDirection = AnimationDirection.Up;
                    break;
                case (0, -1):
                    AnimDirection = AnimationDirection.Down;
                    break;
                case (1, 0):
                    AnimDirection = AnimationDirection.Side;
                    break;
                case (1, 1):
                    AnimDirection = AnimationDirection.UpSide;
                    break;
                case (1, -1):
                    AnimDirection = AnimationDirection.DownSide;
                    break;
            }
            if (dirTuple != (0, 0) && !isAttacking)
            {
                AnimState = AnimationStates.PlayerWalk;
            }
            else if (dirTuple == (0, 0) && !isAttacking)
            {
                AnimState = AnimationStates.PlayerIdle;
            }
        }
    }

    public void EndAttack()
    {
        isAttacking = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("player attack Collision Detected");
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log($"{collision.gameObject.name} attacked by player");
            stats.CallOnHitEffects(collision.gameObject.GetComponent<Stats>());
        }
    }
}
