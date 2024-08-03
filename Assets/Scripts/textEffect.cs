using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textEffect : MonoBehaviour
{
   private void Update()
   {
      transform.Translate(Vector2.up*1*Time.deltaTime);
   }
}
