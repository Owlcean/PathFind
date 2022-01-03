using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RaycastHelper
{
    public static void RayByMouse()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 200))
        {
            Debug.Log(hit.point);
            Vector3 dir = Camera.main.transform.position-hit.point;
            Vector3 dirX = new Vector3(dir.x, 0, 0) + hit.point;
            Vector3 dirY = new Vector3(0, dir.y, 0) + hit.point;
            Vector3 dirZ = new Vector3(0, 0, dir.z) + hit.point;
            Debug.DrawLine(hit.point, dirX, Color.red,3);
            Debug.DrawLine(hit.point, dirY, Color.blue, 3);
            Debug.DrawLine(hit.point, dirZ, Color.yellow, 3);
        }
    }
}
