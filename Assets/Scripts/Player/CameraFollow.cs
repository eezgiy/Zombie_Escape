using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset; // Kameran�n ba�lang�� konumuna g�re offset ayar�

    void LateUpdate()
    {
        if (target != null)
        {
            // Kameray� Player konumuna sabitle, d�nmesini engelle
            transform.position = target.position + offset;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}