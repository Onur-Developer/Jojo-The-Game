using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEnemyScript : MonoBehaviour
{
    public LayerMask playerLayer;
    public GameObject Character;
    private float distance;
    public Transform[] Points;
    private Transform target;
    private byte bytePoint;
    private Vector2 look;
    private float speed;
    public bool isBuff, isAttack, isReady,isUlti;
    [SerializeField] private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        Character = GameObject.FindWithTag("Player");
        changetarget();
        speed = 2;
        isBuff = true;
    }
    
    void UltiOpen()
    {
        isUlti = true;
        anim.enabled = false;
    }

    void UltiEnd()
    {
        isUlti = false;
        anim.enabled = true;
        speed = 2;
    }
    private void Update()
    {
        if (!isUlti)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("S-Rest"))
            {
                transform.position = transform.position;
                isBuff = true;
                isReady = false;
                speed = 2;
            }
            else
            {
                distance = Vector2.Distance(transform.position, Character.transform.position);
                Range();

                if (transform.position.x > target.position.x)
                {
                    transform.localScale = new Vector2(-1, 1);
                    look = new Vector2(-1, 0);
                }
                else
                {
                    transform.localScale = new Vector2(1, 1);
                    look = new Vector2(1, 0);
                }
            }
        }
    }

    void Range()
    {
        bool range = Physics2D.OverlapCircle(transform.position, 7, playerLayer);

        if (range && distance > 4 && !isReady)
        {
            anim.SetBool("isReady", false);
            Follow();
        }

        else if (range && !anim.GetCurrentAnimatorStateInfo(0).IsName("S-Attack") && distance < 7)
        {
            anim.SetBool("isReady", true);
            isReady = true;
        }

        else if (isAttack)
        {
            Attack();
        }
        else if (!range)
        {
            changetarget();
        }
    }

    void Follow()
    {
        target = Character.transform;
        anim.SetBool("isHere", true);
        transform.position =
            Vector2.MoveTowards(transform.position, Character.transform.position, speed * Time.deltaTime);
    }

    void changetarget()
    {
        anim.SetBool("isHere", false);
        transform.position = Vector2.MoveTowards(transform.position, Points[bytePoint].transform.position,
            speed * Time.deltaTime);
        target = Points[bytePoint];
        speed = 2;
    }

    public void isattack()
    {
        isAttack = true;
        // Debug.Log("attack");
    }

    void Attack()
    {
        transform.position =
            Vector2.MoveTowards(transform.position, Character.transform.position, speed * Time.deltaTime);
        Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, 1.2f);

        foreach (var var in hit)
        {
            if (var.gameObject.CompareTag("Player"))
            {
                Character.GetComponent<Rigidbody2D>().AddForce(look * 10);
                Character.GetComponent<Controllers>().TakeDamage(0.3f);
            }
        }

        if (isBuff)
        {
            StartCoroutine("speedBuff");
            isBuff = false;
        }
    }

    void isDeath()
    {
        enabled = false;
    }

    IEnumerator speedBuff()
    {
        speed = 7f;
        yield return new WaitForSeconds(1.7f);
        speed = 2;
        anim.SetTrigger("isRest");
        isAttack = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("FollowPoint"))
        {
            switch (bytePoint)
            {
                case 0:
                    bytePoint = 1;
                    break;
                case 1:
                    bytePoint = 0;
                    break;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, 7f);
        Gizmos.DrawWireSphere(transform.position, 1.2f);
    }
}