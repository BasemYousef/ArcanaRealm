using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttack : MonoBehaviour
{
    [SerializeField] float cooldownReduction = 7;
    [SerializeField] int damage = 50;

    private float atkStart = 0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //collision.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
    }

    void Update()
    {
        SpAttack();

    }

    public void SpAttack()
    {


        if (Input.GetKeyUp(KeyCode.C) && Time.time > atkStart)
        {
            atkStart = cooldownReduction + Time.time;

        }
    }
}
