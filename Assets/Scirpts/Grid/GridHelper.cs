using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GridHelper
{
    public static Mesh DrawQuad()
    {
        Mesh mesh = new Mesh();
        Vector3[] vertices = new Vector3[4] {
                new Vector3(-1,0,-1),
                new Vector3(1,0,-1),

                new Vector3(-1,0,1),
                new Vector3(1,0,1),
        };
        int[] ibo = new int[] { 0, 2, 3, 0, 3, 1 };
        mesh.vertices = vertices;
        mesh.triangles = ibo;

        Vector2[] uv = new Vector2[4] {
            new Vector2(1, 1),
            new Vector2(0, 1),
            new Vector2(1, 0),
            new Vector2(0, 0)
        };
        mesh.uv = uv;
        return mesh;
    }
}
