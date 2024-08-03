using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comboScript2 : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    /* override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
     {
     } */

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!Controllers.instance.anim.GetBool("isUlti") && Controllers.instance.isAttacking)
        {
            Controllers.instance.anim.Play("PunchAnim2");
        }

        else if (Controllers.instance.isAttacking)
        {
            Controllers.instance.anim.Play("UltiPunchAnim2");
        }
        if (Controllers2.instance.isAttacking)
        {
            Controllers2.instance.anim.SetBool("ComboContinue2",true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Controllers.instance.isAttacking = false;
        Controllers2.instance.isAttacking = false;
        Controllers2.instance.anim.SetBool("ComboContinue",false);
        Controllers2.instance.anim.SetBool("ComboContinue2",false);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}