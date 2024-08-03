using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class REnemyScript : MonoBehaviour
{
    public Animator anim;
    public Transform character, myrope;
    private float speed, distance, radius;
    public Transform[] points;
    private byte pointcontrol;
    private Vector2 currentTarget;
    public GameObject grabble, stopcollider;
    private BoxCollider2D bc;
    public LayerMask playerLayer;
    private bool isUlti;
    private float cooldown;

    private void Start()
    {
        radius = 4.5f;
        anim = GetComponent<Animator>();
        speed = 2.5f;
        myrope = transform.GetChild(0);
        stopcollider = transform.GetChild(1).gameObject;
        bc = stopcollider.GetComponent<BoxCollider2D>();
        character = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        distance = Vector2.Distance(transform.position, character.position);
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("New State") && !isUlti)
            Range();
        scale();
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
    }

    void Range()
    {
        bool isrange = Physics2D.OverlapCircle(transform.position, 8, playerLayer);

        if (isrange && distance > radius)
        {
            anim.SetBool("isHere", true);
            anim.SetBool("isRange", false);
            transform.position = Vector2.MoveTowards(transform.position, character.position, speed * Time.deltaTime);
            speed = 3.5f;
            currentTarget = character.transform.position;
        }

        else if (isrange && distance < 2)
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("R-Punch")&& cooldown<=0)
            {
                anim.Play("R-Punch");
                cooldown = 3;
            }
            else
            {
                cooldown -= Time.deltaTime;
            }

        }
        else if (isrange)
        {
            currentTarget = character.transform.position;
            radius = 7.5f;
            anim.SetBool("isRange", true);
        }
        else
        {
            anim.SetBool("isHere", false);
            transform.position =
                Vector2.MoveTowards(transform.position, points[pointcontrol].position, speed * Time.deltaTime);
            speed = 2.5f;
            radius = 4.5f;
            currentTarget = points[pointcontrol].transform.position;
        }
    }

    public void punch()
    {
        Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, 1.3f);
        foreach (var var in hit)
        {
            if (var.gameObject.CompareTag("Player"))
            {
                var.GetComponent<Controllers>().TakeDamage(5);
            }
        }
    }

    void scale()
    {
        if (currentTarget.x < transform.position.x)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            transform.localScale = new Vector2(-1, 1);
        }
    }

    public void grabbleGo()
    {
        bc.enabled = false;
        GameObject ourGrabble = Instantiate(grabble, transform.position, Quaternion.identity);
        ourGrabble.GetComponent<grabbleScript>().selectmyparent(gameObject, myrope, stopcollider);
        Invoke("colliderenable", 0.5f);
    }

    void colliderenable()
    {
        bc.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("FollowPoint"))
        {
            switch (pointcontrol)
            {
                case 0:
                    pointcontrol = 1;
                    break;
                case 1:
                    pointcontrol = 0;
                    break;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, 1.3f);
    }
}