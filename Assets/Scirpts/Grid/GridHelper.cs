using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GridHelper
{
    public static Mesh DrawQuad()
    {
        float unitLength = Voxel.gridLength/2;
        float unitWidth = Voxel.gridWidth/2;
        Mesh mesh = new Mesh();
        Vector3[] vertices = new Vector3[4] {
                new Vector3(-unitLength,0,-unitWidth),
                new Vector3(unitLength,0,-unitWidth),

                new Vector3(-unitLength,0,unitWidth),
                new Vector3(unitLength,0,unitWidth),
        };
        Vector3[] normals = new Vector3[4] {
                Vector3.up,
                Vector3.up,
                Vector3.up,
                Vector3.up,
        };
        int[] ibo = new int[] { 3, 0, 2, 3, 1, 0 };// new int[] { 0, 2, 3, 0, 3, 1 };
        mesh.vertices = vertices;
        mesh.triangles = ibo;

        Vector2[] uv = new Vector2[4] {
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(0, 1),
            new Vector2(1, 1),
            
        };
        mesh.uv = uv;
        mesh.name = "yogo";
        mesh.SetNormals(normals);
        return mesh;
    }
}
