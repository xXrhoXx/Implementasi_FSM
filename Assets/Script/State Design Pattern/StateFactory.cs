using System.Collections.Generic;
using System;
using UnityEngine;
using System.Reflection;
using System.Linq;

public class StateFactory
{
    public Dictionary<string, Type> _states = new Dictionary<string, Type>();

    public StateFactory()
    {
        var stateType = Assembly.GetAssembly(typeof(BaseState)).GetTypes()
            .Where(thisType => thisType.IsClass && !thisType.IsAbstract && thisType.IsSubclassOf(typeof(BaseState)));

        foreach (var state in stateType)
        {
            //casting, basically the same as (BaseState)Activator.CreateInstance(state)
            var temp = Activator.CreateInstance(state) as BaseState;
            _states.Add(temp.Name, state);
        }
    }

    internal BaseState GetState(string stateName)
    {
        if (_states.ContainsKey(stateName))
        {
            Type stateType = _states[stateName];
            var state = Activator.CreateInstance(stateType) as BaseState;
            return state;
        }

        return null;
    }

    internal IEnumerable<string> GetStateName()
    {
        return _states.Keys;
    }
}