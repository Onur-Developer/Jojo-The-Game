using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ImagesandUpgrade : MonoBehaviour
{
    [Header("Images")] public GameObject[] Images;
    [Header("Upgrades")] public GameObject[] Upgrades;
    public GameObject storePanel,ınvertoryPanel,upgradePanel;
    public TextMeshProUGUI tx;

    public Sprite[] animation;
    public Sprite[] def;

    public Button bt1;
    public Image ım1;

   [SerializeField] private soundScript ss;

    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        Invoke("close",0.05f);
    }

    public void startfunc()
    {
        ss.clicksound();
        SceneManager.LoadScene("D1");
    }

    public void quıtfunc()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            PlayerPrefs.SetInt("Coin",PlayerPrefs.GetInt("Coin")+1000);
            tx.text = PlayerPrefs.GetInt("Coin").ToString();
        }
    }

    public void buttonnext(int choıse)
    {
        ss.clicksound();
        if (bt1 != null)
        {
            bt1.interactable = true;
            switch (ım1.name)
            {
                case "Button":
                    ım1.sprite = def[0];
                    break;
                case "Button (1)":
                    ım1.sprite = def[1];
                    break;
                case "Button (2)":
                    ım1.sprite = def[2];
                    break;
            }
        }
        switch (choıse)
        {
            case 0:
                ınvertoryPanel.SetActive(true);
                storePanel.SetActive(false);
                upgradePanel.SetActive(false);
                ım1 = GameObject.Find("Button").GetComponent<Image>();
                bt1=GameObject.Find("Button").GetComponent<Button>();
                StartCoroutine(buttonanim(0));
                break;
            case 1:
                ınvertoryPanel.SetActive(false);
                storePanel.SetActive(false);
                upgradePanel.SetActive(true);
                ım1 = GameObject.Find("Button (1)").GetComponent<Image>();
                bt1=GameObject.Find("Button (1)").GetComponent<Button>();
                StartCoroutine(buttonanim(4));
                break;
            case 2:
                ınvertoryPanel.SetActive(false);
                storePanel.SetActive(true);
                upgradePanel.SetActive(false);
                ım1 = GameObject.Find("Button (2)").GetComponent<Image>();
                bt1=GameObject.Find("Button (2)").GetComponent<Button>();
                StartCoroutine(buttonanim(8));
                break;
        }
    }

    IEnumerator buttonanim(int value)
    {
        bt1.interactable = false;
        for (int i = value; i < value+4; i++)
        {
            ım1.sprite = animation[i];
            yield return new WaitForSeconds(0.2f);
        }
    }

    void close()
    {
        storePanel.SetActive(false);
    }
}
