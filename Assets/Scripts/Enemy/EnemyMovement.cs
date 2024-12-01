using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float aggroRadius;
    private float movementSpeed;
    private Transform player;
    private Rigidbody rb;
    void Start()
    {
        aggroRadius = 40f;
        movementSpeed = 20f;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MoveTowardsTarget();
    }

    void MoveTowardsTarget()
    {
        float playerDistance = Vector3.Distance(transform.position, player.position);

        if (playerDistance <= aggroRadius)
        {
            Vector3 direction = (player.position - transform.position).normalized;

            // Y eksenindeki hareketi engelle
            direction.y = 0;

            // Rigidbody ile hareket
            if (rb != null)
            {
                rb.MovePosition(transform.position + direction * movementSpeed * Time.deltaTime);
            }
        }
    }
}
