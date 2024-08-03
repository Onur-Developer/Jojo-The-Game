using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controllers2 : MonoBehaviour
{
    public static Controllers2 instance;
    public Transform Character;
    public Rigidbody2D rb;
    public Animator anim;
    private float movementX, movementY;
    private float speed = 300;
    public Controllers ct;
    public bool isAttacking;
    public LineRenderer line;
    [SerializeField] private Texture2D[] textures;
    private byte lineanim;

    private void Awake()
    {
        lineanim = 0;
        instance = this;
        StartCoroutine("lineAnim");
    }

    public void onDinamic()
    {
        transform.parent = null;
        rb.bodyType = RigidbodyType2D.Dynamic;
        anim.enabled = true;
        anim.Play("StandComing");
    }

    public void Attack()
    {
        if (Input.GetButtonDown("Fire1") && !isAttacking)
        {
            isAttacking = true;
        }
    }

    private void FixedUpdate()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        movementY = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(movementX * speed, movementY * speed) * Time.deltaTime;
    }

    void closeAnim()
    {
        ct.enabled = true;
        ct.onDinamic();
        ct.rb.velocity = Vector2.zero;
        anim.enabled = false;
        transform.gameObject.GetComponent<SpriteRenderer>().sprite = null;
    }

    private void Update()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("StandComing"))
        {
            line.SetPosition(0, Character.position);
            line.SetPosition(1, transform.position);
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            ct.standgo();
            rb.velocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Kinematic;
            transform.parent = Character;
            anim.Play("StandOut");
            Invoke("closeAnim", 0.6f);
            line.enabled = false;
            ct.changeFace(true);
            enabled = false;
        }

        if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }

        Attack();
    }

    public void lineAnim()
    {
        if (lineanim == 4)
            lineanim = 0;
        else
            lineanim++;
        line.material.SetTexture("_MainTex", textures[lineanim]);

        if (line.enabled)
            Invoke("lineAnim", .15f);
    }
}