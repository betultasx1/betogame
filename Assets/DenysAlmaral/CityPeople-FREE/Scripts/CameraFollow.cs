using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Takip edilecek karakter
    public Vector3 offset;   // Kameranýn hedefe göre pozisyonu
    public float smoothSpeed = 0.125f; // Takipteki yumuþaklýk

    private void LateUpdate()
    {
        if (target != null)
        {
            // Hedef pozisyonunu hesapla
            Vector3 desiredPosition = target.position + offset;
            // Kamerayý yumuþak bir þekilde hedef pozisyona hareket ettir
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            // Kamerayý hedefe doðru çevir
            transform.LookAt(target);
        }
    }
}
