using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float attackRange;
    private float damageAmount;
    void Start()
    {
        attackRange = 3f;
        damageAmount = 20f;
}
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) 
        {
            Attack();
        }
        
    }
    void Attack()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit,attackRange))
        {
            Health enemyHealth = hit.transform.GetComponent<Health>();
            if(enemyHealth != null) 
            {
                enemyHealth.TakeDamage(damageAmount, hit.transform.gameObject);
            }
        }
    }
}
