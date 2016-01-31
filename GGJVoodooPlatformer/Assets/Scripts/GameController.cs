using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    public GameObject _player;
    public float touchMoveSpeed = 0.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void killPlayer()
    {
        Debug.Break();
    }

    public Vector2 getPlayerPos()
    {
        return _player.transform.position;
    }

    /// <summary>
    /// When the player is caught by the enemy.
    /// </summary>
    /// <param name="_enemy">The enemy.</param>
    public void touchedPlayer()
    {
        // Stop player
        _player.GetComponent<PlayerController>().touched();
        // Play dying animation
    }
}
