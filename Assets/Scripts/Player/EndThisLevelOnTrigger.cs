using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndThisLevelOnTrigger : MonoBehaviour
{
    public static EndThisLevelOnTrigger instance { get; private set; }

    public delegate void EndLevelByTriggerAction();
    public event EndLevelByTriggerAction endLevelByTrigger;

    [SerializeField] private bool canLoadNextLevel;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        canLoadNextLevel = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (canLoadNextLevel)
        {
            if ((this.gameObject.CompareTag("Player")) && (other.gameObject.CompareTag("Finish")))
            {
                endLevelByTrigger?.Invoke();
            }
        }
    }
}
