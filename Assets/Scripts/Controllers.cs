using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Controllers : MonoBehaviour
{
    public Controllers2 ct2;
    public Rigidbody2D rb;
    public Animator anim, gamepanelanım;
    private float movementX, movementY, punchtimer, heart, maxheart = 100, mydamage = 20;
    public bool isAttacking, isMove, iscount, nodamagebool, ismyulti, ishead, isdash;
    public static Controllers instance;
    private float speed = 5, ulticount;
    public Transform hitPoint, dontDestroy;
    private Vector2 look;
    private int coin, nowcoin;
    private byte healtposioncount;
    [SerializeField] private CinemachineVirtualCamera cc;
    public GameObject Stand;

    [Header("UI Elements")] [SerializeField]
    private Image heartImage;

    [SerializeField] private TextMeshProUGUI healttext;

    [SerializeField] private Image ultiImage;
    [SerializeField] private TextMeshProUGUI ultitext;
    [SerializeField] private Image jotaroFace;
    [SerializeField] private Image starPlatiniumFace;
    [SerializeField] private TextMeshProUGUI coinText, healtposiontext;
    [SerializeField] private GameObject healtposionpanel,dashımage;

    [SerializeField] private talentManager tl;
    [SerializeField] private dontdestroy ds;

    [Header("Sesler")] [SerializeField] private AudioSource au, auwalk,aubackground;

    [SerializeField]
    private AudioClip theworldopen, tıktak, theworldend, deathsound, coinsound, standcoming, standgoing, healtpickup,skeletondeath,boom,reverse;

    [SerializeField] private AudioClip[] gainhealtsound;
    [SerializeField] private AudioClip[] dıksın;
    [SerializeField] private AudioClip[] takedamages;
    private int randomgainhealt;

    private void Start()
    {
        gamepanelanım = GameObject.FindWithTag("Gamep").GetComponent<Animator>();
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        isMove = true;
        heart = maxheart;
        writehealt();
        healttext.text = heart + " / 100";
        ultitext.text = ulticount + " / 100";
        isdash = true;
    }

    public void onDinamic()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    public void ewww()
    {
        au.PlayOneShot(skeletondeath);
    }

    public void reversesound()
    {
        au.PlayOneShot(reverse);
    }

    public void boomsound()
    {
        au.PlayOneShot(boom);
    }

    public void standgo()
    {
        au.PlayOneShot(standgoing);
    }

    public void TakeDamage(float damage)
    {
        if (!nodamagebool)
        {
            randomgainhealt = Random.Range(0, 2);
            au.PlayOneShot(takedamages[randomgainhealt]);
            anim.Play("TakeDamageAnim");
            if (PlayerPrefs.GetInt("SlotPosition2") != -1)
                heart -= damage - ((damage * tl.lessdamage) / 100);
            else
                heart -= damage;
            if (heart <= 0 && tl.isdokunulmaz && PlayerPrefs.GetInt("SlotPosition5") != -1)
            {
                heart = 10;
                StartCoroutine(nodamage(tl.dokunulmaztime));
                tl.isdokunulmaz = false;
                StartCoroutine(tl.dokunulmaztimer());
            }

            heartImage.fillAmount = Mathf.InverseLerp(0, maxheart, heart);
            healttext.text = Math.Round(heart, 0) + " / 100";
            if (PlayerPrefs.GetInt("SlotPosition9") != -1)
            {
                anim.SetFloat("SaldırıHızı", 1);
                tl.stackwriter(0);
            }

            if (PlayerPrefs.GetInt("SlotPosition7") != -1)
            {
                mydamage = 20;
                tl.damagestackwriter(0);
            }

            ultiıncrease(0, damage);
            amIdead();
        }
    }

    void ultiıncrease(byte value, float comingdamage)
    {
        if (value == 0)
        {
            if (PlayerPrefs.GetInt("SlotPosition10") != -1)
                ulticount += (comingdamage / 2) + (comingdamage / 2 * (tl.ultıartısoranı / 100));
            else
                ulticount += comingdamage / 2;
        }
        else
        {
            if (PlayerPrefs.GetInt("SlotPosition10") != -1)
                ulticount += 0.5f + (0.5f * tl.ultıartısoranı / 100);
            else
                ulticount += 0.5f;
        }

        if (ulticount > 100)
            ulticount = 100;

        ultiImage.fillAmount = Mathf.InverseLerp(0, 100, ulticount);
        ultitext.text = Math.Round(ulticount, 1) + " / 100";
    }

    void amIdead()
    {
        if (heart <= 0)
        {
            if (PlayerPrefs.GetInt("SlotPosition3") != -1 && !tl.onemore)
            {
                heart = tl.yenıdencanlanmamıktarı;
                heartImage.fillAmount = Mathf.InverseLerp(0, maxheart, heart);
                tl.onemore = true;
                tl.bırsansobj2.GetComponent<Image>().color = new Color(0.2f, 0.2f, 0.2f);
                StartCoroutine(nodamage(1));
            }
            else
            {
                aubackground.enabled = false;
                // Time.timeScale = 0;
                au.PlayOneShot(deathsound);
                anim.Play("Death");
                PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + coin + tl.toplamquickmoney);
                StartCoroutine(ds.deathScene());
                enabled = false;
            }

            heartImage.fillAmount = Mathf.InverseLerp(0, maxheart, heart);
        }
    }

    IEnumerator nodamage(float seconds)
    {
        nodamagebool = true;
        yield return new WaitForSecondsRealtime(seconds);
        nodamagebool = false;
    }

    void gainhealt()
    {
        if (healtposioncount != 0)
        {
            if (PlayerPrefs.GetInt("SlotPosition4") != -1)
                heart += 30 + ((30 * tl.canartır / 100));
            else
                heart += 30;
            if (heart >= 100)
            {
                heart = 100;
                if (PlayerPrefs.GetInt("SlotPosition5") != -1 && !tl.isdokunulmaz)
                {
                    tl.isdokunulmaz = true;
                    tl.dokunulmazobj2.GetComponent<Image>().color = new Color(1, 1, 1);
                }
            }

            randomgainhealt = Random.Range(0, 3);
            heartImage.fillAmount = Mathf.InverseLerp(0, maxheart, heart);
            healttext.text = Math.Round(heart, 1) + " /100";
            healtposioncount--;
            au.PlayOneShot(gainhealtsound[randomgainhealt]);
            writehealt();
        }
    }

    void writehealt()
    {
        healtposionpanel.SetActive(true);
        if (healtposioncount > 0)
            healtposiontext.text = healtposioncount.ToString();
        else
            healtposionpanel.SetActive(false);
    }

    public void changeFace(bool situation)
    {
        cc.Follow = transform;
        jotaroFace.enabled = situation;
        starPlatiniumFace.enabled = !situation;
    }

    public void gainCoin(int coinn)
    {
        if (PlayerPrefs.GetInt("SlotPosition8") != -1)
        {
            tl.quickstackwriter(coinn);
        }

        au.PlayOneShot(coinsound);
        nowcoin = coin;
        coin += coinn;
        if (!iscount)
            StartCoroutine("drawCoin");
    }

    IEnumerator drawCoin()
    {
        iscount = true;
        while (nowcoin < coin)
        {
            nowcoin++;
            coinText.text = nowcoin.ToString();
            yield return new WaitForSeconds(0.02f);
        }

        iscount = false;
    }

    private void FixedUpdate()
    {
        if (isMove)
        {
            movementX = Input.GetAxisRaw("Horizontal");
            movementY = Input.GetAxisRaw("Vertical");

            // rb.velocity = new Vector2(movementX * speed, movementY * speed) * Time.deltaTime;
            transform.position += new Vector3(movementX, movementY) * speed * Time.deltaTime;
            if (movementX != 0 || movementY != 0)
                auwalk.enabled = true;
            else
                auwalk.enabled = false;
        }
    }

   

    private void Update()
    {
        // 2-16 32-46
        /*aubackground.GetSpectrumData(m_SpectrumData, 0, FFTWindow.BlackmanHarris);

        // 20Hz - 60Hz arasındaki spektrum verisini alıyoruz
        float bassValue = 0f;
        for (int i = 0; i < 6; i++)
        {
            bassValue += m_SpectrumData[i];
        }

        bassValue += BalanceVolume;
        Debug.Log("Bass Value: "+bassValue);
        if(bassValue > 1f)
            Debug.Log("Bass"); */

        /* if (rb.velocity.x != 0 || rb.velocity.y != 0)
         {
             anim.SetBool("isRun", true);
         }
         else
         {
             anim.SetBool("isRun", false);
         }
 
         if (rb.velocity.x < 0)
         {
             transform.localScale = new Vector2(-1, 1);
         }
         else if (rb.velocity.x > 0)
         {
             transform.localScale = new Vector2(1, 1);
         } */

        if (movementX != 0 || movementY != 0)
        {
            anim.SetBool("isRun", true);
        }
        else
        {
            anim.SetBool("isRun", false);
        }

        if (movementX < 0)
        {
            transform.localScale = new Vector2(-1, 1);
            look = new Vector2(-1, 0);
        }
        else if (movementX > 0)
        {
            transform.localScale = new Vector2(1, 1);
            look = new Vector2(1, 0);
        }

        if (Input.GetKeyDown(KeyCode.U) && !ismyulti)
        {
            au.PlayOneShot(standcoming);
            anim.SetBool("isRun", false);
            ct2.enabled = true;
            ct2.onDinamic();
            ct2.line.enabled = true;
            ct2.line.SetPosition(0, Vector3.zero);
            ct2.line.SetPosition(1, Vector3.zero);
            ct2.lineAnim();
            // rb.velocity=Vector2.zero;
            rb.bodyType = RigidbodyType2D.Kinematic;
            changeFace(false);
            enabled = false;
            cc.Follow = Stand.transform;
        }

        if (Input.GetKeyDown(KeyCode.Z) && tl.zaWarudo)
        {
            au.PlayOneShot(theworldopen);
            StartCoroutine("zaWarudo");
            tl.zaWarudo = false;
            gamepanelanım.SetBool("istheworld", true);
        }

        if (Input.GetKeyDown(KeyCode.T) && ulticount == 100)
        {
            anim.Play("TheWorldEffect");
            StartCoroutine("ultiStart");
        }

        Attack();

        if (Input.GetKeyDown(KeyCode.Space) && isdash)
        {
            StartCoroutine("Dash");
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            gainhealt();
        }

        if (Input.GetKeyDown(KeyCode.G) && tl.isgorunmez && PlayerPrefs.GetInt("SlotPosition6", -1) != -1)
        {
            tl.callgorunmez();
        }
    }

    public void Attack()
    {
        if (Input.GetButtonDown("Fire1") && !isAttacking)
        {
            isAttacking = true;
        }
    }

    public void Hit()
    {
        Collider2D[] hit = Physics2D.OverlapCircleAll(hitPoint.position, 1f);

        foreach (var var in hit)
        {
            if (var.gameObject.CompareTag("Enemy"))
            {
                randomgainhealt = Random.Range(0, 10);
                var.gameObject.GetComponent<Enemys>().TakeDamage(mydamage, look);
                au.PlayOneShot(dıksın[randomgainhealt]);
                if (!Enemys.isUlti)
                    ultiıncrease(1, 0);

                if (PlayerPrefs.GetInt("SlotPosition7") != -1)
                {
                    if (tl.hasarıartırstack != 8)
                    {
                        mydamage += tl.hasarıartır;
                        tl.damagestackwriter(1);
                    }
                }

                if (PlayerPrefs.GetInt("SlotPosition9") != -1)
                {
                    if (tl.saldırıhızıstack != 8)
                    {
                        anim.SetFloat("SaldırıHızı", anim.GetFloat("SaldırıHızı") + tl.saldırıhızıartır);
                        tl.stackwriter(1);
                    }
                }
            }
        }
    }

    IEnumerator zaWarudo()
    {
        Enemys.isUlti = true;
        anim.SetLayerWeight(1, 1);
        isMove = true;
        transform.SetParent(dontDestroy);
        anim.Play("TheWorldEffect");
        yield return new WaitForSeconds(1.5f);
        au.clip = tıktak;
        au.enabled = false;
        au.enabled = true;
        yield return new WaitForSeconds(tl.zaWarudoTimer - 1.5f);
        anim.SetLayerWeight(1, 0);
        gamepanelanım.SetBool("istheworld", false);
        au.PlayOneShot(theworldend);
        au.clip = null;
    }

    IEnumerator ultiStart()
    {
        au.PlayOneShot(theworldopen);
        speed = 10;
        ismyulti = true;
        StartCoroutine(ultivisual());
        Enemys.isUlti = true;
        anim.SetBool("isUlti", true);
        anim.SetLayerWeight(1, 1);
        yield return new WaitForSeconds(1.5f);
        au.PlayOneShot(tıktak);
        au.enabled = false;
        au.enabled = true;
        yield return new WaitForSeconds(15);
        anim.SetBool("isUlti", false);
        anim.SetLayerWeight(1, 0);
        ismyulti = false;
        speed = 5;
        au.PlayOneShot(theworldend);
        au.clip = null;
    }

    IEnumerator ultivisual()
    {
        ulticount -= Time.deltaTime * 6.4f;
        ultiImage.fillAmount = Mathf.InverseLerp(0, 100, ulticount);
        yield return null;
        if (ulticount <= 0)
            ulticount = 0;
        else
            StartCoroutine(ultivisual());
    }

    IEnumerator Dash()
    {
        speed = 15;
        anim.Play("Dash");
        ishead = true;
        isdash = false;
        yield return new WaitForSecondsRealtime(0.5f);
        speed = 5;
        ishead = false;
        dashımage.SetActive(true);
        yield return new WaitForSeconds(3);
        dashımage.SetActive(false);
        isdash = true;
    }

    IEnumerator speedNerf()
    {
        speed = 1;
        yield return new WaitForSeconds(1.5f);
        speed = 5;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(hitPoint.position, 1f);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Kapı"))
        {
            ds.nextScene();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Grabble"))
        {
            StartCoroutine("speedNerf");
        }
        else if (col.gameObject.CompareTag("HealtPosion"))
        {
            Destroy(col.gameObject);
            healtposioncount++;
            au.PlayOneShot(healtpickup);
            writehealt();
        }
    }
}