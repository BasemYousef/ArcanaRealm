using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon_Attack : StateMachineBehaviour
{
    [SerializeField] private float minTime;
    [SerializeField] private float maxTime;

    private int rand;
    private float cooldown;
    private Moon moon;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        cooldown = Random.Range(minTime, maxTime);
        moon = animator.GetComponent<Moon>();
        moon.StartSpecialAttack();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (cooldown <= 0)
        {
            rand = Random.Range(0, 1);
            switch (rand)
            {
                case 0:
                    moon.StartSpecialAttack();
                    break;
                case 1:
                    // Attack 2
                    break;
            }
            animator.SetTrigger("Idle");
        }
        else
        {
            cooldown -= Time.deltaTime;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        moon.EndSpecialAttack();
    }
}
