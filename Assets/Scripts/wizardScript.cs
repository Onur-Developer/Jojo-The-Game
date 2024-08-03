using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wizardScript : MonoBehaviour
{
    private GameObject otherwizard;
    public string myname;

    private void Awake()
    {
        if (myname == "BlueWizard")
            otherwizard = GameObject.Find("RedWizard");

        else
            otherwizard = GameObject.Find("BlueWizard");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            StartCoroutine(teleporting(col.gameObject));
        }
    }

    IEnumerator teleporting(GameObject player)
    {
        otherwizard.GetComponent<BoxCollider2D>().enabled = false;
        player.transform.position = otherwizard.transform.position;
        yield return new WaitForSeconds(2f);
        otherwizard.GetComponent<BoxCollider2D>().enabled = true;
    }
}