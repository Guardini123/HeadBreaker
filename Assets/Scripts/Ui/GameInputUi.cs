using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameInputUi : MonoBehaviour
{
    public static GameInputUi Instance { get; private set; }

	[SerializeField] private BtnUserInputSupportUi _moveButtonUp;
	[SerializeField] private BtnUserInputSupportUi _moveButtonDown;
	[SerializeField] private BtnUserInputSupportUi _moveButtonRight;
	[SerializeField] private BtnUserInputSupportUi _moveButtonLeft;


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
				_moveButtonUp.OnPress.AddListener(player.MovePlayerByUI);
				_moveButtonDown.OnPress.AddListener(player.MovePlayerByUIInvert);
			}

			if (player.MoveDirection.x != 0)
			{
				_moveButtonRight.OnPress.AddListener(player.MovePlayerByUI);
				_moveButtonLeft.OnPress.AddListener(player.MovePlayerByUIInvert);
			}
		}
	}

}
