using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class coinScript : MonoBehaviour
{
    private int gaincoin;
    private Controllers cn;
    private SpriteRenderer rp;
    private GameObject mytm;
   [SerializeField] private TextMeshProUGUI tm;

    private void Awake()
    {
        cn = GameObject.FindWithTag("Player").GetComponent<Controllers>();
        mytm = gameObject.transform.Find("Canvas").gameObject;
        rp = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("Stand"))
        {
            gaincoin = Random.Range(10, 101);
            cn.gainCoin(gaincoin);
            rp.enabled = false;
            mytm.SetActive(true);
            tm.text = "+ "+gaincoin;
            Destroy(gameObject,1);
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}