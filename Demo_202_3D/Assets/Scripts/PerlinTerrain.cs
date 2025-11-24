using UnityEngine;


/// <summary>
/// Used to set the height of every vertex in the heightmap of a Terrain object.
/// </summary>
public class PerlinTerrain : MonoBehaviour
{
    // Terrain reference for setting/getting heights
    public Terrain terrainObj;


    void Start()
    {
        SetTerrainHeight();
    }

    void Update()
    {
        
    }

    public void SetTerrainHeight()
    {
        // Grab the Terrain's resolution (number of vertices along an edge)
        int heightmapRes = terrainObj.terrainData.heightmapResolution;

        // Need an array the size of the Terrain
        float[,] heightData = new float[heightmapRes, heightmapRes];

        // Set the height value of every vertex to 1.
        float timeStep = 0.005f;
        float xAxis = 0;
        float yAxis = 0;

        for(int r = 0; r < heightmapRes; r++)
        {
            // "Row" of heightmap data
            for(int c = 0; c < heightmapRes; c++)
            {
                // Set a small randomized calue for each vertex in the mesh (too random!
                //heightData[r, c] = Random.Range(0f, 0.02f);

                // PLAY AROUND TO DETERMINE PERLIN NOISE VALUES FOR EACH HEIGHT DATA
                float heightValue = Mathf.PerlinNoise(xAxis, yAxis);   // <-- Won't work for us
                heightData[r, c] = heightValue;
                //Debug.Log(heightValue);

                xAxis += timeStep;
            }

            xAxis = 0;
            yAxis += timeStep;
        }

        // Put this data into the Terrain with SetHeights
        terrainObj.terrainData.SetHeights(0, 0, heightData);
    }
}
