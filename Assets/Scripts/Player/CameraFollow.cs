using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;   // Takip edilecek hedef (karakter)
    public Vector3 offset = new Vector3(0, 2, 2); // Kameranın karakterin arkasında ve biraz yukarıda olması için offset değeri
    public float fixedXRotation = 22f;  // Kameranın sabit X rotasyonu

    void LateUpdate()
    {
        if (target != null)
        {
            // Kamera pozisyonu: Kamera her zaman hedefin arkasında olacak ve biraz yukarıda
            transform.position = target.position - target.forward * offset.z + target.up * offset.y;

            // Kameranın hedefe doğru bakmasını sağla ve X rotasını sabit tut
            Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
            transform.rotation = Quaternion.Euler(fixedXRotation, targetRotation.eulerAngles.y, 0f); // Y ekseninde dönüşe izin veriyoruz
        }
    }
}
