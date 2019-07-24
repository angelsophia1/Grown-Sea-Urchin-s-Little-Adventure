using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabBubble : StateMachineBehaviour {
    private bool needRand = true;
    private int rand;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        needRand = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (needRand)
        {
            rand = Random.Range(1, 3);
            if (rand == 2)
            {
                rand += 1;
            }
            switch ((CrabStates)rand)
            {
                case CrabStates.Patrol:
                    animator.SetInteger("StateNumber", 1);
                    break;
                case CrabStates.Laser:
                    animator.SetInteger("StateNumber", 3);
                    break;
                default:
                    break;
            }
            needRand = false;
        }
    }

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
