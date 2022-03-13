using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSpawning : MonoBehaviour
{
    public GameObject spawn;
    public GameObject npcPrefab;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Transform spawnPoint3;

    public static bool isOnPoint = false;

    private static bool idOnTriger;

    private void Start()
    {
        idOnTriger = false;
    }

    private void Update()
    {
        if (isOnPoint == true && idOnTriger == true)
        {
            Spawning();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            idOnTriger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            idOnTriger = false;
            spawn.SetActive(false);
        }
    }

    public void Spawning()
    {
        Instantiate(npcPrefab, spawnPoint1.position, Quaternion.identity);
        Instantiate(npcPrefab, spawnPoint2.position, Quaternion.identity);
        Instantiate(npcPrefab, spawnPoint3.position, Quaternion.identity);

        PlayerShooting.numNPC = 3;

        isOnPoint = false;
    }
}
