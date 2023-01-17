using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Run : StateMachineBehaviour
{
    Transform Target;
    Rigidbody2D rb;
    Boss boss;
    public float speed = 2.5f;
    public float attackRange = 3f;
    private float atkStart = 0;
    public float atkCooldown = 2;
    public int attackCounter = 0;
   
   
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        Target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LookAtPlayer();
        Vector2 target = new Vector2(Target.position.x, rb.position.y);
        Vector2 newpos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newpos);
        if (Vector2.Distance(Target.position, rb.position) <= attackRange && Time.time > atkStart + atkCooldown)
        {
            attackCounter++;
            atkStart = Time.time;
            if (attackCounter <= 3)
            {
                animator.SetTrigger("Attack");
            }
            else
            {
                animator.SetTrigger("SpAtk");
                attackCounter = 0;
            }


        }

    }
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }

}
