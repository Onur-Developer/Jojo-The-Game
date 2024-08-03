using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundScript : MonoBehaviour
{
    [SerializeField] private AudioSource au;
    [SerializeField] private AudioClip click, choise, dowm;

    public void clicksound()
    {
        au.PlayOneShot(click);
    }

    public void chousefunc()
    {
        au.PlayOneShot(choise);
    }

    public void dowmfunc()
    {
        au.PlayOneShot(dowm);
    }
}
