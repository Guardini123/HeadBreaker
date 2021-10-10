using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class StandaloneStartAction : MonoBehaviour
{
    public UnityEvent OnStartStandalone;


    void Start()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        OnStartStandalone?.Invoke();
#endif
    }
}
