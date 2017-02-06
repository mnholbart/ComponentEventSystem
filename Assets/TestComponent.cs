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

        if (Input.GetKeyDown(KeyCode.K))
        {
            GetComponent<nhn_EventHandler>().Unregister(this);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            GetComponent<nhn_EventHandler>().Register(this);
        }
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

    bool CanStart_TestTask()
    {
        Debug.Log("CanStart_TestTask");
        return true;
    }

    void OnStart_TestTask()
    {
        Debug.Log("OnStart_TestTask");
    }

    void OnStop_TestTask()
    {
        Debug.Log("OnStop_TestTask");
    }

    bool CanStop_TestTask()
    {
        Debug.Log("CanStop_TestTask");
        return true;
    }
    

}
