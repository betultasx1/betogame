using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject selectedCharacterPrefab; // Se�ilen karakterin prefab'i

    void Awake()
    {
        // E�er Instance zaten varsa, bu GameObject'i yok et
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Sahne de�i�se bile GameManager yok edilmez
        }
        else
        {
            Destroy(gameObject); // E�er Instance zaten varsa, eski nesneyi yok et
        }
    }

    // Se�ilen karakteri kaydet
    public void SetPlayerCharacter(GameObject characterPrefab)
    {
        selectedCharacterPrefab = characterPrefab;
        Debug.Log($"{characterPrefab.name} oyuncu olarak se�ildi.");
    }
}
