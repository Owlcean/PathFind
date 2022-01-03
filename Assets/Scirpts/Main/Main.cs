using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public GameObject gridPrefab;
    public GameObject gridRoot;
    public GameObject role;
    private RoleMgr roleMgr;
    private FSMMgr roleFSM;
    private bool isWalking = false;
    // Start is called before the first frame update
    void Start()
    {
        gridPrefab.GetComponent<MeshFilter>().mesh = GridHelper.DrawQuad();
        GridMgr.GetInstance().GenGrids(20,20,gridPrefab, gridRoot.transform);
        GridMgr.GetInstance().SetStartPoint(0, 0);
        GridMgr.GetInstance().SetEndPoint(19, 19);
        if (GetComponent<BoxCollider>() == null)
        {
            gameObject.AddComponent<BoxCollider>();
        }
        BoxCollider box = GetComponent<BoxCollider>();
        box.size = new Vector3(GridData.GetInstance().GetLength()* Voxel.gridLength, 1,GridData.GetInstance().GetWidth()* Voxel.gridWidth);
        box.center = new Vector3((GridData.GetInstance().GetLength() * Voxel.gridLength / 2)-(Voxel.gridLength/2),0,(GridData.GetInstance().GetWidth() * Voxel.gridWidth / 2)-(Voxel.gridWidth/2));
        roleFSM = new FSMMgr(role.GetComponent<Animator>());
        roleFSM.SetState(new IdleState(roleFSM));
    }


    // Update is called once per frame
    void Update()
    {
        roleFSM.Update();
        if (Input.GetKeyDown(KeyCode.Space)&& isWalking==false)
        {
            WalkPath(PathFindMgr.BeginPathFind(GridMgr.GetInstance().GetStartPoint(), GridMgr.GetInstance().GetEndPoint()));
            isWalking = true;
        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHelper.RayByMouse();
        }
    }

    public void WalkPath(List<Voxel> pointList)
    {
        roleFSM.SetState(new StraightWalkState(roleFSM));
        StartCoroutine(WalkSingleVoxel2(pointList).GetEnumerator());
    }


    IEnumerable WalkSingleVoxel2(List<Voxel> pointList)
    {
        for (int i = 0; i < pointList.Count; i++)
        {
            Voxel voxel = pointList[i];
            Vector3 dest = new Vector3(voxel.x*Voxel.gridLength, 0, voxel.z * Voxel.gridWidth);
            role.transform.LookAt(dest);
            Vector3 translateV3 = dest - role.transform.position;
            role.transform.Translate(translateV3, Space.World);
            yield return new WaitForSeconds(0.1f);
        }
        isWalking = false;
        roleFSM.SetState(new IdleState(roleFSM));
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject);
    }
}
