using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Enemys : MonoBehaviour
{
    public static bool isUlti;
    private byte mybyte = 0;
    public float maxHeart, heart;
    private Rigidbody2D rb;
    private Animator anim;
    private bool isdeath;
    private Vector2 endlook;
    private float healtbarcooldown;
    private BoxCollider2D bc;
    public GameObject coin;

    [Header("UI Elements")] [SerializeField]
    private Image heartBarBackground;

    [SerializeField] private Image heartBar;
    [SerializeField] private talentManager tl;
    [SerializeField] private Controllers cn;

    private void Awake()
    {
        tl = GameObject.FindWithTag("Player").GetComponent<talentManager>();
        cn = GameObject.FindWithTag("Player").GetComponent<Controllers>();
        if (gameObject.tag == "Enemy")
        {
            heart = maxHeart;
        }

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        if (gameObject.tag == "Enemy")
        {
            heartBarBackground.enabled = false;
            heartBar.enabled = false;
        }
    }


    private void Update()
    {
        if (isUlti && mybyte == 0)
            ultiOpen();

        if (gameObject.tag == "Enemy")
        {
            if (heartBar.enabled)
            {
                healtbarcooldown += Time.deltaTime;
                if (healtbarcooldown >= 2)
                {
                    heartBar.enabled = false;
                    heartBarBackground.enabled = false;
                    healtbarcooldown = 0;
                }
            }

            if (transform.localScale.x == 1)
            {
                heartBar.fillOrigin = 0;
            }
            else
            {
                heartBar.fillOrigin = 1;
            }
        }
    }

    public void TakeDamage(float damage, Vector2 look)
    {
        endlook = look;
        heart -= damage;
        rb.AddForce(look * 10, ForceMode2D.Impulse);
        if (heart <= 0 && !isUlti && !isdeath)
        {
            heartBar.fillAmount = 0;
            isdeath = true;
            gameObject.SendMessage("isDeath");
            transform.localScale = new Vector2((endlook.x * -1), 1);
            anim.SetTrigger("isDeath");
            anim.SetBool("isDeathb", true);
            rb.AddForce(look * 60, ForceMode2D.Impulse);
            Destroy(gameObject, 2);
            Instantiate(coin, transform.position, quaternion.identity);
           cn.ewww();
        }

        else if (damage != 0 && !isdeath)
        {
            heartBarBackground.enabled = true;
            heartBar.enabled = true;
            heartBar.fillAmount = Mathf.InverseLerp(0, maxHeart, heart);
            anim.SetTrigger("isHit");
            rb.AddForce(look * 0.5f, ForceMode2D.Impulse);
        }
    }

    public void ultiOpen()
    {
        if (gameObject.tag == "Enemy")
            bc.isTrigger = false;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        mybyte = 1;
        gameObject.SendMessage("UltiOpen");
        if (!cn.ismyulti)
            Invoke("ultiEnd", tl.zaWarudoTimer);
        else
            Invoke("ultiEnd", 15);
    }

    public void ultiEnd()
    {
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        isUlti = false;
        mybyte = 0;
        gameObject.SendMessage("UltiEnd");
        anim.enabled = true;
        if (gameObject.tag == "Enemy")
            TakeDamage(0, endlook);
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            bc.isTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (gameObject.tag == "Enemy")
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                bc.isTrigger = false;
            }
        }
    }
}