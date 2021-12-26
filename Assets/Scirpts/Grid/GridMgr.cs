using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMgr
{
    private static GridMgr _instance;
    public static GridMgr GetInstance()
    {
        if (_instance == null) _instance = new GridMgr();
        return _instance;
    }

    public void GenGrids(int len,int width,GameObject gridAsset,Transform parent)
    {
        GridData.GetInstance().SetupGridData(len, width);
        for (int i = 0; i < len; i++)
            for (int j = 0; j < len; j++)
                GridData.GetInstance().GenVoxelEntity(i, j, gridAsset, parent);
    }

    public Voxel GetVoxcelByXZ(int x, int z)
    {
        return GridData.GetInstance().GetVoxcelByXZ(x, z);
    }
    public List<Voxel> GetNeighbour(int x, int z)
    {
        return GridData.GetInstance().GetNeighbour(x, z);
    }
}
