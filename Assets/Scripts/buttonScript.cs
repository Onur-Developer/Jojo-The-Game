using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttonScript : MonoBehaviour
{
   [SerializeField] private AudioSource au;
   [SerializeField] private AudioClip click, close;
    public Sprite[] myanimation;
    public Sprite[] def;
    [SerializeField] private Image ım;
    [SerializeField] private Animator anim;
    private Button bt;
    public void onclick(int deger)
    {
        au.PlayOneShot(click);
        switch (deger)
        {
            case 0:
                ım = GameObject.Find("StartButton").GetComponent<Image>();
                bt = GameObject.Find("StartButton").GetComponent<Button>();
                StartCoroutine(loadmyscene(deger));
                StartCoroutine(buttonanimation(0));
                break;
            case 1:
                ım = GameObject.Find("ControllerButton").GetComponent<Image>();
                bt = GameObject.Find("ControllerButton").GetComponent<Button>();
                anim.SetBool("isopen", true);
                StartCoroutine(buttonanimation(4));
                break;
            case 2:
                StartCoroutine(loadmyscene(deger));
                ım = GameObject.Find("ExitButton").GetComponent<Image>();
                bt = GameObject.Find("ExitButton").GetComponent<Button>();
                StartCoroutine(buttonanimation(8));
                break;
            case 3:
                PlayerPrefs.DeleteAll();
                SceneManager.LoadScene("Menu");
               break; 
        }
    }

    IEnumerator loadmyscene(int value2)
    {
        yield return new WaitForSeconds(3);
        switch (value2)
        {
            case 0:
                SceneManager.LoadScene("Store");
                break;
            case 2:
               Application.Quit();
                break;
        }
    }

    IEnumerator buttonanimation(int value)
    {
        bt.interactable = false;
        for (int i = value; i < value + 4; i++)
        {
            ım.sprite = myanimation[i];
            yield return new WaitForSeconds(0.2f);
        }
    }

    public void back(int value)
    {
        au.PlayOneShot(close);
        bt.interactable = true;
        switch (value)
        {
            case 1:
                anim.SetBool("isopen", false);
                ım.sprite = def[1];
                break;
            case 2:
                ım.sprite = def[2];
                break;
        }
    }
}