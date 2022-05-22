using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] glyphPrefabs;
    float spawnDelay = 2;
    float spawnInterval;
    float spawnPosX = 12;
    int posY1 = 4;
    int posY2 = 2;
    int posY3 = 0;
    int posY4 = -2;
    int posY5 = -4;

    // Start is called before the first frame update
    void Start()
    {
        spawnInterval = 2;
        InvokeRepeating("SpawnObject", spawnDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObject()
        {
        int glyphIndex = Random.Range(0, glyphPrefabs.Length);
        Vector2 spawnPos1 = new Vector3(spawnPosX, posY1, 0);
        Instantiate(glyphPrefabs[glyphIndex], spawnPos1, glyphPrefabs[glyphIndex].transform.rotation);

        int glyphIndex2 = Random.Range(0, glyphPrefabs.Length);
        Vector2 spawnPos2 = new Vector3(spawnPosX, posY2, 0);
        Instantiate(glyphPrefabs[glyphIndex2], spawnPos2, glyphPrefabs[glyphIndex2].transform.rotation);

        int glyphIndex3 = Random.Range(0, glyphPrefabs.Length);
        Vector2 spawnPos3 = new Vector3(spawnPosX, posY3, 0);
        Instantiate(glyphPrefabs[glyphIndex3], spawnPos3, glyphPrefabs[glyphIndex3].transform.rotation);

        int glyphIndex4 = Random.Range(0, glyphPrefabs.Length);
        Vector2 spawnPos4 = new Vector3(spawnPosX, posY4, 0);
        Instantiate(glyphPrefabs[glyphIndex4], spawnPos4, glyphPrefabs[glyphIndex4].transform.rotation);

        int glyphIndex5 = Random.Range(0, glyphPrefabs.Length);
        Vector2 spawnPos5 = new Vector3(spawnPosX, posY5, 0);
        Instantiate(glyphPrefabs[glyphIndex5], spawnPos5, glyphPrefabs[glyphIndex5].transform.rotation);


        }
    }
