using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset; // Kameranýn baþlangýç konumuna göre offset ayarý

    void LateUpdate()
    {
        if (target != null)
        {
            // Kamerayý Player konumuna sabitle, dönmesini engelle
            transform.position = target.position + offset;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}