using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Level : MonoBehaviour
{
    [SerializeField] private string _levelName;
    [SerializeField] private string _levelDescription;
    [SerializeField] private Sprite _levelPic;
    [SerializeField] private List<Player> _levelPlayers;
    [HideInInspector] public float BestTime;


	/// <summary>
	/// Level's name.
	/// </summary>
	public string Name => _levelName;


    /// <summary>
    /// Level's description. 
    /// </summary>
    public string Description => _levelDescription;


    /// <summary>
    /// Level's picture.
    /// </summary>
    public Sprite Pic => _levelPic;


    /// <summary>
    /// Level's players.
    /// </summary>
    public List<Player> Players => _levelPlayers;
}
