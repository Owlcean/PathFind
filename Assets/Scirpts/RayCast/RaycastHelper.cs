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
            Vector3 dir = hit.point-Camera.main.transform.position;
            Vector3 dirX = new Vector3(dir.x, 0, 0) + hit.point;
            Vector3 dirY = new Vector3(0, dir.y, 0) + hit.point;
            Vector3 dirZ = new Vector3(0, 0, dir.z) + hit.point;
            Debug.DrawLine(hit.point, dirX, Color.red,3);
            Debug.DrawLine(hit.point, dirY, Color.blue, 3);
            Debug.DrawLine(hit.point, dirZ, Color.yellow, 3);

            MaxBasic maxBasic = MaxBasic.X;
            MinBasic minBasic = MinBasic.X;
            float maxBasicValue = Mathf.Abs(dir.x);
            float minBasicValue = Mathf.Abs(dir.x);
            if (maxBasicValue < Mathf.Abs(dir.y))
            {
                maxBasicValue = Mathf.Abs(dir.y);
                maxBasic = MaxBasic.Y;
            }
            if (maxBasicValue < Mathf.Abs(dir.z))
            {
                maxBasicValue = Mathf.Abs(dir.z);
                maxBasic = MaxBasic.Z;
            }

            if (minBasicValue > Mathf.Abs(dir.y))
            {
                minBasicValue = Mathf.Abs(dir.y);
                minBasic = MinBasic.Y;
            }
            if (minBasicValue > Mathf.Abs(dir.z))
            {
                minBasicValue = Mathf.Abs(dir.z);
                minBasic = MinBasic.Z;
            }

            switch(minBasic)
            {
                case MinBasic.X:
                    break;
                case MinBasic.Y:
                    break;
                case MinBasic.Z:
                    break;
            }

            switch (maxBasic)
            {
                case MaxBasic.X:
                    break;
                case MaxBasic.Y:
                    break;
                case MaxBasic.Z:
                    break;
            }
        }
    }

    private static void 

    private  enum MaxBasic 
    {
        X,
        Y,
        Z
    }

    private enum MinBasic
    {
        X,
        Y,
        Z
    }
}
