using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voxel 
{
    public static float gridLength { get { return 2.0f; } }
    public static float gridWidth { get { return 1.0f; } }
    public static float gridHeight { get { return 1.0f; } }
    public int x, z;
    public bool reachable;
    public bool hasReached;
    public GameObject go;
    public bool CheckEqual(Voxel voxel)
    {
        return x == voxel.x && z == voxel.z;
    }
    private enum WalkCost
    {
        Plane = 1,
        Forest = 2,
    }
    public Voxel(int x,int z,GameObject gridAsset,Transform parent)
    {
        this.x = x;
        this.z = z;
        go = GameObject.Instantiate(gridAsset, new Vector3(this.x* gridLength, 0* gridWidth, this.z* gridWidth), Quaternion.identity, parent);
    }
    public void SetReachable(bool reachable)
    {
        this.reachable = reachable;
    }
    public void SetHasReached(bool hasReached)
    {
        this.hasReached = hasReached;
    }
    public void SetUnReachable()
    {
        reachable = false;
        go.GetComponent<MeshRenderer>().material.color = Color.red;
    }
    public void SetReachable()
    {
        reachable = true;
        go.GetComponent<MeshRenderer>().material.color = Color.green;
    }
    public void SetColor(Color color)
    {
        go.GetComponent<MeshRenderer>().material.color = color;
    }
}
