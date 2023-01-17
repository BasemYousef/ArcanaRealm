using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BonusController : MonoBehaviour
{
    [SerializeField] float bonus;
    [SerializeField] AudioClip bonusClip;   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(bonusClip, GameObject.FindObjectOfType<Camera>().transform.position);
          //  collision.GetComponent<PlayerHealth>().BonusHealth(bonus);
            
            Destroy(gameObject);
        }
    }
}

