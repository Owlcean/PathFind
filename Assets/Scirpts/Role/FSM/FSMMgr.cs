using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMMgr
{
    public Animator animator;
    private  State currentState;
    private Dictionary<string, State> stateList = new Dictionary<string, State>();
    public FSMMgr(Animator animator)
    {
        this.animator = animator;
    }
    public  void SetState(State state)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }
        currentState = state;
        currentState.Enter();
    }

    public  void Update()
    {
        if (currentState != null)
        {
            currentState.Update();
        }
    }

    //public void AddState(State state)
    //{
    //    stateList.Add(state.stateName, state);
    //}
}
