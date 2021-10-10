using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EndThisLevelOnTrigger : MonoBehaviour
{
    public UnityEvent OnEndLevel;

    [SerializeField] private bool _canLoadNextLevel;



    void Start()
    {
        _canLoadNextLevel = true;
        OnEndLevel.AddListener(LevelManager.Instance.FinishLevel);
    }


	private void OnDestroy()
	{
        OnEndLevel.RemoveAllListeners();
	}


	private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            if (_canLoadNextLevel)
            {
                OnEndLevel?.Invoke();
            }
        } 
    }
}
