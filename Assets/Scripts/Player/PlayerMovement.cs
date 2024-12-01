using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed;
    private CharacterController controller;
    private float mouseSensitivity;
    private float yRotation;
    private Transform cameraTransform;
    private Animator animator;  // Animator referansı

    void Start()
    {
        speed = 2f;
        mouseSensitivity = 600f;
        yRotation = 0f;
        controller = GetComponentInChildren<CharacterController>();
        cameraTransform = Camera.main.transform;
        animator = GetComponent<Animator>();  // Animator bileşenini alıyoruz
    }

    void Update()
    {
        // Mouse hareketini al
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        yRotation += mouseX;

        // Karakterin rotasyonunu güncelle
        transform.rotation = Quaternion.Euler(0f, yRotation, 0f);

        // Kamerayı karaktere bağımlı hale getir
        cameraTransform.rotation = Quaternion.Euler(0f, yRotation, 0f);

        // Hareket girişlerini al
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveHorizontal + transform.forward * moveVertical;

        // Hareketi uygula
        controller.Move(move * speed * Time.deltaTime);

        // Eğer hareket ediyorsa, IsWalking parametresini true yap, duruyorsa false yap
        bool isWalking = move.magnitude > 0.1f;  // Eğer hareketin büyüklüğü küçükse, karakter duruyor demektir.

        // Eğer karakter hareket ediyorsa, Idle animasyonunu bypass et ve Walking animasyonuna geç
        if (isWalking && (moveHorizontal != 0 || moveVertical != 0))
        {            
            animator.SetBool("IsWalking", true);  // Hareket başladı, IsWalking true
        }
        else
        {
            animator.StopPlayback();
            animator.SetBool("IsWalking", false);   // Geçiş süresi düşük tutulmalı.
        }
    }
}
