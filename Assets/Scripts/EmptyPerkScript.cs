using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyPerkScript : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Perks"))
        {
            col.gameObject.GetComponent<PerksScript>().isActive = true;
            col.gameObject.GetComponent<PerksScript>().takeValue(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Perks"))
        {
            other.gameObject.GetComponent<PerksScript>().isActive = false;
        }
    } 
}
