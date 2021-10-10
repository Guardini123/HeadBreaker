using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioListener audioListener;
    private bool audioOn;
    public static AudioManager audioManager { get; private set; }

    private void Awake()
    {
        audioManager = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        audioListener = this.gameObject.GetComponent<AudioListener>();
        audioOn = true;
    }

    /// <summary>
    /// Switch audio on or off.
    /// </summary>
    /// <returns> True - if audio now On, False - if audio now Off.</returns>
    public bool AudioSwitchState()
    {
        if (audioOn)
        {
            audioOn = false;
        }
        else
        {
            audioOn = true;
        }
        audioListener.enabled = audioOn;
        return audioOn;
    }
}
