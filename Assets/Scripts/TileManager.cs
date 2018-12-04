using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {
    public GameObject[] tilePrefabs;

    private Transform player;

    private float spawnZ = -5f;
    private float tileLength = 12;
    private int amountOfTilesOnScreen = 5;
    private float safezone = 15f;
    private int lastIndex = 0;

    private List<GameObject> activeTiles;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        activeTiles = new List<GameObject>();

        for (int i = 0; i < amountOfTilesOnScreen; i++)
            SpawnTiles(0);
    }

    private void Update()
    {
        if(player.position.z - safezone > (spawnZ - amountOfTilesOnScreen * tileLength))
        {
            SpawnTiles(RandomIndex());
            DeleteTiles();
        }
    }

    private void SpawnTiles(int index = -1) {
        GameObject go = Instantiate(tilePrefabs[index],transform.position, Quaternion.identity) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(go);
    }

    private int RandomIndex() {
        if (tilePrefabs.Length <= 1)
            return 0;
        int randomIndex = lastIndex;
        while (randomIndex == lastIndex) {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }
        lastIndex = randomIndex;
        return randomIndex;
    }

    private void DeleteTiles() {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
