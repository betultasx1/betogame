using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject selectedCharacterPrefab; // Seçilen karakterin prefab'i

    void Awake()
    {
        // Eðer Instance zaten varsa, bu GameObject'i yok et
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Sahne deðiþse bile GameManager yok edilmez
        }
        else
        {
            Destroy(gameObject); // Eðer Instance zaten varsa, eski nesneyi yok et
        }
    }

    // Seçilen karakteri kaydet
    public void SetPlayerCharacter(GameObject characterPrefab)
    {
        selectedCharacterPrefab = characterPrefab;
        Debug.Log($"{characterPrefab.name} oyuncu olarak seçildi.");
    }
}
