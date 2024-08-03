using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlEnemyScript : MonoBehaviour
{
    public GameObject door;
    public Sprite opendoorsprite;

    private void Awake()
    {
        door = GameObject.Find("Kapı");
    }

    private void Start()
    {
        door.tag = "Untagged";
        StartCoroutine(controlen());
    }

    IEnumerator controlen()
    {
        yield return new WaitForSeconds(1);
        if (transform.childCount == 0)
        {
            door.tag = "Kapı";
            door.GetComponent<SpriteRenderer>().sprite = opendoorsprite;
        }
        else
        {
            StartCoroutine(controlen());
        }
    }
}
