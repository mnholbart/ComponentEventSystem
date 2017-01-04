using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace nhn_EventSystem
{
    /// <summary>
    /// An action is a one time activated event that implements callbacks for failing/succeeding to start
    /// and conditions for starting
    /// </summary>
    public class nhn_Action : nhn_Event
    {
        //List<nhn_Delegate> delegates = new List<nhn_Delegate>();

        public nhn_Action(string name) : base(name)
        {
            EventTypes.Add(nhn_EventHandler.GetEventTypeFromName("OnStart"));
            EventTypes.Add(nhn_EventHandler.GetEventTypeFromName("OnFailStart"));
            EventTypes.Add(nhn_EventHandler.GetEventTypeFromName("CanStart"));
            InitializeCallbacks();
        }

        public override void Register(object target, string methodName, string prefixName)
        {
            nhn_Delegate d = null;
            delegates.TryGetValue(prefixName, out d);

            if (d == null)
                return;

            //todo: Verify methods before adding

            d.AddMethod(target, methodName);
        }

        public virtual void TryStart()
        {
            foreach (nhn_Delegate.EventCondition d in delegates["CanStart"].MyEventCondition.GetInvocationList())
            {
                if (!d.Invoke())
                {
                    delegates["OnFailStart"].MyEventCallback.Invoke();
                    return;
                }
            }

            delegates["OnStart"].MyEventCallback.Invoke();
        }
    }
}