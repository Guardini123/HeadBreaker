using System.Collections;
using UnityEngine;
using UnityEngine.Events;


public class UpdateTrigger : MonoBehaviour
{
    public UnityEvent OnUpdateActions;


    void Update()
    {
        OnUpdateActions?.Invoke();
    }
}