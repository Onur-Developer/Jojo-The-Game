using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class PerksScript : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public bool isActive;
    private Transform mynewpos;
    public Sprite level1, level2, level3;
    public string myname,defaultstringvalue;
    public Transform[] slots;
    private GameObject ınformationPanel;
    private TextMeshProUGUI perkNameText, perkInfoText;
    public Transform ınventory, canvas;
    public soundScript ss;

    [Multiline(10)] public String perkName, perkInfo;

    void amIstillChoise()
    {
        if (myname == "ZaWarudo")
        {
            switch (PlayerPrefs.GetInt("SlotPosition", -1))
            {
                case -1:
                    transform.SetParent(ınventory);
                    PlayerPrefs.SetInt("SlotPosition", -1);
                    break;
                case 0:
                    transform.SetParent(slots[0]);
                    break;
                case 1:
                    transform.SetParent(slots[1]);
                    break;
                case 2:
                    transform.SetParent(slots[2]);
                    break;
                case 3:
                    transform.SetParent(slots[3]);
                    break;
            }

            transform.localPosition = Vector2.zero;
        }
        else if (myname == "Az Hasar")
        {
            switch (PlayerPrefs.GetInt("SlotPosition2", -1))
            {
                case -1:
                    transform.SetParent(ınventory);
                    PlayerPrefs.SetInt("SlotPosition2", -1);
                    break;
                case 0:
                    transform.SetParent(slots[0]);
                    break;
                case 1:
                    transform.SetParent(slots[1]);
                    break;
                case 2:
                    transform.SetParent(slots[2]);
                    break;
                case 3:
                    transform.SetParent(slots[3]);
                    break;
            }

            transform.localPosition = Vector2.zero;
        }
        else if (myname == "BirSans")
        {
            switch (PlayerPrefs.GetInt("SlotPosition3", -1))
            {
                case -1:
                    transform.SetParent(ınventory);
                    PlayerPrefs.SetInt("SlotPosition3", -1);
                    break;
                case 0:
                    transform.SetParent(slots[0]);
                    break;
                case 1:
                    transform.SetParent(slots[1]);
                    break;
                case 2:
                    transform.SetParent(slots[2]);
                    break;
                case 3:
                    transform.SetParent(slots[3]);
                    break;
            }

            transform.localPosition = Vector2.zero;
        }

        else if (myname == "CanIksırı")
        {
            switch (PlayerPrefs.GetInt("SlotPosition4", -1))
            {
                case -1:
                    transform.SetParent(ınventory);
                    PlayerPrefs.SetInt("SlotPosition4", -1);
                    break;
                case 0:
                    transform.SetParent(slots[0]);
                    break;
                case 1:
                    transform.SetParent(slots[1]);
                    break;
                case 2:
                    transform.SetParent(slots[2]);
                    break;
                case 3:
                    transform.SetParent(slots[3]);
                    break;
            }

            transform.localPosition = Vector2.zero;
        }
        else if (myname == "Dokunulmaz")
        {
            switch (PlayerPrefs.GetInt("SlotPosition5", -1))
            {
                case -1:
                    transform.SetParent(ınventory);
                    PlayerPrefs.SetInt("SlotPosition5", -1);
                    break;
                case 0:
                    transform.SetParent(slots[0]);
                    break;
                case 1:
                    transform.SetParent(slots[1]);
                    break;
                case 2:
                    transform.SetParent(slots[2]);
                    break;
                case 3:
                    transform.SetParent(slots[3]);
                    break;
            }

            transform.localPosition = Vector2.zero;
        }
        else if (myname == "Gorunmez")
        {
            switch (PlayerPrefs.GetInt("SlotPosition6", -1))
            {
                case -1:
                    transform.SetParent(ınventory);
                    PlayerPrefs.SetInt("SlotPosition6", -1);
                    break;
                case 0:
                    transform.SetParent(slots[0]);
                    break;
                case 1:
                    transform.SetParent(slots[1]);
                    break;
                case 2:
                    transform.SetParent(slots[2]);
                    break;
                case 3:
                    transform.SetParent(slots[3]);
                    break;
            }

            transform.localPosition = Vector2.zero;
        }
        else if (myname == "GucluYumruklar")
        {
            switch (PlayerPrefs.GetInt("SlotPosition7", -1))
            {
                case -1:
                    transform.SetParent(ınventory);
                    PlayerPrefs.SetInt("SlotPosition7", -1);
                    break;
                case 0:
                    transform.SetParent(slots[0]);
                    break;
                case 1:
                    transform.SetParent(slots[1]);
                    break;
                case 2:
                    transform.SetParent(slots[2]);
                    break;
                case 3:
                    transform.SetParent(slots[3]);
                    break;
            }

            transform.localPosition = Vector2.zero;
        }
        else if (myname == "HızlıAltın")
        {
            switch (PlayerPrefs.GetInt("SlotPosition8", -1))
            {
                case -1:
                    transform.SetParent(ınventory);
                    PlayerPrefs.SetInt("SlotPosition8", -1);
                    break;
                case 0:
                    transform.SetParent(slots[0]);
                    break;
                case 1:
                    transform.SetParent(slots[1]);
                    break;
                case 2:
                    transform.SetParent(slots[2]);
                    break;
                case 3:
                    transform.SetParent(slots[3]);
                    break;
            }

            transform.localPosition = Vector2.zero;
        }
        else if (myname == "HızlıYumruk")
        {
            switch (PlayerPrefs.GetInt("SlotPosition9", -1))
            {
                case -1:
                    transform.SetParent(ınventory);
                    PlayerPrefs.SetInt("SlotPosition9", -1);
                    break;
                case 0:
                    transform.SetParent(slots[0]);
                    break;
                case 1:
                    transform.SetParent(slots[1]);
                    break;
                case 2:
                    transform.SetParent(slots[2]);
                    break;
                case 3:
                    transform.SetParent(slots[3]);
                    break;
            }

            transform.localPosition = Vector2.zero;
        }
        else if (myname == "HızlıUltı")
        {
            switch (PlayerPrefs.GetInt("SlotPosition10", -1))
            {
                case -1:
                    transform.SetParent(ınventory);
                    PlayerPrefs.SetInt("SlotPosition10", -1);
                    break;
                case 0:
                    transform.SetParent(slots[0]);
                    break;
                case 1:
                    transform.SetParent(slots[1]);
                    break;
                case 2:
                    transform.SetParent(slots[2]);
                    break;
                case 3:
                    transform.SetParent(slots[3]);
                    break;
            }

            transform.localPosition = Vector2.zero;
        }
    }

    void whoLevel()
    {
        perkInfo = defaultstringvalue;
        if (myname == "ZaWarudo")
        {
            switch (PlayerPrefs.GetInt("ZaWarudo", 1))
            {
                case 2:
                    GetComponent<Image>().sprite = level2;
                    perkInfo = perkInfo.Replace("&value", "7.5");
                    break;
                case 3:
                    GetComponent<Image>().sprite = level3;
                    perkInfo = perkInfo.Replace("&value", "10");
                    break;
                default:
                    GetComponent<Image>().sprite = level1;
                    perkInfo = perkInfo.Replace("&value", "5");
                    break;
            }
        }
        else if (myname == "Az Hasar")
        {
            switch (PlayerPrefs.GetInt("Az Hasar", 1))
            {
                case 2:
                    GetComponent<Image>().sprite = level2;
                    perkInfo = perkInfo.Replace("&value", "15");
                    break;
                case 3:
                    GetComponent<Image>().sprite = level3;
                    perkInfo = perkInfo.Replace("&value", "30");
                    break;
                default:
                    GetComponent<Image>().sprite = level1;
                    perkInfo = perkInfo.Replace("&value", "5");
                    break;
            }
        }
        else if (myname == "BirSans")
        {
            switch (PlayerPrefs.GetInt("BirSans", 1))
            {
                case 2:
                    GetComponent<Image>().sprite = level2;
                    perkInfo = perkInfo.Replace("&value", "50");
                    break;
                case 3:
                    GetComponent<Image>().sprite = level3;
                    perkInfo = perkInfo.Replace("&value", "70");
                    break;
                default:
                    GetComponent<Image>().sprite = level1;
                    perkInfo = perkInfo.Replace("&value", "35");
                    break;
            }
        }
        else if (myname == "CanIksırı")
        {
            switch (PlayerPrefs.GetInt("CanIksırı", 1))
            {
                case 2:
                    GetComponent<Image>().sprite = level2;
                    perkInfo = perkInfo.Replace("&value", "30");
                    break;
                case 3:
                    GetComponent<Image>().sprite = level3;
                    perkInfo = perkInfo.Replace("&value", "40");
                    break;
                default:
                    GetComponent<Image>().sprite = level1;
                    perkInfo = perkInfo.Replace("&value", "20");
                    break;
            }
        }
        else if (myname == "Dokunulmaz")
        {
            switch (PlayerPrefs.GetInt("Dokunulmaz", 1))
            {
                case 2:
                    GetComponent<Image>().sprite = level2;
                    perkInfo = perkInfo.Replace("&value", "15");
                    break;
                case 3:
                    GetComponent<Image>().sprite = level3;
                    perkInfo = perkInfo.Replace("&value", "20");
                    break;
                default:
                    GetComponent<Image>().sprite = level1;
                    perkInfo = perkInfo.Replace("&value", "10");
                    break;
            }
        }
        else if (myname == "Gorunmez")
        {
            switch (PlayerPrefs.GetInt("Gorunmez", 1))
            {
                case 2:
                    GetComponent<Image>().sprite = level2;
                    perkInfo = perkInfo.Replace("&value", "7.5");
                    break;
                case 3:
                    GetComponent<Image>().sprite = level3;
                    perkInfo = perkInfo.Replace("&value", "10");
                    break;
                default:
                    GetComponent<Image>().sprite = level1;
                    perkInfo = perkInfo.Replace("&value", "5");
                    break;
            }
        }
        else if (myname == "GucluYumruklar")
        {
            switch (PlayerPrefs.GetInt("GucluYumruklar", 1))
            {
                case 2:
                    GetComponent<Image>().sprite = level2;
                    perkInfo = perkInfo.Replace("&value", "4");
                    break;
                case 3:
                    GetComponent<Image>().sprite = level3;
                    perkInfo = perkInfo.Replace("&value", "5");
                    break;
                default:
                    GetComponent<Image>().sprite = level1;
                    perkInfo = perkInfo.Replace("&value", "3");
                    break;
            }
        }
        else if (myname == "HızlıAltın")
        {
            switch (PlayerPrefs.GetInt("HızlıAltın", 1))
            {
                case 2:
                    GetComponent<Image>().sprite = level2;
                    perkInfo = perkInfo.Replace("&value", "15");
                    break;
                case 3:
                    GetComponent<Image>().sprite = level3;
                    perkInfo = perkInfo.Replace("&value", "25");
                    break;
                default:
                    GetComponent<Image>().sprite = level1;
                    perkInfo = perkInfo.Replace("&value", "10");
                    break;
            }
        }
        else if (myname == "HızlıYumruk")
        {
            switch (PlayerPrefs.GetInt("HızlıYumruk", 1))
            {
                case 2:
                    GetComponent<Image>().sprite = level2;
                    perkInfo = perkInfo.Replace("&value", "4");
                    break;
                case 3:
                    GetComponent<Image>().sprite = level3;
                    perkInfo = perkInfo.Replace("&value", "5");
                    break;
                default:
                    GetComponent<Image>().sprite = level1;
                    perkInfo = perkInfo.Replace("&value", "3");
                    break;
            }
        }
        else if (myname == "HızlıUltı")
        {
            switch (PlayerPrefs.GetInt("HızlıUltı", 1))
            {
                case 2:
                    GetComponent<Image>().sprite = level2;
                    perkInfo = perkInfo.Replace("&value", "15");
                    break;
                case 3:
                    GetComponent<Image>().sprite = level3;
                    perkInfo = perkInfo.Replace("&value", "25");
                    break;
                default:
                    GetComponent<Image>().sprite = level1;
                    perkInfo = perkInfo.Replace("&value", "10");
                    break;
            }
        }

        perkInfoText.text = perkInfo;
        perkNameText.text = perkName;
    }

    private void Awake()
    {
        ınformationPanel = transform.Find("PerksInformation").gameObject;
        perkNameText = ınformationPanel.transform.Find("PerksName").transform.Find("NameText")
            .GetComponent<TextMeshProUGUI>();
        perkInfoText = ınformationPanel.transform.Find("PerksInform").transform.Find("InfoText")
            .GetComponent<TextMeshProUGUI>();
        defaultstringvalue = perkInfo;
        amIstillChoise();
        whoLevel();
    }

    private void Start()
    {
        ınformationPanel.SetActive(false);
        Invoke("controlps", 0.1f);
    }
    private void OnEnable()
    {
        whoLevel();
    }

    void controlps()
    {
        // transform.SetParent(canvas);
        GetComponent<BoxCollider2D>().isTrigger = true;
    }


    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        ınformationPanel.SetActive(false);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ss.dowmfunc();
        makeYourChoıse();
    }

    public void takeValue(Transform pos)
    {
        mynewpos = pos;
    }

    void makeYourChoıse()
    {
        if (isActive)
        {
            transform.SetParent(mynewpos);
            transform.localPosition = Vector2.zero;
           // transform.SetParent(canvas);
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].position == mynewpos.position)
                {
                    if (myname == "ZaWarudo")
                        PlayerPrefs.SetInt("SlotPosition", i);
                    else if (myname == "Az Hasar")
                        PlayerPrefs.SetInt("SlotPosition2", i);
                    else if (myname == "BirSans")
                        PlayerPrefs.SetInt("SlotPosition3", i);
                    else if (myname == "CanIksırı")
                        PlayerPrefs.SetInt("SlotPosition4", i);
                    else if (myname == "Dokunulmaz")
                        PlayerPrefs.SetInt("SlotPosition5", i);
                    else if (myname == "Gorunmez")
                        PlayerPrefs.SetInt("SlotPosition6", i);
                    else if (myname == "GucluYumruklar")
                        PlayerPrefs.SetInt("SlotPosition7", i);
                    else if (myname == "HızlıAltın")
                        PlayerPrefs.SetInt("SlotPosition8", i);
                    else if (myname == "HızlıYumruk")
                        PlayerPrefs.SetInt("SlotPosition9", i);
                    else if (myname == "HızlıUltı")
                        PlayerPrefs.SetInt("SlotPosition10", i);
                }
            }
        }
        else
        {
            if (myname == "ZaWarudo")
            {
                PlayerPrefs.SetInt("SlotPosition", -1);
                transform.SetParent(null);
                transform.SetParent(ınventory);
            }

            else if (myname == "Az Hasar")
            {
                PlayerPrefs.SetInt("SlotPosition2", -1);
                transform.SetParent(null);
                transform.SetParent(ınventory);
            }
            else if (myname == "BirSans")
            {
                PlayerPrefs.SetInt("SlotPosition3", -1);
                transform.SetParent(null);
                transform.SetParent(ınventory);
            }
            else if (myname == "CanIksırı")
            {
                PlayerPrefs.SetInt("SlotPosition4", -1);
                transform.SetParent(null);
                transform.SetParent(ınventory);
            }
            else if (myname == "Dokunulmaz")
            {
                PlayerPrefs.SetInt("SlotPosition5", -1);
                transform.SetParent(null);
                transform.SetParent(ınventory);
            }
            else if (myname == "Gorunmez")
            {
                PlayerPrefs.SetInt("SlotPosition6", -1);
                transform.SetParent(null);
                transform.SetParent(ınventory);
            }
            else if (myname == "GucluYumruklar")
            {
                PlayerPrefs.SetInt("SlotPosition7", -1);
                transform.SetParent(null);
                transform.SetParent(ınventory);
            }
            else if (myname == "HızlıAltın")
            {
                PlayerPrefs.SetInt("SlotPosition8", -1);
                transform.SetParent(null);
                transform.SetParent(ınventory);
            }
            else if (myname == "HızlıYumruk")
            {
                PlayerPrefs.SetInt("SlotPosition9", -1);
                transform.SetParent(null);
                transform.SetParent(ınventory);
            }
            else if (myname == "HızlıUltı")
            {
                PlayerPrefs.SetInt("SlotPosition10", -1);
                transform.SetParent(null);
                transform.SetParent(ınventory);
            }
        }
    }

    public void onclick()
    {
        ınformationPanel.SetActive(true);
    }

    public void outclick()
    {
        ınformationPanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Perks"))
        {
            col.transform.SetParent(ınventory);
            if (col.name == "ZaWarudoPerk")
            {
                PlayerPrefs.SetInt("SlotPosition", -1);
            }

            else if (col.name == "LessDamagePerk")
            {
                PlayerPrefs.SetInt("SlotPosition2", -1);
            }
            else if (col.name == "OneMoreChance")
            {
                PlayerPrefs.SetInt("SlotPosition3", -1);
            }
            else if (col.name == "HealtPosion")
            {
                PlayerPrefs.SetInt("SlotPosition4", -1);
            }
            else if (col.name == "Dokunulmaz")
            {
                PlayerPrefs.SetInt("SlotPosition5", -1);
            }
            else if (col.name == "Gorunmez")
            {
                PlayerPrefs.SetInt("SlotPosition6", -1);
            }
            else if (col.name == "GucluYumruklar")
            {
                PlayerPrefs.SetInt("SlotPosition7", -1);
            }
            else if (col.name == "HızlıAltın")
            {
                PlayerPrefs.SetInt("SlotPosition8", -1);
            }
            else if (col.name == "HızlıYumruk")
            {
                PlayerPrefs.SetInt("SlotPosition9", -1);
            }
            else if (col.name == "HızlıUltı")
            {
                PlayerPrefs.SetInt("SlotPosition10", -1);
            }
        }
    }
}