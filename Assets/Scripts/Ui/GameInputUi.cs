using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;


public class GameInputUi : MonoBehaviour
{
    public static GameInputUi Instance { get; private set; }

	[SerializeField] private BtnPressSupportUi _moveButtonUp;
	[SerializeField] private BtnPressSupportUi _moveButtonDown;
	[SerializeField] private BtnPressSupportUi _moveButtonRight;
	[SerializeField] private BtnPressSupportUi _moveButtonLeft;


	private void Awake()
	{
		Instance = this;
	}


	public void SetUpUiInput(List<Player> players)
	{
		_moveButtonUp.OnPress.RemoveAllListeners();
		_moveButtonDown.OnPress.RemoveAllListeners();
		_moveButtonRight.OnPress.RemoveAllListeners();
		_moveButtonLeft.OnPress.RemoveAllListeners();

		foreach (var player in players)
		{
			if(player.MoveDirection.z != 0)
			{
				_moveButtonUp.OnPress.AddListener(() => player.MovePlayer());
				_moveButtonDown.OnPress.AddListener(() => player.MovePlayer(true));
			}

			if (player.MoveDirection.x != 0)
			{
				_moveButtonRight.OnPress.AddListener(() => player.MovePlayer());
				_moveButtonLeft.OnPress.AddListener(() => player.MovePlayer(true));
			}
		}
	}

}
