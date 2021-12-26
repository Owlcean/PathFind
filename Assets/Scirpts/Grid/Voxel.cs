using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voxel 
{
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
        go = GameObject.Instantiate(gridAsset, new Vector3(this.x, 0, this.z), Quaternion.identity, parent);
    }
    public void SetReachable(bool reachable)
    {
        this.reachable = reachable;
    }
    public void SetHasReached(bool hasReached)
    {
        this.hasReached = hasReached;
    }
}
