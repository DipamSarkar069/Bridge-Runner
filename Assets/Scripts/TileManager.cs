using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    private Transform playerTransform;
    private float spawnZ = 0.0f;
    private float tileLength = 60.0f;
    public int amountOfTiles = 4;
    private int lastPrefabIndex = 0;

    private List<GameObject> activeTiles;

    // Start is called before the first frame update
    void Start()
    {
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; 

        //spawms tiles at the start 
        for(int i =0; i < amountOfTiles; i++)
        {
            if(i < 2)
            {
                SpawnTiles(0);
            }
            else
            {
            SpawnTiles();//calling spawn tiles function
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        //spawning tiles according to the player movement
        if(playerTransform.position.z - 65 > (spawnZ - amountOfTiles*tileLength))
        {
            SpawnTiles();//calling spawn tiles function
            DeleteTile();
        }
    }

    //new function for spawning tiles
    void SpawnTiles(int prefabIndex = -1)
    {
        GameObject go;
        if(prefabIndex == -1)
        {
        go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;//instantiating the tilePrefabs at 0 as Game Object
        }
        else
        {
            go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
        }

        go.transform.SetParent(transform); 
        go.transform.position = Vector3.forward * spawnZ;//spawning tiles in the front
        spawnZ += tileLength;//Spawning according to the given tile length
        activeTiles.Add(go);
    }

    //deletes the previous tiles
   void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);

    }

    //puts random tiles everyting excluding the 1st tile
    private int RandomPrefabIndex()
    {
        if(tilePrefabs.Length <=1 )
        return 0;
        
        int randomIndex = lastPrefabIndex;
        while(randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }

        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
