using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private CharacterController2D controller;
    private SpriteMask spriteMask;
    private Animator animator;
    private float horizontalMove = 0f;
    private bool jump = false;
    private bool isAttacking = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController2D>();
        animator = GetComponent<Animator>();
        spriteMask = GetComponent<SpriteMask>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Attack1"))
            isAttacking = true;
        else
            isAttacking = false;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetBool("IsAttacking", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("IsAttacking", false);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //Vector3 tpDistance = 

            transform.position = new Vector3(transform.position.x + 10, transform.position.y, 0f);
        }


    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    private void FixedUpdate()
    {
        if (!isAttacking)
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
            jump = false;
        }
    }
}
