using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RandomSpawn : MonoBehaviour
{
    public static int[] greenIndex = { 0, 1, 0, 0, 0 };
    public static int[] blueIndex = { 2, 5, 5, 3, 5, 4, 5, 5, 6, 5, 5 };
    public static int[] redIndex = { 8, 7, 8, 11, 13, 9, 11, 8, 13, 11, 10, 8, 11, 13, 11, 8, 12, 8, 11, 13, 8, 11 };
    public static int[] grassIndex = { 14, 15, 14, 14, 14, 15, 14, 14, 14, 14, 15, 14, 14, 14, 15, 14 };
    public static int maskIndex = 2;
    public static int grassMaskIndex = 3;
    public static int maxGreen = 7000;
    public static int maxBlue = 800;
    public static int maxRed = 300;
    public static int maxGrass = 9999;

    [MenuItem("Terrain/ Create Terrain Green")]
    public static void CreateTreesOnAllTerrainsGreen()
    {
        foreach (Terrain terrain in Terrain.activeTerrains)
        {
            CreateTreeOnTerrainGreen(terrain);
        }
    }

    [MenuItem("Terrain/ Create Terrain Blue")]
    public static void CreateTreesOnAllTerrainsBlue()
    {
        foreach (Terrain terrain in Terrain.activeTerrains)
        {
            CreateTreeOnTerrainBlue(terrain);
        }
    }

    [MenuItem("Terrain/ Create Terrain Red")]
    public static void CreateTreesOnAllTerrainsRed()
    {
        foreach (Terrain terrain in Terrain.activeTerrains)
        {
            CreateTreeOnTerrainRed(terrain);
        }
    }

    [MenuItem("Terrain/ Create Terrain Grass")]
    public static void CreateGrassOnAllTerrainsRed()
    {
        foreach (Terrain terrain in Terrain.activeTerrains)
        {
            CreateGrassOnTerrainGreen(terrain);
        }
    }

    [MenuItem("Terrain/ Clear")]
    public static void CleanTAllerrainTrees()
    {
        foreach (Terrain terrain in Terrain.activeTerrains)
        {
            List<TreeInstance> trees = new List<TreeInstance>();
            terrain.terrainData.SetTreeInstances(trees.ToArray(), true);
        }
    }

    public static void CreateTreeOnTerrainGreen(Terrain terrain)
    {
        try
        {
            Texture2D mask = terrain.terrainData.terrainLayers[maskIndex].diffuseTexture;
            List<TreeInstance> trees = new List<TreeInstance>();
            int treesSpawn = maxGreen;
            while (trees.Count < treesSpawn)
            {
                try
                {
                    Vector3 pos = new Vector3(Random.Range(0.0f, 1.0f), 0, Random.Range(0.0f, 1.0f));
                    Color pixelMask = mask.GetPixelBilinear(pos.x, pos.z);
                    if (pixelMask.g > 0.9f)
                    {
                        TreeInstance tree = new TreeInstance();
                        float h = Random.Range(0.8f, 1.2f);
                        tree.heightScale = h;
                        tree.widthScale = h * Random.Range(0.8f, 1.2f);
                        tree.prototypeIndex = greenIndex[Random.Range(0, greenIndex.Length)];
                        tree.color = Color.white;
                        tree.lightmapColor = Color.white;
                        tree.rotation = Random.Range(0, 360.0f);
                        tree.position = pos;
                        trees.Add(tree);
                    }
                }
                catch (UnityException err)
                {
                    Debug.Log(err.Message);
                    break;
                }
            }
            trees.AddRange(terrain.terrainData.treeInstances);
            terrain.terrainData.SetTreeInstances(trees.ToArray(), true);
            return;
        }
        catch (UnityException err)
        {
            Debug.Log(err.Message);
            return;
        }
    }

    public static void CreateTreeOnTerrainBlue(Terrain terrain)
    {
        try
        {
            Texture2D mask = terrain.terrainData.terrainLayers[maskIndex].diffuseTexture;
            List<TreeInstance> trees = new List<TreeInstance>();
            int treesSpawn = maxBlue;
            while (trees.Count < treesSpawn)
            {
                try
                {
                    Vector3 pos = new Vector3(Random.Range(0.0f, 1.0f), 0, Random.Range(0.0f, 1.0f));
                    Color pixelMask = mask.GetPixelBilinear(pos.x, pos.z);
                    if (pixelMask.b > 0.9f)
                    {
                        TreeInstance tree = new TreeInstance();
                        float h = Random.Range(0.8f, 1.2f);
                        tree.heightScale = h;
                        tree.widthScale = h * Random.Range(0.8f, 1.2f);
                        tree.prototypeIndex = blueIndex[Random.Range(0, blueIndex.Length)];
                        tree.color = Color.white;
                        tree.lightmapColor = Color.white;
                        tree.rotation = Random.Range(0, 360.0f);
                        tree.position = pos;
                        trees.Add(tree);
                    }
                }
                catch (UnityException err)
                {
                    Debug.Log(err.Message);
                    break;
                }
            }
            trees.AddRange(terrain.terrainData.treeInstances);
            terrain.terrainData.SetTreeInstances(trees.ToArray(), true);
            return;
        }
        catch (UnityException err)
        {
            Debug.Log(err.Message);
            return;
        }
    }

    public static void CreateTreeOnTerrainRed(Terrain terrain)
    {
        try
        {
            Texture2D mask = terrain.terrainData.terrainLayers[maskIndex].diffuseTexture;
            List<TreeInstance> trees = new List<TreeInstance>();
            int treesSpawn = maxRed;
            while (trees.Count < treesSpawn)
            {
                try
                {
                    Vector3 pos = new Vector3(Random.Range(0.0f, 1.0f), 0, Random.Range(0.0f, 1.0f));
                    Color pixelMask = mask.GetPixelBilinear(pos.x, pos.z);
                    if (pixelMask.r > 0.9f)
                    {
                        TreeInstance tree = new TreeInstance();
                        float h = Random.Range(0.8f, 1.2f);
                        tree.heightScale = h;
                        tree.widthScale = h * Random.Range(0.8f, 1.2f);
                        tree.prototypeIndex = redIndex[Random.Range(0, redIndex.Length)];
                        tree.color = Color.white;
                        tree.lightmapColor = Color.white;
                        tree.rotation = Random.Range(0, 360.0f);
                        tree.position = pos;
                        trees.Add(tree);
                    }
                }
                catch (UnityException err)
                {
                    Debug.Log(err.Message);
                    break;
                }
            }
            trees.AddRange(terrain.terrainData.treeInstances);
            terrain.terrainData.SetTreeInstances(trees.ToArray(), true);
            return;
        }
        catch (UnityException err)
        {
            Debug.Log(err.Message);
            return;
        }
    }

    public static void CreateGrassOnTerrainGreen(Terrain terrain)
    {
        try
        {
            Texture2D mask = terrain.terrainData.terrainLayers[grassMaskIndex].diffuseTexture;
            List<TreeInstance> trees = new List<TreeInstance>();
            int treesSpawn = maxGrass;
            while (trees.Count < treesSpawn)
            {
                try
                {
                    Vector3 pos = new Vector3(Random.Range(0.0f, 1.0f), 0, Random.Range(0.0f, 1.0f));
                    Color pixelMask = mask.GetPixelBilinear(pos.x, pos.z);
                    if (pixelMask.g > 0.9f)
                    {
                        TreeInstance tree = new TreeInstance();
                        float h = Random.Range(0.8f, 1.2f);
                        tree.heightScale = h;
                        tree.widthScale = h * Random.Range(0.8f, 1.2f);
                        tree.prototypeIndex = grassIndex[Random.Range(0, grassIndex.Length)];
                        tree.color = Color.white;
                        tree.lightmapColor = Color.white;
                        tree.rotation = Random.Range(0, 360.0f);
                        tree.position = pos;
                        trees.Add(tree);
                    }
                }
                catch (UnityException err)
                {
                    Debug.Log(err.Message);
                    break;
                }
            }
            trees.AddRange(terrain.terrainData.treeInstances);
            terrain.terrainData.SetTreeInstances(trees.ToArray(), true);
            return;
        }
        catch (UnityException err)
        {
            Debug.Log(err.Message);
            return;
        }
    }
}
