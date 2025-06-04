using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    public GameObject[] characterPrefabs;   // Inspector’dan atayacaðýz
    public Transform spawnPoint;            // Karakterin doðacaðý yer

    void Start()
    {
        int selectedIndex = PlayerPrefs.GetInt("SelectedCharacter", 0); // Default: 0
        GameObject character = Instantiate(characterPrefabs[selectedIndex], spawnPoint.position, spawnPoint.rotation);

        // Kamera varsa target olarak ata
        ThirdPersonCamera cam = Camera.main.GetComponent<ThirdPersonCamera>();
        if (cam != null)
        {
            cam.target = character.transform;
        }
    }
}
