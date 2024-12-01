using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float aggroRadius;
    private float movementSpeed;
    private Transform player;
    private Rigidbody rb;
    private Animator animator;  // Animator referansı
    private bool chaseStarted;

    void Start()
    {
        chaseStarted = false;
        aggroRadius = 12f;
        movementSpeed = 4f;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();  // Animator bileşenini alıyoruz
    }

    void Update()
    {
        MoveTowardsTarget();
    }

    void MoveTowardsTarget()
    {
        float playerDistance = Vector3.Distance(transform.position, player.position);

        if (playerDistance <= aggroRadius || chaseStarted)
        {
            chaseStarted = true;
            animator.StopPlayback();

            // Oyuncu range içinde, hareket etmeye başla
            Vector3 direction = (player.position - transform.position).normalized;

            // Y eksenindeki hareketi engelle
            direction.y = 0;

            // Rigidbody ile hareket
            if (rb != null)
            {
                rb.MovePosition(transform.position + direction * movementSpeed * Time.deltaTime);
            }

            // Yüzünü karaktere dönsün
            RotateTowardsPlayer();

            // Hareket başladı, animasyonu değiştirelim
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }

    // Yüzü her zaman karaktere döndürmek için fonksiyon
    void RotateTowardsPlayer()
    {
        // Hedefin pozisyonunu al
        Vector3 targetDirection = (player.position - transform.position).normalized;

        // Y eksenindeki dönüşü engellemek için yalnızca y ekseninde dönüş yapıyoruz
        targetDirection.y = 0;

        // Eğer hareket var ise, düşmanı hedefe doğru döndür
        if (targetDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);  // Yavaşça dönmesi için Slerp kullanıyoruz
        }
    }
}
