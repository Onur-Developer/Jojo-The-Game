using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StoreScript : MonoBehaviour
{
    public ImagesandUpgrade ıu;
    public string myName;
    public GameObject InfoPanel;

    private writeCoinScript wc;
    private TextMeshProUGUI costtext;

    [SerializeField] private soundScript ss;

    private void Awake()
    {
        costtext = transform.GetChild(0).transform.GetChild(2).GetComponentInChildren<TextMeshProUGUI>();
        wc = GameObject.Find("MainPanel").GetComponent<writeCoinScript>();
        control();
    }

    private void Start()
    {
        costtext.text = "1000";
        InfoPanel.SetActive(false);
    }


    void control()
    {
        switch (myName)
        {
            case "LessDamage":
                if (PlayerPrefs.GetString("LessDamageActive", "false") == "true")
                {
                    ıu.Images[0].SetActive(true);
                    ıu.Upgrades[0].SetActive(true);
                    gameObject.SetActive(false);
                }
                else
                    PlayerPrefs.SetInt("SlotPosition2", -1);

                break;
            case "OneMoreChange":
                if (PlayerPrefs.GetString("OneMoreChangeActive", "false") == "true")
                {
                    ıu.Images[1].SetActive(true);
                    ıu.Upgrades[1].SetActive(true);
                    gameObject.SetActive(false);
                }
                else
                    PlayerPrefs.SetInt("SlotPosition3", -1);

                break;
            case "HealtPosion":
                if (PlayerPrefs.GetString("HealtPosionActive", "false") == "true")
                {
                    ıu.Images[2].SetActive(true);
                    ıu.Upgrades[2].SetActive(true);
                    gameObject.SetActive(false);
                }
                else
                    PlayerPrefs.SetInt("SlotPosition4", -1);
                break;
            case "Dokunulmaz":
                if (PlayerPrefs.GetString("DokunulmazActive", "false") == "true")
                {
                    ıu.Images[3].SetActive(true);
                    ıu.Upgrades[3].SetActive(true);
                    gameObject.SetActive(false);
                }
                else
                    PlayerPrefs.SetInt("SlotPosition5", -1);
                break;
            case "Gorunmez":
                if (PlayerPrefs.GetString("GorunmezActive", "false") == "true")
                {
                    ıu.Images[4].SetActive(true);
                    ıu.Upgrades[4].SetActive(true);
                    gameObject.SetActive(false);
                }
                else
                    PlayerPrefs.SetInt("SlotPosition6", -1);
                break;
            case "GucluYumruklar":
                if (PlayerPrefs.GetString("GucluYumruklarActive", "false") == "true")
                {
                    ıu.Images[5].SetActive(true);
                    ıu.Upgrades[5].SetActive(true);
                    gameObject.SetActive(false);
                }
                else
                    PlayerPrefs.SetInt("SlotPosition7", -1);
                break;
            case "HızlıAltın":
                if (PlayerPrefs.GetString("HızlıAltınActive", "false") == "true")
                {
                    ıu.Images[6].SetActive(true);
                    ıu.Upgrades[6].SetActive(true);
                    gameObject.SetActive(false);
                }
                else
                    PlayerPrefs.SetInt("SlotPosition8", -1);
                break;
            case "HızlıYumruk":
                if (PlayerPrefs.GetString("HızlıYumrukActive", "false") == "true")
                {
                    ıu.Images[7].SetActive(true);
                    ıu.Upgrades[7].SetActive(true);
                    gameObject.SetActive(false);
                }
                else
                    PlayerPrefs.SetInt("SlotPosition9", -1);
                break;
            case "HızlıUlti":
                if (PlayerPrefs.GetString("HızlıUltiActive", "false") == "true")
                {
                    ıu.Images[8].SetActive(true);
                    ıu.Upgrades[8].SetActive(true);
                    gameObject.SetActive(false);
                }
                else
                    PlayerPrefs.SetInt("SlotPosition10", -1);
                break;
        }
    }

    public void onButton(int layer)
    {
        if (PlayerPrefs.GetInt("Coin") >= 1000)
        {
            ss.chousefunc();
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") - 1000);
            wc.writecointx();
            switch (layer)
            {
                case 0:
                    ıu.Images[layer].SetActive(true);
                    ıu.Upgrades[layer].SetActive(true);
                    gameObject.SetActive(false);
                    PlayerPrefs.SetString("LessDamageActive", "true");
                    break;
                case 1:
                    ıu.Images[layer].SetActive(true);
                    ıu.Upgrades[layer].SetActive(true);
                    gameObject.SetActive(false);
                    PlayerPrefs.SetString("OneMoreChangeActive", "true");
                    break;
                case 2:
                    ıu.Images[layer].SetActive(true);
                    ıu.Upgrades[layer].SetActive(true);
                    gameObject.SetActive(false);
                    PlayerPrefs.SetString("HealtPosionActive", "true");
                    break;
                case 3:
                    ıu.Images[layer].SetActive(true);
                    ıu.Upgrades[layer].SetActive(true);
                    gameObject.SetActive(false);
                    PlayerPrefs.SetString("DokunulmazActive", "true");
                    break;
                case 4:
                    ıu.Images[layer].SetActive(true);
                    ıu.Upgrades[layer].SetActive(true);
                    gameObject.SetActive(false);
                    PlayerPrefs.SetString("GorunmezActive", "true");
                    break;
                case 5:
                    ıu.Images[layer].SetActive(true);
                    ıu.Upgrades[layer].SetActive(true);
                    gameObject.SetActive(false);
                    PlayerPrefs.SetString("GucluYumruklarActive", "true");
                    break;
                case 6:
                    ıu.Images[layer].SetActive(true);
                    ıu.Upgrades[layer].SetActive(true);
                    gameObject.SetActive(false);
                    PlayerPrefs.SetString("HızlıAltınActive", "true");
                    break;
                case 7:
                    ıu.Images[layer].SetActive(true);
                    ıu.Upgrades[layer].SetActive(true);
                    gameObject.SetActive(false);
                    PlayerPrefs.SetString("HızlıYumrukActive", "true");
                    break;
                case 8:
                    ıu.Images[layer].SetActive(true);
                    ıu.Upgrades[layer].SetActive(true);
                    gameObject.SetActive(false);
                    PlayerPrefs.SetString("HızlıUltiActive", "true");
                    break;
            }
        }
    }

    public void onEnter()
    {
        InfoPanel.SetActive(true);
    }

    public void onExit()
    {
        InfoPanel.SetActive(false);
    }
}