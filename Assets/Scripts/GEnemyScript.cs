using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GEnemyScript : MonoBehaviour
{
   private Animator anim;
   public LayerMask playerlayer;
   public bool isRelodad;
   public Transform[] points;
   private byte pointscontrol;
   public Transform character;
   public GameObject launcher;
   private bool isUlti;

   private void Start()
   {
      character = GameObject.FindWithTag("Player").transform;
      anim = GetComponent<Animator>();
   }
   void isDeath()
   {
      enabled = false;
   }
   
   void UltiOpen()
   {
      isUlti = true;
      anim.enabled = false;
   }

   void UltiEnd()
   {
      isUlti = false;
      anim.enabled = true;
   }

   private void Update()
   {
      if (!isUlti)
      {
         if(anim.GetCurrentAnimatorStateInfo(0).IsName("G-Relodad"))
         {
            transform.position = transform.position;
         }
         else
         {
            Range();
         }
      }
   }

   void Range()
   {
      bool range = Physics2D.OverlapCircle(transform.position, 7,playerlayer);
      if (range)
      {
         anim.SetBool("isDetected",true);
         transform.position = transform.position;
         if (character.position.x > transform.position.x)
         {
            transform.localScale = new Vector2(1, 1);
         }
         else
         {
            transform.localScale = new Vector2(-1, 1);
         }
      }
      else
      {
         anim.SetBool("isDetected",false);
         transform.position = Vector2.MoveTowards(transform.position,points[pointscontrol].position,1*Time.deltaTime);
         if (points[pointscontrol].position.x > transform.position.x)
         {
            transform.localScale = new Vector2(1, 1);
         }
         else
         {
            transform.localScale = new Vector2(-1, 1);
         }
      }

   }

   public void launcherGo()
   {
      Instantiate(launcher, transform.position, Quaternion.identity);
   }

   private void OnTriggerEnter2D(Collider2D col)
   {
      if (col.gameObject.CompareTag("FollowPoint"))
      {
         switch (pointscontrol)
         {
            case 0:
               pointscontrol = 1;
               break;
            case 1:
               pointscontrol = 0;
               break;
         }
      }
   }

   private void OnDrawGizmosSelected()
   {
      Gizmos.DrawWireSphere(transform.position, 7f);
   }
}
