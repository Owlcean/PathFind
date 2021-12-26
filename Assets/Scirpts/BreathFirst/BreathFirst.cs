using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BreathFirst
{
    private static Queue<Voxel> frontier;
    private static Dictionary<Voxel, Voxel> came_from;
    public static List<Voxel> Begin(Voxel startPoint, Voxel endPoint)
    {
        came_from = new Dictionary<Voxel, Voxel>();
        frontier.Enqueue(startPoint);
        while (frontier.Count != 0)
        {
            Voxel currentGrid = frontier.Dequeue();
            List<Voxel>neighbours = GridMgr.GetInstance().GetNeighbour(currentGrid.x, currentGrid.z);
            foreach (Voxel item in neighbours)
            {
                if (!came_from.ContainsKey(item))
                {
                    came_from[item] = currentGrid;
                    frontier.Enqueue(item);
                }
            }
        }
        List<Voxel> outputPath = new List<Voxel>();
        Voxel point = endPoint;
        outputPath.Add(point);
        while (!point.CheckEqual(startPoint))
        {
            point = came_from[point];
            outputPath.Add(point);
        }
        outputPath.Reverse();
        return outputPath;
    }
}
