
using System;
using UnityEngine;

public class uıanimation : MonoBehaviour
{
  private SliderJoint2D sj;

  private void Start()
  {
    sj = GetComponent<SliderJoint2D>();
  }

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.A))
    {
      sj.angle = 0;
    }
    if (Input.GetKeyDown(KeyCode.D))
    {
      sj.angle = 180;
    }
  }
}
