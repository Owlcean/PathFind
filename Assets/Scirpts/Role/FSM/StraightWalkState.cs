using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightWalkState : State
{
    private FSMMgr mgr;
    public StraightWalkState(FSMMgr mgr)
    {
        this.mgr = mgr;
    }
    public void Enter()
    {
        mgr.animator.Play("WALK");
    }

    public void HandleInput()
    {

    }

    public void Update()
    {
    }

    public void Exit()
    {

    }
}
