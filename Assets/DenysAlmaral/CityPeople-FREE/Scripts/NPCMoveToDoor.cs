using System.Collections;
using System.Collections.Generic;
using uk.vroad.api.sim;
using UnityEngine;


using UnityEngine.AI;



public class NPCMoveToDoor : MonoBehaviour

{
    public string doorName = "Door2"; // Kap�n�n ad�
    private Transform door; // Kap�n�n Transform referans�
    private GameObject[] npcs; // Sahnede yer alan NPC'lerin referanslar�

    public bool HasReachedDoor { get; internal set; }

    void Start()
    {
        // Kap�n�n referans�n� al
        door = GameObject.Find(doorName)?.transform;

        if (door == null)
        {
            Debug.LogError($"Kap� '{doorName}' bulunamad�!");
            return;
        }

        // Sahnede "NPC" tag'ine sahip t�m karakterleri bul
        npcs = GameObject.FindGameObjectsWithTag("NPC");

        if (npcs.Length == 0)
        {
            Debug.LogError("Sahnede hi�bir NPC bulunamad�!");
            return;
        }

        // T�m NPC'leri kap�ya y�nlendir
        foreach (GameObject npc in npcs)
        {
            NavMeshAgent agent = npc.GetComponent<NavMeshAgent>();
            if (agent != null)
            {
                agent.SetDestination(door.position); // Kap�ya y�nlendir
            }
            else
            {
                Debug.LogWarning($"{npc.name} �zerinde NavMeshAgent bulunamad�!");
            }
        }
    }
}
