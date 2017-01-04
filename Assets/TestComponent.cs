using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nhn_EventSystem;

public class TestComponent : MonoBehaviour {

    bool allowTestAction = false;

	void Start () {
		if (GetComponent<nhn_EventHandler>())
        {
            GetComponent<nhn_EventHandler>().Register(this);
        }
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            allowTestAction = true;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            allowTestAction = false;
    }

    void OnStart_TestAction()
    {
        Debug.Log("OnStart_TestAction");
    }

    bool CanStart_TestAction()
    {
        Debug.Log("CanStart_TestAction return " + allowTestAction);
        return allowTestAction;
    }

    void OnFailStart_TestAction()
    {
        Debug.Log("OnFailStart_TestAction");
    }
}
