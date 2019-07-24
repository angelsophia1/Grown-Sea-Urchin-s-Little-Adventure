using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum CrabStates {Patrol=1,Bubble=2,Laser=3};
public class CrabBigIdle : StateMachineBehaviour {
    private int rand;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rand = Random.Range(1,4);
        switch ((CrabStates)rand)
        {
            case CrabStates.Patrol:
                animator.SetInteger("StateNumber", 1);
                break;
            case CrabStates.Bubble:
                animator.SetInteger("StateNumber", 2);
                break;
            case CrabStates.Laser:
                animator.SetInteger("StateNumber", 3);
                break;
            default:
                break;               
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{

    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{

    //}

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
