using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject magicAttack;
    [SerializeField] Transform magicAttackTransform;
    [SerializeField] float attackSpeed;

    private Animator animator;
    private bool canAttack = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canAttack)
            Attack();
    }

    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            StartCoroutine(ShootMagic());
        }
    }

    IEnumerator ShootMagic()
    {
        canAttack = false;
        yield return new WaitForSeconds(0.7f);
        GameObject arrow = Instantiate(magicAttack, magicAttackTransform.transform.position, magicAttackTransform.rotation);
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        rb.AddForce(magicAttackTransform.transform.right * attackSpeed, ForceMode2D.Impulse);
        Destroy(arrow, 3.0f);
        yield return new WaitForSeconds(0.1f);
        canAttack = true;
    }
}
