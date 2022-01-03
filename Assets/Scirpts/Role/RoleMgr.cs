using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleMgr : MonoBehaviour
{
    // [RequireComponent(typeof(Animator))]
    private FSMMgr roleFSM;
    private List<Voxel> pointList;
    void Start()
    {
        roleFSM = new FSMMgr(GetComponent<Animator>());
        roleFSM.SetState(new IdleState(roleFSM));
    }

    // Update is called once per frame
    void Update()
    {
        roleFSM.Update();
    }

    public void WalkPath(List<Voxel> pointList)
    {
        this.pointList = pointList;
        roleFSM.SetState(new StraightWalkState(roleFSM));
        StartCoroutine("WalkSingleVoxel");

    }

    IEnumerable WalkSingleVoxel()
    {
        foreach (Voxel voxel in pointList)
        {
            transform.Translate(new Vector3Int(voxel.x, 0, voxel.z));
            yield return null;
        }
    }
}
