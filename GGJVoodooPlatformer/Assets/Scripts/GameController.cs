using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    public GameObject _player;
    public float touchMoveSpeed = 0.5f;
	public GameObject gameOver;
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
        // Freeze positioning
        _player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        // Change animation
        var anim = _player.GetComponent<Animator>();
        anim.SetFloat("Speed", 0);
		Camera.main.transform.position = new Vector3 (_player.transform.position.x, _player.transform.position.y, -1f);
		Camera.main.orthographicSize = 2;
		_player.layer = LayerMask.NameToLayer("UI");
		StartCoroutine(gameOver.GetComponent<GameOverScript>().playerDied());
        // Play dying animation
    }
}
