using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridData
{
    private static GridData _instance;
    private Voxel startPoint;
    private Voxel endPoint;
    public static GridData GetInstance()
    {
        if (_instance == null) _instance = new GridData();
        return _instance;
    }

    private Voxel[] voxels;
    int len, width;
    public void SetupGridData(int len,int width)
    {
        voxels = new Voxel[len * width];
        this.len = len;
        this.width = width;
    }
    public void GenVoxelEntity(int x, int z, GameObject gridAsset, Transform parent)
    {
        int index = z * len + x;
        voxels[index] = new Voxel(x, z, gridAsset, parent);
        if (Random.Range(1, 99) > 90)
        {
            voxels[index].SetUnReachable();
        }
        else
        {
            voxels[index].SetReachable();
        }
    }
    public void SetStartPoint(int x,int z)
    {
        int index = z * len + x;
        startPoint = voxels[index];
        voxels[index].SetReachable();
        voxels[index].SetColor(Color.yellow);
    }
    public Voxel GetStartPoint()
    {
        return startPoint;
    }

    public void SetEndPoint(int x, int z)
    {
        int index = z * len + x;
        endPoint = voxels[index];
        voxels[index].SetReachable();
        voxels[index].SetColor(Color.yellow);
    }
    public Voxel GetEndPoint()
    {
        return endPoint;
    }

    public Voxel GetVoxcelByXZ(int x, int z)
    {
        int index = z * len + x;
        return voxels[index];
    }
    private bool CheckXZIsInBoundary(int x, int z)
    {
        return x >= 0 && x <= len - 1 && z >= 0 && z <= width - 1;
    }

    public List<Voxel> GetNeighbour(int x, int z)
    {
        List<Voxel> neighbours = new List<Voxel>();
        if (CheckXZIsInBoundary(x - 1, z))
        {
            neighbours.Add(GetVoxcelByXZ(x - 1, z));
        }
        if (CheckXZIsInBoundary(x + 1, z))
        {
            neighbours.Add(GetVoxcelByXZ(x + 1, z));
        }
        if (CheckXZIsInBoundary(x, z - 1))
        {
            neighbours.Add(GetVoxcelByXZ(x, z - 1));
        }
        if (CheckXZIsInBoundary(x, z + 1))
        {
            neighbours.Add(GetVoxcelByXZ(x, z + 1));
        }
        return neighbours;
    }

    public int GetLength()
    {
        return len;
    }

    public int GetWidth()
    {
        return width;
    }
}
