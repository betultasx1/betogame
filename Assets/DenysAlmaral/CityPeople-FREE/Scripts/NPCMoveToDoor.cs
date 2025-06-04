using System.Collections;
using System.Collections.Generic;
using uk.vroad.api.sim;
using UnityEngine;


using UnityEngine.AI;



public class NPCMoveToDoor : MonoBehaviour

{
    public string doorName = "Door2"; // Kapýnýn adý
    private Transform door; // Kapýnýn Transform referansý
    private GameObject[] npcs; // Sahnede yer alan NPC'lerin referanslarý

    public bool HasReachedDoor { get; internal set; }

    void Start()
    {
        // Kapýnýn referansýný al
        door = GameObject.Find(doorName)?.transform;

        if (door == null)
        {
            Debug.LogError($"Kapý '{doorName}' bulunamadý!");
            return;
        }

        // Sahnede "NPC" tag'ine sahip tüm karakterleri bul
        npcs = GameObject.FindGameObjectsWithTag("NPC");

        if (npcs.Length == 0)
        {
            Debug.LogError("Sahnede hiçbir NPC bulunamadý!");
            return;
        }

        // Tüm NPC'leri kapýya yönlendir
        foreach (GameObject npc in npcs)
        {
            NavMeshAgent agent = npc.GetComponent<NavMeshAgent>();
            if (agent != null)
            {
                agent.SetDestination(door.position); // Kapýya yönlendir
            }
            else
            {
                Debug.LogWarning($"{npc.name} üzerinde NavMeshAgent bulunamadý!");
            }
        }
    }
}
