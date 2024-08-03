using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takip : MonoBehaviour
{
   Transform myhedef;
    public void degerler(Transform hedef)
    {
        myhedef = hedef;
    }

    private void Update()
    {
        transform.position =
            Vector2.MoveTowards(transform.position, myhedef.transform.position, 5*Time.deltaTime);
    }
}
