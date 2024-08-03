using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabbleScript : MonoBehaviour
{
    public Transform character, ropeposition, myrope, dontdestroy;
    private bool goingDirection;
    private BoxCollider2D bc;
    private GameObject myparent, stopcol;
    private LineRenderer lr;
    private Animator anim;
    private float speed;
    private bool isUlti;

    private void Awake()
    {
        dontdestroy = GameObject.Find("DontDestroy").transform;
        character = GameObject.Find("Character").transform;
        bc = GetComponent<BoxCollider2D>();
        lr = GetComponent<LineRenderer>();
        myrope = transform.GetChild(0);
        anim = GetComponent<Animator>();
        speed = 10;
    }

    private void Start()
    {
        Invoke("back", 1);
    }

    public void selectmyparent(GameObject parent, Transform ropePosition, GameObject stopcollider)
    {
        myparent = parent;
        ropeposition = ropePosition;
        stopcol = stopcollider;
    }

    void UltiOpen()
    {
        bc.enabled = false;
        isUlti = true;
        anim.enabled = false;
    }

    void UltiEnd()
    {
        bc.enabled = true;
        isUlti = false;
        anim.enabled = true;
        speed = 10;
    }

    private void Update()
    {
        if (!isUlti)
        {
            lr.SetPosition(0, ropeposition.position);
            lr.SetPosition(1, myrope.position);

            if (!goingDirection)
            {
                transform.position =
                    Vector2.MoveTowards(transform.position, character.position, speed * Time.deltaTime);
            }
            else
            {
                transform.position =
                    Vector2.MoveTowards(transform.position, myparent.transform.position, speed * Time.deltaTime);
            }

            if (character.position.x < transform.position.x)
            {
                transform.localScale = new Vector2(1, 1);
            }
            else
            {
                transform.localScale = new Vector2(-1, 1);
            }
        }

        if (myparent == null)
        {
            Destroy(gameObject);
        }
    }

    void back()
    {
        goingDirection = true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            character.transform.SetParent(gameObject.transform);
            goingDirection = true;
            character.GetComponent<Controllers>().isMove = false;
        }

        if (col.gameObject == stopcol.gameObject)
        {
            character.transform.SetParent(dontdestroy.transform);
            character.GetComponent<Controllers>().isMove = true;
            myparent.transform.GetComponent<REnemyScript>().anim.SetTrigger("isback");
            Destroy(gameObject);
        }
    }
}