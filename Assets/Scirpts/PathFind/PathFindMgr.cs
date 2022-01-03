using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PathFindMgr
{
    public static List<Voxel> BeginPathFind(Voxel start,Voxel end)
    {
        Voxel startPoint = GridMgr.GetInstance().GetVoxcelByXZ(start.x, start.z);
        Voxel endPoint = GridMgr.GetInstance().GetVoxcelByXZ(end.x, end.z);
        return BreadthFirst.Begin(startPoint, endPoint);
    }
}
