using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Moon : MonoBehaviour
{
    [SerializeField] private List<GameObject> attacks = new List<GameObject>();
    [SerializeField] private float specialAttackDuration = 1.5f;

    public void StartSpecialAttack()
    {
        attacks[0].SetActive(true);
    }

    public void EndSpecialAttack()
    {
        attacks[0].SetActive(false);
    }

    
}
