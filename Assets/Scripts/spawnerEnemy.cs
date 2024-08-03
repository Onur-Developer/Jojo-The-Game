using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class spawnerEnemy : MonoBehaviour
{
   public GameObject[] Enemys;
   private int randomvalue;
   public GameObject[] Points;
   public GameObject controlallenemy;


   private void Start()
   {
      controlallenemy = GameObject.FindWithTag("Respawn");
      ınstant();
   }

   void ınstant()
   {
      for (int i = 0; i < 2; i++)
      {
         randomvalue = Random.Range(0,4);
         switch (randomvalue)
         {
            case 0:
               GameObject obj = Instantiate(Enemys[randomvalue], transform);
               obj.GetComponent<EnemyScript>().Points[0] = Points[0].transform;
               obj.GetComponent<EnemyScript>().Points[1] = Points[1].transform;
               obj.transform.SetParent(controlallenemy.transform);
               break;
            case 1:
               GameObject obj2 = Instantiate(Enemys[randomvalue], transform);
               obj2.GetComponent<GEnemyScript>().points[0] = Points[0].transform;
               obj2.GetComponent<GEnemyScript>().points[1] = Points[1].transform;
               obj2.transform.SetParent(controlallenemy.transform);
               break;
            case 2:
               GameObject obj3 = Instantiate(Enemys[randomvalue], transform);
               obj3.GetComponent<REnemyScript>().points[0] = Points[0].transform;
               obj3.GetComponent<REnemyScript>().points[1] = Points[1].transform;
               obj3.transform.SetParent(controlallenemy.transform);
               break;
            case 3:
               GameObject obj4 = Instantiate(Enemys[randomvalue], transform);
               obj4.GetComponent<SEnemyScript>().Points[0] = Points[0].transform;
               obj4.GetComponent<SEnemyScript>().Points[1] = Points[1].transform;
               obj4.transform.SetParent(controlallenemy.transform);
               break;
         }
      }
   }
}
