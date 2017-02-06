using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nhn_EventSystem;

public class PlayerEventHandler : nhn_EventHandler {

    public nhn_Action TestAction;
    public nhn_Task TestTask;

    protected override void Start()
    {
        base.Start();

        TestTask.maxTaskTime = 1f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            TestAction.TryStart();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            TestTask.TryStart();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            TestTask.TryStop();
        }
    }
}
