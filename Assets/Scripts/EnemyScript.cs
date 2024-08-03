using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public SpriteRenderer sr;
    public LayerMask playerLayer;
    public Transform ChacacterTr, hitPoint;
    public Transform[] Points;
    private int pointByte;
    private float distance,cooldown;
    private Animator anim;
    private float locationx, contollocation;
    public bool iswhere, isright,isUlti;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        ChacacterTr = GameObject.FindWithTag("Player").transform;
    }
    
    void isDeath()
    {
        enabled = false;
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
    }

    private void Update()
    {
        if (!isUlti)
        {
            locationx = transform.position.x;
            contollocation = locationx;
            distance = Vector2.Distance(transform.position, ChacacterTr.position);
            Range();
        }
    }

    private void LateUpdate()
    {
        locationx = transform.position.x;
        if (contollocation < locationx)
        {
            transform.localScale = new Vector2(1, 1);
            isright = true;
        }
        else if (contollocation == locationx)
        {
            transform.localScale = transform.localScale;
        }
        else
        {
            transform.localScale = new Vector2(-1, 1);
            isright = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position,5);
    }

    void Range()
    {
        bool hit = Physics2D.OverlapCircle(transform.position, 5f, playerLayer);
        if (hit && distance > 1.5f)
        {
            Follow();
        }
        else if (!hit && !anim.GetBool("isFollow") && iswhere)
        {
            anim.Play("EnemyWhereAnim");
        }
        else if (!hit)
        {
            FollowPoint();
        }
        else
        {
            if (cooldown <= 0)
            {
                anim.SetTrigger("isAttack");
                cooldown = .5f;
            }
            else
            {
                cooldown -= Time.deltaTime;
            }
        }
    }

    public void isWherefalse()
    {
        iswhere = false;
    }

    void FollowPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, Points[pointByte].position, 1.5f * Time.deltaTime);
        anim.SetBool("isFollow", false);
    }

    void Follow()
    {
        transform.position = Vector2.MoveTowards(transform.position, ChacacterTr.position, 2 * Time.deltaTime);
        anim.SetBool("isFollow", true);
        iswhere = true;
    }

    public void Attack()
    {
        Collider2D[] hit = Physics2D.OverlapCircleAll(hitPoint.position, 1f);
        foreach (var var in hit)
        {
            if (var.CompareTag("Player"))
            {
                if (!isright)
                {
                    var.gameObject.GetComponent<Controllers>().TakeDamage(10);
                    var.gameObject.transform.position =
                        new Vector2(var.gameObject.transform.position.x - 0.5f, var.gameObject.transform.position.y);
                }

                else
                {
                    var.gameObject.GetComponent<Controllers>().TakeDamage(10);
                    var.gameObject.transform.position =
                        new Vector2(var.gameObject.transform.position.x + 0.5f, var.gameObject.transform.position.y);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("FollowPoint"))
        {
            switch (pointByte)
            {
                case 0:
                    pointByte = 1;
                    break;
                case 1:
                    pointByte = 0;
                    break;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, 5f);
        Gizmos.DrawWireSphere(hitPoint.position, 1f);
    }
}