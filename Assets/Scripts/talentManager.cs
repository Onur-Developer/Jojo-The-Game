using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class talentManager : MonoBehaviour
{
    [Header("Güçlü Yumruklar")] public GameObject gucluyumrukobj;
    private GameObject gucluyumrukobj2;
    public float hasarıartır, hasarıartırstack;
    private TextMeshProUGUI hasarartırstacktext;
    public Sprite gucluyumruk2, gucluyumruk3;
    
    [Header("Hızlı Yumruklar")] private GameObject hızlıyumrukobj;
    public GameObject hızlıyumrukımage;
    public float saldırıhızıartır, saldırıhızıstack;
    private TextMeshProUGUI saldırıhızıstacktext;
    public Sprite hızlıyumruk2, hızlıyumruk3;

    [Header("Za Warudo")] public GameObject talentPanel, zaWarudoImage, ınstaza;
    public bool zaWarudo, zaWarudoCount, zaWarudocooldown;
    public float zaWarudoTimer, zaWarudoTimer2, cooldowntimer;
    public Image zaWarudofill;
    public Sprite ZaWarudoSprite2, ZaWarudoSprite3;

    [Header("HızlıAltın")] private GameObject quickcoinobj;
    [Header("HızlıAltın")] public GameObject quickcoinımage;
    [Header("HızlıAltın")] private TextMeshProUGUI quickcointext;
    [Header("HızlıAltın")] public int quickmoney, toplamquickmoney;
    [Header("HızlıAltın")] public Sprite quickmoney2, quickmoney3;

    [Header("AzHasar")] public GameObject azhasarobj;
    public float lessdamage;
    public Sprite azhasar2, azhasar3;
    private GameObject azhasarobj2;

    [Header("BırŞansDaha")] public bool onemore;
    public GameObject bırsansobj;
    public GameObject bırsansobj2;
    public Sprite bırsans2, bırsans3;
    public float yenıdencanlanmamıktarı;

    [Header("Can İksiri")] public GameObject canobj, canobj2;
    public Sprite cansprite2, cansprite3;
    public float canartır;

    [Header("Dokunulmaz")] public GameObject dokunulmazobj;
    public GameObject dokunulmazobj2;
    public Sprite dokunulmazsprite2, dokunulmazsprite3;
    public float dokunulmaztime,dokunulmaztimerr;
    public bool isdokunulmaz;
    private Image dokunulmazımage;

    [Header("Görünmez")] public GameObject gorunmezobj;
    public GameObject gorunmezobj2;
    public Sprite gorunmezsprite2, gorunmezsprite3;
    public float gorunmeztime,gorunmezgerisayım;
    public bool isgorunmez;
    private Image gorunmezImage;
    public SpriteRenderer sr;

    [Header("Hızlı Ulti")] public GameObject hızlıultiobj;
    private GameObject hızlıultiobj2;
    public Sprite hızlıulti2, hızlıulti3;
    public float ultıartısoranı;


    private void Awake()
    {
        if (PlayerPrefs.GetInt("SlotPosition") != -1)
        {
            ınstaza = Instantiate(zaWarudoImage, talentPanel.transform);
            zaWarudo = true;
            zaWarudofill = ınstaza.transform.GetChild(0).gameObject.GetComponent<Image>();
            zaWarudofill.fillAmount = 0;
            switch (PlayerPrefs.GetInt("ZaWarudo", 1))
            {
                case 1:
                    zaWarudoTimer = 5;
                    break;
                case 2:
                    zaWarudoTimer = 7.5f;
                    ınstaza.GetComponent<Image>().sprite = ZaWarudoSprite2;
                    break;
                case 3:
                    zaWarudoTimer = 10;
                    ınstaza.GetComponent<Image>().sprite = ZaWarudoSprite3;
                    break;
            }

            zaWarudoTimer2 = zaWarudoTimer;
        }

        if (PlayerPrefs.GetInt("SlotPosition2") != -1)
        {
            azhasarobj2 = Instantiate(azhasarobj, talentPanel.transform);
            switch (PlayerPrefs.GetInt("Az Hasar", 1))
            {
                case 1:
                    lessdamage = 5;
                    break;
                case 2:
                    lessdamage = 15;
                    azhasarobj2.GetComponent<Image>().sprite = azhasar2;
                    break;
                case 3:
                    lessdamage = 30;
                    azhasarobj2.GetComponent<Image>().sprite = azhasar3;
                    break;
            }
        }
        if (PlayerPrefs.GetInt("SlotPosition3") != -1)
        {
            bırsansobj2 = Instantiate(bırsansobj, talentPanel.transform);
            switch (PlayerPrefs.GetInt("BirSans", 1))
            {
                case 1:
                    yenıdencanlanmamıktarı = 35;
                    break;
                case 2:
                    yenıdencanlanmamıktarı = 50;
                    bırsansobj2.GetComponent<Image>().sprite = bırsans2;
                    break;
                case 3:
                    yenıdencanlanmamıktarı = 70;
                    bırsansobj2.GetComponent<Image>().sprite = bırsans3;
                    break;
            }
        }
        if (PlayerPrefs.GetInt("SlotPosition4") != -1)
        {
            canobj2 = Instantiate(canobj, talentPanel.transform);
            switch (PlayerPrefs.GetInt("CanIksırı", 1))
            {
                case 1:
                    canartır = 20;
                    break;
                case 2:
                    canartır = 30;
                    canobj2.GetComponent<Image>().sprite = cansprite2;
                    break;
                case 3:
                    canartır = 40;
                    canobj2.GetComponent<Image>().sprite = cansprite3;
                    break;
            }
        }
        if (PlayerPrefs.GetInt("SlotPosition5") != -1)
        {
            dokunulmazobj2 = Instantiate(dokunulmazobj, talentPanel.transform);
            dokunulmazımage = dokunulmazobj2.transform.GetChild(0).GetComponent<Image>();
            switch (PlayerPrefs.GetInt("Dokunulmaz", 1))
            {
                case 1:
                    dokunulmaztime = 10;
                    break;
                case 2:
                    dokunulmaztime = 15;
                    dokunulmazobj2.GetComponent<Image>().sprite = dokunulmazsprite2;
                    break;
                case 3:
                    dokunulmaztime = 20;
                    dokunulmazobj2.GetComponent<Image>().sprite = dokunulmazsprite3;
                    break;
            }

            dokunulmaztimerr = dokunulmaztime;
        }
        if (PlayerPrefs.GetInt("SlotPosition6") != -1)
        {
            gorunmezobj2 = Instantiate(gorunmezobj, talentPanel.transform);
            gorunmezImage = gorunmezobj2.transform.GetChild(0).GetComponent<Image>();
            switch (PlayerPrefs.GetInt("Gorunmez", 1))
            {
                case 1:
                    gorunmeztime = 5;
                    break;
                case 2:
                    gorunmeztime = 7.5f;
                    gorunmezobj2.GetComponent<Image>().sprite = gorunmezsprite2;
                    break;
                case 3:
                    gorunmeztime = 10;
                    gorunmezobj2.GetComponent<Image>().sprite = gorunmezsprite3;
                    break;
            }
        }
        if (PlayerPrefs.GetInt("SlotPosition7") != -1)
        {
            gucluyumrukobj2 = Instantiate(gucluyumrukobj, talentPanel.transform);
            hasarartırstacktext = gucluyumrukobj2.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            switch (PlayerPrefs.GetInt("GucluYumruklar", 1))
            {
                case 1:
                    hasarıartır = 2;
                    break;
                case 2:
                    hasarıartır = 2.5f;
                    gucluyumrukobj2.GetComponent<Image>().sprite = hızlıyumruk2;
                    break;
                case 3:
                    hasarıartır = 3;
                    gucluyumrukobj2.GetComponent<Image>().sprite = hızlıyumruk3;
                    break;
            }
        }
        if (PlayerPrefs.GetInt("SlotPosition10") != -1)
        {
            hızlıultiobj2 = Instantiate(hızlıultiobj, talentPanel.transform);
            switch (PlayerPrefs.GetInt("HızlıUltı", 1))
            {
                case 1:
                    ultıartısoranı = 10;
                    break;
                case 2:
                    ultıartısoranı = 15;
                    hızlıultiobj2.GetComponent<Image>().sprite = hızlıulti2;
                    break;
                case 3:
                    ultıartısoranı = 25;
                    hızlıultiobj2.GetComponent<Image>().sprite = hızlıulti3;
                    break;
            }
        }

        if (PlayerPrefs.GetInt("SlotPosition9") != -1)
        {
            hızlıyumrukobj = Instantiate(hızlıyumrukımage, talentPanel.transform);
            saldırıhızıstacktext = hızlıyumrukobj.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            switch (PlayerPrefs.GetInt("HızlıYumruk", 1))
            {
                case 1:
                    saldırıhızıartır = 0.03f;
                    break;
                case 2:
                    saldırıhızıartır = 0.04f;
                    hızlıyumrukobj.GetComponent<Image>().sprite = hızlıyumruk2;
                    break;
                case 3:
                    saldırıhızıartır = 0.05f;
                    hızlıyumrukobj.GetComponent<Image>().sprite = hızlıyumruk3;
                    break;
            }
        }

        if (PlayerPrefs.GetInt("SlotPosition8") != -1)
        {
            quickcoinobj = Instantiate(quickcoinımage, talentPanel.transform);
            quickcointext = quickcoinobj.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            switch (PlayerPrefs.GetInt("HızlıAltın", 1))
            {
                case 1:
                    quickmoney = 10;
                    break;
                case 2:
                    quickmoney = 15;
                    quickcoinobj.GetComponent<Image>().sprite = quickmoney2;
                    break;
                case 3:
                    quickmoney = 25;
                    quickcoinobj.GetComponent<Image>().sprite = quickmoney3;
                    break;
            }
        }
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("SlotPosition") != -1)
        {
            if (Input.GetKeyDown(KeyCode.Z) && zaWarudo)
            {
               // zaWarudo = false;
                zaWarudofill.color = Color.green;
                zaWarudoTimer2 = zaWarudoTimer;
            }

            else if (!zaWarudo && !zaWarudocooldown)
            {
                zaWarudoTimer2 -= Time.deltaTime;
                zaWarudofill.fillAmount = Mathf.InverseLerp(0, zaWarudoTimer, zaWarudoTimer2);
                if (zaWarudoTimer2 <= 0)
                {
                    zaWarudocooldown = true;
                    ınstaza.GetComponent<Image>().color = new Color(0.2f, 0.2f, 0.2f);
                }
            }

            else if (zaWarudocooldown)
            {
                zaWarudofill.color = Color.red;
                cooldowntimer -= Time.deltaTime;
                zaWarudofill.fillAmount = Mathf.InverseLerp(0, 40, cooldowntimer);
                if (cooldowntimer <= 0)
                {
                    zaWarudocooldown = false;
                    zaWarudo = true;
                    cooldowntimer = 40;
                    ınstaza.GetComponent<Image>().color = new Color(1, 1, 1);
                }
            }
        }
    }

   public IEnumerator dokunulmaztimer()
    {
        dokunulmaztimerr -= Time.deltaTime;
        dokunulmazımage.fillAmount=Mathf.InverseLerp(0, dokunulmaztime, dokunulmaztimerr);
        yield return null;
        if (dokunulmaztimerr >= 0)
            StartCoroutine(dokunulmaztimer());
        else
        {
            dokunulmaztimerr = dokunulmaztime;
            dokunulmazobj2.GetComponent<Image>().color = new Color(0.2f, 0.2f, 0.2f);
        }
    }

   IEnumerator gorunmezTimer()
   {
       gameObject.layer = 0;
       isgorunmez = false;
       gorunmezImage.color=Color.green;
       gorunmezgerisayım = gorunmeztime;
       sr.color = new Color(1, 1, 1, 0.5f);
       StartCoroutine(gorunmezusıng());
       yield return new WaitForSeconds(gorunmeztime);
       gameObject.layer = 1;
       gorunmezobj2.GetComponent<Image>().color = new Color(0.2f, 0.2f, 0.2f);
       sr.color = new Color(1, 1, 1, 1);
   }

   IEnumerator gorunmeztcooldown()
   {
       gorunmezgerisayım -= Time.deltaTime;
       gorunmezImage.fillAmount = Mathf.InverseLerp(0, 40, gorunmezgerisayım);
       yield return null;
       if (gorunmezgerisayım >= 0)
           StartCoroutine(gorunmeztcooldown());
       else
       {
           gorunmezgerisayım = 40;
           gorunmezobj2.GetComponent<Image>().color = new Color(1f, 1f, 1f);
           isgorunmez = true;
       }
   }

   IEnumerator gorunmezusıng()
   {
       gorunmezgerisayım -= Time.deltaTime;
       gorunmezImage.fillAmount = Mathf.InverseLerp(0, gorunmeztime, gorunmezgerisayım);
       yield return null;
       if (gorunmezgerisayım >= 0)
           StartCoroutine(gorunmezusıng());
       else
       {
           gorunmezgerisayım = 40;
           gorunmezImage.color=Color.red;
           StartCoroutine(gorunmeztcooldown());
       }
   }

    public void stackwriter(byte decision)
    {
        if (decision == 1)
            saldırıhızıstack++;
        else
            saldırıhızıstack = 0;
        saldırıhızıstacktext.text = saldırıhızıstack.ToString();
    }

    public void damagestackwriter(byte decision)
    {
        if (decision == 1)
            hasarıartırstack++;
        else
            hasarıartırstack = 0;
        hasarartırstacktext.text = hasarıartırstack.ToString();
    }

    public void quickstackwriter(int gelenaltın)
    {
        toplamquickmoney += (gelenaltın * quickmoney) / 100;
        quickcointext.text = toplamquickmoney.ToString();
    }

    public void callgorunmez()
    {
        StartCoroutine(gorunmezTimer());
    }
}