using UnityEngine;

public class GenerateTerrainBlocks : MonoBehaviour
{
    // Need reference to Terrain Data for accessing heightmap data
    public Terrain terrainObj;
    public TerrainData heightmapData;

    // reference to a block prefab
    public GameObject blockPrefab;


    void Start()
    {
        heightmapData = terrainObj.terrainData;
    }

    void Update()
    {

    }
}
