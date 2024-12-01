using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 5f; // Hareket h�z�
    private CharacterController controller;
    private float mouseSensitivity = 100f; // Mouse hassasiyeti
    private float yRotation = 0f; // Y ekseni rotasyonu
    private Transform cameraTransform; // Kamera d�n��� i�in

    void Start()
    {
        controller = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform; // Ana kameray� al
    }

    void Update()
    {
        // Mouse hareketine g�re karakterin rotasyonunu ayarla
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        yRotation += mouseX;

        // Karakteri yaln�zca y ekseninde d�nd�r
        transform.rotation = Quaternion.Euler(0f, yRotation, 0f);

        // Kamera i�in rotasyonu uygula
        cameraTransform.rotation = Quaternion.Euler(cameraTransform.rotation.eulerAngles.x, yRotation, 0f);

        // Klavye girdileri ile hareket et
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Hareket y�n�n� mouse y�n�ne g�re ayarla
        Vector3 move = transform.right * moveHorizontal + transform.forward * moveVertical;

        // Hareketi uygula
        controller.Move(move * speed * Time.deltaTime);
    }
}
