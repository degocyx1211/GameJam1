using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;

    public GameObject NPCPrefab;
   

    private float spawnRangeX = 4;
    private float spawnZMin = -8; // set min spawn Z
    private float spawnZMax = 1; // set max spawn Z

    public int NPCCount;
    public int waveCount = 1;

    private void Awake()
    {
        instance = this;
    }


    // Generate random spawn position for powerups and enemy balls
    Vector3 GenerateSpawnPosition()
    {
        float xPos = Random.Range(-spawnRangeX, spawnRangeX);
        float zPos = Random.Range(spawnZMin, spawnZMax);
        return new Vector3(xPos, 0, zPos);
    }


    public void SpawnNPCWave()
    {
        // Spawn number of enemy balls based on wave number
        for (int i = 0; i < waveCount; i++)
        {
            //Instancia de otra clase
            GameObject NPC = Instantiate(NPCPrefab, GenerateSpawnPosition(), NPCPrefab.transform.rotation);
           
        }

        waveCount++;
       
    }
  
}
