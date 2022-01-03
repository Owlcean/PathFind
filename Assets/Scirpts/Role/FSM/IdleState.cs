using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState:State
{
    private FSMMgr mgr;
    public IdleState(FSMMgr mgr)
    {
        this.mgr = mgr;
    }
    public  void Enter()
    {
        mgr.animator.Play("IDLE");
    }

    public  void HandleInput()
    {

    }

    public  void Update()
    {
    }

    public  void Exit()
    {

    }
}
