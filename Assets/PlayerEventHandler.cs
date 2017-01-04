using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nhn_EventSystem;

public class PlayerEventHandler : nhn_EventHandler {

    public nhn_Action TestAction;

    protected override void Start()
    {
        base.Start();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            TestAction.TryStart();
        }
    }
}
