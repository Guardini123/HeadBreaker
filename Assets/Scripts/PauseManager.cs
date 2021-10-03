using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public static PauseManager pauseManager { get; private set; }

    public delegate void PauseAction(bool flag);
    public event PauseAction pause;

    private void Awake()
    {
        pauseManager = this;
    }

    private void Start()
    {

    }

    public void StopTime()
    {
        pause?.Invoke(true);
    }

    public void ContinueTime()
    {
        pause?.Invoke(false);
    }
}
