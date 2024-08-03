using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgadeScript : MonoBehaviour
{
    private Button bt;
    public Sprite level3;
    public string myname, value1, value2, cost;
    public GameObject perksPanel, ınfopanel;
    public TextMeshProUGUI tx1, tx2, costtext;
    private writeCoinScript wc;
    [SerializeField] private soundScript ss;

    private void Awake()
    {
        bt = GetComponent<Button>();
        wc = GameObject.Find("MainPanel").GetComponent<writeCoinScript>();
    }

    private void Start()
    {
        //PlayerPrefs.DeleteKey("Az Hasar");
        //PlayerPrefs.DeleteKey("ZaWarudo");
        //PlayerPrefs.DeleteKey("BirSans");
        ınfopanel.SetActive(false);
        control();
    }

    void control()
    {
        ss.chousefunc();
        if (myname == "ZaWarudoUpgrade")
        {
            if (PlayerPrefs.GetInt("ZaWarudo", 1) == 3)
            {
                GetComponent<Image>().sprite = level3;
                bt.interactable = false;
            }
            else if (PlayerPrefs.GetInt("ZaWarudo", 1) == 2)
            {
                GetComponent<Image>().sprite = level3;
                value1 = "7.5";
                value2 = "10";
                cost = "1000";
            }
            else
            {
                value1 = "5";
                value2 = "7.5";
                cost = "500";
            }
        }
        else if (myname == "AzHasarUpgrade")
        {
            if (PlayerPrefs.GetInt("Az Hasar", 1) == 3)
            {
                GetComponent<Image>().sprite = level3;
                bt.interactable = false;
            }
            else if (PlayerPrefs.GetInt("Az Hasar", 1) == 2)
            {
                GetComponent<Image>().sprite = level3;
                value1 = "15";
                value2 = "30";
                cost = "1000";
            }
            else
            {
                value1 = "5";
                value2 = "15";
                cost = "500";
            }
        }
        else if (myname == "BirSans")
        {
            if (PlayerPrefs.GetInt("BirSans", 1) == 3)
            {
                GetComponent<Image>().sprite = level3;
                bt.interactable = false;
            }
            else if (PlayerPrefs.GetInt("BirSans", 1) == 2)
            {
                GetComponent<Image>().sprite = level3;
                value1 = "50";
                value2 = "70";
                cost = "1000";
            }
            else
            {
                value1 = "35";
                value2 = "50";
                cost = "500";
            }
        }
        else if (myname == "CanIksırı")
        {
            if (PlayerPrefs.GetInt("CanIksırı", 1) == 3)
            {
                GetComponent<Image>().sprite = level3;
                bt.interactable = false;
            }
            else if (PlayerPrefs.GetInt("CanIksırı", 1) == 2)
            {
                GetComponent<Image>().sprite = level3;
                value1 = "30";
                value2 = "40";
                cost = "1000";
            }
            else
            {
                value1 = "20";
                value2 = "30";
                cost = "500";
            }
        }
        else if (myname == "Dokunulmaz")
        {
            if (PlayerPrefs.GetInt("Dokunulmaz", 1) == 3)
            {
                GetComponent<Image>().sprite = level3;
                bt.interactable = false;
            }
            else if (PlayerPrefs.GetInt("Dokunulmaz", 1) == 2)
            {
                GetComponent<Image>().sprite = level3;
                value1 = "15";
                value2 = "20";
                cost = "1000";
            }
            else
            {
                value1 = "10";
                value2 = "15";
                cost = "500";
            }
        }
        else if (myname == "Gorunmez")
        {
            if (PlayerPrefs.GetInt("Gorunmez", 1) == 3)
            {
                GetComponent<Image>().sprite = level3;
                bt.interactable = false;
            }
            else if (PlayerPrefs.GetInt("Gorunmez", 1) == 2)
            {
                GetComponent<Image>().sprite = level3;
                value1 = "7.5";
                value2 = "10";
                cost = "1000";
            }
            else
            {
                value1 = "5";
                value2 = "7.5";
                cost = "500";
            }
        }
        else if (myname == "GucluYumruklar")
        {
            if (PlayerPrefs.GetInt("GucluYumruklar", 1) == 3)
            {
                GetComponent<Image>().sprite = level3;
                bt.interactable = false;
            }
            else if (PlayerPrefs.GetInt("GucluYumruklar", 1) == 2)
            {
                GetComponent<Image>().sprite = level3;
                value1 = "4";
                value2 = "5";
                cost = "1000";
            }
            else
            {
                value1 = "3";
                value2 = "4";
                cost = "500";
            }
        }
        else if (myname == "HızlıAltın")
        {
            if (PlayerPrefs.GetInt("HızlıAltın", 1) == 3)
            {
                GetComponent<Image>().sprite = level3;
                bt.interactable = false;
            }
            else if (PlayerPrefs.GetInt("HızlıAltın", 1) == 2)
            {
                GetComponent<Image>().sprite = level3;
                value1 = "15";
                value2 = "25";
                cost = "1000";
            }
            else
            {
                value1 = "10";
                value2 = "15";
                cost = "500";
            }
        }
        else if (myname == "HızlıYumruk")
        {
            if (PlayerPrefs.GetInt("HızlıYumruk", 1) == 3)
            {
                GetComponent<Image>().sprite = level3;
                bt.interactable = false;
            }
            else if (PlayerPrefs.GetInt("HızlıYumruk", 1) == 2)
            {
                GetComponent<Image>().sprite = level3;
                value1 = "4";
                value2 = "5";
                cost = "1000";
            }
            else
            {
                value1 = "3";
                value2 = "4";
                cost = "500";
            }
        }
        else if (myname == "HızlıUltı")
        {
            if (PlayerPrefs.GetInt("HızlıUltı", 1) == 3)
            {
                GetComponent<Image>().sprite = level3;
                bt.interactable = false;
            }
            else if (PlayerPrefs.GetInt("HızlıUltı", 1) == 2)
            {
                GetComponent<Image>().sprite = level3;
                value1 = "15";
                value2 = "25";
                cost = "1000";
            }
            else
            {
                value1 = "10";
                value2 = "15";
                cost = "500";
            }
        }
        write();
    }

    void write()
    {
        tx1.text = value1;
        tx2.text = value2;
        costtext.text = cost;
        wc.writecointx();
    }

    public void upgradePerk(int value)
    {
        switch (value)
        {
            case 1:
                if (PlayerPrefs.GetInt("ZaWarudo", 1) == 2 && PlayerPrefs.GetInt("Coin") >= 1000)
                {
                    PlayerPrefs.SetInt("Coin",PlayerPrefs.GetInt("Coin")-1000);
                    PlayerPrefs.SetInt("ZaWarudo", 3);
                    control();
                }
                else if (PlayerPrefs.GetInt("ZaWarudo", 1)==1 && PlayerPrefs.GetInt("Coin") >= 500)
                {
                    PlayerPrefs.SetInt("Coin",PlayerPrefs.GetInt("Coin")-500);
                    PlayerPrefs.SetInt("ZaWarudo", 2);
                    control();
                }

                break;
            case 2:
                if (PlayerPrefs.GetInt("Az Hasar", 1) == 2 && PlayerPrefs.GetInt("Coin") >= 1000)
                {
                    PlayerPrefs.SetInt("Coin",PlayerPrefs.GetInt("Coin")-1000);
                    PlayerPrefs.SetInt("Az Hasar", 3);
                    control();
                }
                else if (PlayerPrefs.GetInt("Az Hasar", 1) == 1 && PlayerPrefs.GetInt("Coin") >= 500)
                {
                    PlayerPrefs.SetInt("Coin",PlayerPrefs.GetInt("Coin")-500);
                    PlayerPrefs.SetInt("Az Hasar", 2);
                    control();
                }

                break;
            case 3:
                if (PlayerPrefs.GetInt("BirSans", 1) == 2 && PlayerPrefs.GetInt("Coin") >= 1000)
                {
                    PlayerPrefs.SetInt("Coin",PlayerPrefs.GetInt("Coin")-1000);
                    PlayerPrefs.SetInt("BirSans", 3);
                    control();
                }
                else if (PlayerPrefs.GetInt("BirSans", 1) == 1 && PlayerPrefs.GetInt("Coin") >= 500)
                {
                    PlayerPrefs.SetInt("Coin",PlayerPrefs.GetInt("Coin")-500);
                    PlayerPrefs.SetInt("BirSans", 2);
                    control();
                }

                break;
            case 4:
                if (PlayerPrefs.GetInt("CanIksırı", 1) == 2 && PlayerPrefs.GetInt("Coin") >= 1000)
                {
                    PlayerPrefs.SetInt("Coin",PlayerPrefs.GetInt("Coin")-1000);
                    PlayerPrefs.SetInt("CanIksırı", 3);
                    control();
                }
                else if (PlayerPrefs.GetInt("CanIksırı", 1) == 1 && PlayerPrefs.GetInt("Coin") >= 500)
                {
                    PlayerPrefs.SetInt("Coin",PlayerPrefs.GetInt("Coin")-500);
                    PlayerPrefs.SetInt("CanIksırı", 2);
                    control();
                }

                break;
            case 5:
                if (PlayerPrefs.GetInt("Dokunulmaz", 1) == 2 && PlayerPrefs.GetInt("Coin") >= 1000)
                {
                    PlayerPrefs.SetInt("Coin",PlayerPrefs.GetInt("Coin")-1000);
                    PlayerPrefs.SetInt("Dokunulmaz", 3);
                    control();
                }
                else if (PlayerPrefs.GetInt("Dokunulmaz", 1) == 1 && PlayerPrefs.GetInt("Coin") >= 500)
                {
                    PlayerPrefs.SetInt("Coin",PlayerPrefs.GetInt("Coin")-500);
                    PlayerPrefs.SetInt("Dokunulmaz", 2);
                    control();
                }

                break;
            case 6:
                if (PlayerPrefs.GetInt("Gorunmez", 1) == 2 && PlayerPrefs.GetInt("Coin") >= 1000)
                {
                    PlayerPrefs.SetInt("Coin",PlayerPrefs.GetInt("Coin")-1000);
                    PlayerPrefs.SetInt("Gorunmez", 3);
                    control();
                }
                else if (PlayerPrefs.GetInt("Gorunmez", 1) == 1 && PlayerPrefs.GetInt("Coin") >= 500)
                {
                    PlayerPrefs.SetInt("Coin",PlayerPrefs.GetInt("Coin")-500);
                    PlayerPrefs.SetInt("Gorunmez", 2);
                    control();
                }

                break;
            case 7:
                if (PlayerPrefs.GetInt("GucluYumruklar", 1) == 2 && PlayerPrefs.GetInt("Coin") >= 1000)
                {
                    PlayerPrefs.SetInt("Coin",PlayerPrefs.GetInt("Coin")-1000);
                    PlayerPrefs.SetInt("GucluYumruklar", 3);
                    control();
                }
                else if (PlayerPrefs.GetInt("GucluYumruklar", 1) == 1 && PlayerPrefs.GetInt("Coin") >= 500)
                {
                    PlayerPrefs.SetInt("Coin",PlayerPrefs.GetInt("Coin")-500);
                    PlayerPrefs.SetInt("GucluYumruklar", 2);
                    control();
                }

                break;
            case 8:
                if (PlayerPrefs.GetInt("HızlıAltın", 1) == 2 && PlayerPrefs.GetInt("Coin") >= 1000)
                {
                    PlayerPrefs.SetInt("Coin",PlayerPrefs.GetInt("Coin")-1000);
                    PlayerPrefs.SetInt("HızlıAltın", 3);
                    control();
                }
                else if (PlayerPrefs.GetInt("HızlıAltın", 1) == 1 &&PlayerPrefs.GetInt("Coin") >= 500)
                {
                    PlayerPrefs.SetInt("Coin",PlayerPrefs.GetInt("Coin")-500);
                    PlayerPrefs.SetInt("HızlıAltın", 2);
                    control();
                }

                break;
            case 9:
                if (PlayerPrefs.GetInt("HızlıYumruk", 1) == 2 && PlayerPrefs.GetInt("Coin") >= 1000)
                {
                    PlayerPrefs.SetInt("Coin",PlayerPrefs.GetInt("Coin")-1000);
                    PlayerPrefs.SetInt("HızlıYumruk", 3);
                    control();
                }
                else if (PlayerPrefs.GetInt("HızlıYumruk", 1) == 1 &&PlayerPrefs.GetInt("Coin") >= 500)
                {
                    PlayerPrefs.SetInt("Coin",PlayerPrefs.GetInt("Coin")-500);
                    PlayerPrefs.SetInt("HızlıYumruk", 2);
                    control();
                }

                break;
            case 10:
                if (PlayerPrefs.GetInt("HızlıUltı", 1) == 2 && PlayerPrefs.GetInt("Coin") >= 500)
                {
                    PlayerPrefs.SetInt("Coin",PlayerPrefs.GetInt("Coin")-500);
                    PlayerPrefs.SetInt("HızlıUltı", 3);
                    control();
                }
                else if (PlayerPrefs.GetInt("HızlıUltı", 1) == 1 && PlayerPrefs.GetInt("Coin") >= 500)
                {
                    PlayerPrefs.SetInt("Coin",PlayerPrefs.GetInt("Coin")-500);
                    PlayerPrefs.SetInt("HızlıUltı", 2);
                    control();
                }

                break;
        }
        StartCoroutine("resetperks");
    }

    IEnumerator resetperks()
    {
        perksPanel.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        perksPanel.SetActive(true);
    }

    public void onpointenter()
    {
        if (myname == "ZaWarudoUpgrade")
        {
            if (PlayerPrefs.GetInt("ZaWarudo", 1) != 3)
                ınfopanel.SetActive(true);
        }

        else if (myname == "AzHasarUpgrade")
        {
            if (PlayerPrefs.GetInt("Az Hasar", 1) != 3)
                ınfopanel.SetActive(true);
        }
        else if (myname == "BirSans")
        {
            if (PlayerPrefs.GetInt("BirSans", 1) != 3)
                ınfopanel.SetActive(true);
        }
        else if (myname == "CanIksırı")
        {
            if (PlayerPrefs.GetInt("CanIksırı", 1) != 3)
                ınfopanel.SetActive(true);
        }
        else if (myname == "Dokunulmaz")
        {
            if (PlayerPrefs.GetInt("Dokunulmaz", 1) != 3)
                ınfopanel.SetActive(true);
        }
        else if (myname == "Gorunmez")
        {
            if (PlayerPrefs.GetInt("Gorunmez", 1) != 3)
                ınfopanel.SetActive(true);
        }
        else if (myname == "GucluYumruklar")
        {
            if (PlayerPrefs.GetInt("GucluYumruklar", 1) != 3)
                ınfopanel.SetActive(true);
        }
        else if (myname == "HızlıAltın")
        {
            if (PlayerPrefs.GetInt("HızlıAltın", 1) != 3)
                ınfopanel.SetActive(true);
        }
        else if (myname == "HızlıYumruk")
        {
            if (PlayerPrefs.GetInt("HızlıYumruk", 1) != 3)
                ınfopanel.SetActive(true);
        }
        else if (myname == "HızlıUltı")
        {
            if (PlayerPrefs.GetInt("HızlıUltı", 1) != 3)
                ınfopanel.SetActive(true);
        }
    }

    public void onpointexit()
    {
        ınfopanel.SetActive(false);
    }
}