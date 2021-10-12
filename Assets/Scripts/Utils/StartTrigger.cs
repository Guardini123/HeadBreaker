using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class StartTrigger : MonoBehaviour
{
    public UnityEvent OnStartActions;


    void Start()
    {
        OnStartActions?.Invoke();
    }
}
