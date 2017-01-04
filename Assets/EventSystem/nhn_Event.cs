using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace nhn_EventSystem {

    /// <summary>
    /// A base class for an event handled by the nhn_EventHandler, extend it to implement custom
    /// events with specific callbacks and constraints
    /// </summary>
    public abstract class nhn_Event {

        public string EventName;
        protected List<nhn_EventType> EventTypes = new List<nhn_EventType>();
        protected Dictionary<string, nhn_Delegate> delegates = new Dictionary<string, nhn_Delegate>();

        public nhn_Event(string name = "")
        {
            EventName = name;
        }

        protected virtual void InitializeCallbacks()
        {
            if (EventTypes == null || EventTypes.Count == 0)
                return;

            foreach (nhn_EventType i in EventTypes)
            {
                delegates.Add(i.EventPrefix, new nhn_Delegate(i.DelegateType));
            }
        }

        public abstract void Register(object target, string methodName, string prefixName);
        //Todo: Unregister function
    }
}