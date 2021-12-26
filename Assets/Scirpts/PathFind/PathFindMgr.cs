using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PathFindMgr
{
    public static void BeginPathFind(int startX, int startY, int endX, int endY)
    {
        Voxel startPoint = GridMgr.GetInstance().GetVoxcelByXZ(startX, startY);
        Voxel endPoint = GridMgr.GetInstance().GetVoxcelByXZ(endX, endY);
        BreathFirst.Begin(startPoint, endPoint);
    }
}
