using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelGenerator1 : MonoBehaviour
{

    private const int PLAYER_DISTANCE_SPAWN_LEVEL_PART = 200;

    [SerializeField] private Transform levelPartStart;
    [SerializeField] private List<Transform> levelPartList;
    [SerializeField] private GameObject player;

    private Vector3 lastEndPosition;

    private void Awake()
    {
        lastEndPosition = levelPartStart.Find("EndPosition").position;

        int startingSpawnLevelParts = 5;
        for (int i = 0; i < startingSpawnLevelParts; i++)
        {
            SpawnLevelPart();
        }
    }
    
    void Update()
    {
        if (Vector3.Distance(player.transform.position, lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
        {
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart()
    {
        try
        {
            lastEndPosition = new Vector3(lastEndPosition.x + 0.5f, lastEndPosition.y, lastEndPosition.z);
            Transform chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
            Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
            lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
        }
        catch (Exception e)
        {
            // Do nothing
        }
        
    }

    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        return Instantiate(levelPart, spawnPosition, Quaternion.identity);
    }
}
