using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameMenuScript : MonoBehaviour
{
    public Slider soundslider,soundslider2;
    public Image pausebackground;
    private float backvalue;
    public GameObject pausepanel;
    public AudioSource au, au2, au3;
    public Button pausebutton;
    public dontdestroy ds;
    public Controllers cn;


    public void stopthegame()
    {
        pausebutton.interactable = false;
        Time.timeScale = 0;
        StartCoroutine(pausebackgroundeffect());
    }

    public void backthegamebutton()
    {
        pausebutton.interactable = true;
        Time.timeScale = 1;
        pausepanel.SetActive(false);
        StartCoroutine(backthegame());
    }

    public void backmaınmenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        ds.mydest();
    }

    public void exitthegame()
    {
        Application.Quit();
    }

    public void soundsetting()
    {
        au.volume = soundslider.value;
        //au2.volume = soundslider.value;
    }

    public void soundsetting2()
    {
        au3.volume = soundslider2.value;
    }

    IEnumerator pausebackgroundeffect()
    {
        yield return new WaitForSecondsRealtime(0.05f);
        backvalue += 0.1f;
        pausebackground.color = new Color(0, 0, 0, backvalue);
        if (backvalue < 0.9f)
            StartCoroutine(pausebackgroundeffect());
        else
            pausepanel.SetActive(true);
    }

    IEnumerator backthegame()
    {
        yield return new WaitForSecondsRealtime(0.05f);
        backvalue -= 0.1f;
        pausebackground.color = new Color(0, 0, 0, backvalue);
        if (backvalue >= 0)
            StartCoroutine(backthegame());
    }
}