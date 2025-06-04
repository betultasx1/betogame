using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Takip edilecek karakter
    public Vector3 offset;   // Kameran�n hedefe g�re pozisyonu
    public float smoothSpeed = 0.125f; // Takipteki yumu�akl�k

    private void LateUpdate()
    {
        if (target != null)
        {
            // Hedef pozisyonunu hesapla
            Vector3 desiredPosition = target.position + offset;
            // Kameray� yumu�ak bir �ekilde hedef pozisyona hareket ettir
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            // Kameray� hedefe do�ru �evir
            transform.LookAt(target);
        }
    }
}
