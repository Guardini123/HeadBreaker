using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class StandaloneTrigger : MonoBehaviour
{
    public UnityEvent OnStandaloneActions;


    public void StandaloneAction()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        OnStandaloneActions?.Invoke();
#endif
    }
}
