using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class kod : MonoBehaviour
{
    public Text high;
    private bool seskontrol;
    private AudioSource au;
    public float zaman;
    public GameObject gm;
    private Transform tm;
    public GameObject ab;
    public GameObject nokta, m;

    private void Start()
    {
        au = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 position = Input.mousePosition;
            position = Camera.main.ScreenToWorldPoint(position);
           nokta = Instantiate(gm, position, quaternion.identity);
            m = Instantiate(ab, transform.position,quaternion.identity);
            m.GetComponent<takip>().degerler(nokta.transform);
        }

        zaman = Time.time;
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(x, y) * Time.deltaTime * 5f;

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            if (!seskontrol)
            {
                au.Play();
                seskontrol = true;
            }
        }
        else
        {
            if (seskontrol)
            {
                au.Stop();
                seskontrol = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            yazdır();
            Time.timeScale = 0;
        }
    }

    void yazdır()
    {
        if (PlayerPrefs.GetFloat("Highscore") > zaman)
        {
            PlayerPrefs.SetFloat("Highscore", zaman);
            Debug.Log("girildi");
        }

        else if (PlayerPrefs.GetFloat("Highscore") == 0)
        {
            PlayerPrefs.SetFloat("Highscore", zaman);
        }

        high.text = PlayerPrefs.GetFloat("Highscore").ToString();
    }
}