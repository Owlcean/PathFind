using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface State
{
    void Update();
    void HandleInput();
    void Enter();
    void Exit();
}
