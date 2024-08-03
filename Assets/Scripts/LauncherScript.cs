using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherScript : MonoBehaviour
{
    public GameObject Character;
    private float distance, exposiontimer;
    private Vector2 look;
    private bool isExplosion, isreverse;
    [SerializeField] private Animator anim;
    private bool isUlti;
    private Controllers ct;
    private float reversespeed = 15;
    public Transform origin;

    private void Start()
    {
        Character = GameObject.Find("Character");
        ct = Character.GetComponent<Controllers>();
        anim = GetComponent<Animator>();
    }

    void UltiOpen()
    {
        isUlti = true;
        anim.enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }

    void UltiEnd()
    {
        isUlti = false;
        anim.enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;
    }

    private void Update()
    {
        if (!isUlti)
        {
            exposiontimer += Time.deltaTime;
            distance = Vector2.Distance(transform.position, Character.transform.position);
            if (exposiontimer >= 3.5f && !isExplosion)
                Explosion();
            else if (isreverse && !isExplosion)
                punchhead();
            else if (!isExplosion)
                Follow();
        }
    }

    void Follow()
    {
        transform.position =
            Vector2.MoveTowards(transform.position, Character.transform.position, 3.5f * Time.deltaTime);
        transform.up = Character.transform.position - transform.position;
        /*  if (transform.position.x > Character.transform.position.x)
          {
              transform.localScale = new Vector2(1, 1);
              look = new Vector2(1, 0);
          }
          else
          {
              transform.localScale = new Vector2(-1, 1);
              look = new Vector2(-1, 0);
          } */
    }

    void Explosion()
    {
        ct.boomsound();
        isExplosion = true;
        Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, 1.5f);
        anim.Play("LauncherExplosion");
        foreach (var var in hit)
        {
            if (var.gameObject.CompareTag("Enemy") && isreverse)
            {
                if (transform.position.x > var.gameObject.transform.position.x)
                    look = Vector2.left;
                else
                    look = Vector2.right;
                var.GetComponent<Rigidbody2D>().AddForce(look * 100, ForceMode2D.Impulse);
                var.gameObject.GetComponent<Enemys>().TakeDamage(20, look);
            }

            if (var.gameObject.CompareTag("Player"))
            {
                if (transform.position.x < var.gameObject.transform.position.x)
                    look = Vector2.left;
                else
                    look = Vector2.right;
                Character.GetComponent<Rigidbody2D>().AddForce(look * -1 * 10, ForceMode2D.Impulse);
                Character.GetComponent<Controllers>().TakeDamage(20);
            }
        }

        GetComponent<BoxCollider2D>().enabled = false;
        Destroy(gameObject, 1);
    }

    void punchhead()
    {
        transform.position = Vector2.MoveTowards(transform.position, origin.position, 12 * Time.deltaTime);
        // transform.Translate(new Vector2(look.x, 0) * reversespeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && !ct.ishead)
        {
            Explosion();
        }
        else if (col.gameObject.CompareTag("Player") && ct.ishead)
        {
            transform.localScale = new Vector2(1, -1);
            // transform.localScale = new Vector2(look.x * -1, 1);
            isreverse = true;
            exposiontimer -= 2;
            ct.reversesound();
        }
        else if (col.gameObject.CompareTag("Enemy") && isreverse)
        {
            Explosion();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, 1.5f);
    }
}