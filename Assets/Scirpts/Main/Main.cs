using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public GameObject gridPrefab;


    // Start is called before the first frame update
    void Start()
    {
        gridPrefab.GetComponent<MeshFilter>().mesh = GridHelper.DrawQuad();
        GridMgr.GetInstance().GenGrids(20,20,gridPrefab,transform);
        PathFindMgr.BeginPathFind(0, 0, 19, 19);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
