using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dontdestroy : MonoBehaviour
{
    public static dontdestroy instance;
    private Transform startobj;
    public Animator anim;
    public GameObject loadingpanel;
    private byte scenecount = 2,levelcount;
    public GameObject character;
    private Vector2 pos;

    public TextMeshProUGUI bolumtext;

    private void Awake()
    {
        control();
        StartCoroutine(yazdır());
    }

    void control()
    {
        if (scenecount != 2)
            character.transform.position = new Vector2(pos.x, pos.y);
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void nextScene()
    {
        StartCoroutine(nextscenee());
    }

    public void mydest()
    {
        Destroy(gameObject);
    }

    public IEnumerator deathScene()
    {
        SceneManager.LoadScene("DeathScene");
        control();
        yield return new WaitForSeconds(5);
        if (instance != null)
        {
            SceneManager.LoadScene("Store");
            Destroy(gameObject);
        }
    }

    void posvariable()
    {
        switch (scenecount)
        {
            case 3:
                pos = new Vector2(-10.4f, 2);
                break;
            case 4:
                pos = new Vector2(-12.8f, -28.4f);
                break;
            case 5:
                pos = new Vector2(-10.6f, 0.74f);
                break;
            case 6:
                pos = new Vector2(-51.2f, -16.4f);
                break;
        }
    }

    IEnumerator nextscenee()
    {
        scenecount++;
        loadingpanel.SetActive(true);
        yield return new WaitForSeconds(5);
        if (scenecount != 7)
        {
            SceneManager.LoadScene(scenecount);
        }
        else
        {
            SceneManager.LoadScene("Store");
            Destroy(gameObject);
        }

        posvariable();
        control();
        anim.SetTrigger("finish");
        yield return new WaitForSeconds(1);
        StartCoroutine(yazdır());
        loadingpanel.SetActive(false);
    }

    IEnumerator yazdır()
    {
        levelcount++;
        bolumtext.enabled = true;
        bolumtext.text = "Bolum: " + levelcount + " / 5";
        yield return new WaitForSeconds(3);
        bolumtext.enabled = false;
    }
}