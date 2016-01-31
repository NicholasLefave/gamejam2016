using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {
    public float moveSpeed;
    public float touchMoveSpeed = 0.5f;

    private bool isChasing = true;
    private GameController _controller;

	// Use this for initialization
	void Start () {
        _controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
        if(isChasing)
        {
            float move = transform.position.x;
            transform.position = new Vector2(move + (moveSpeed * Time.deltaTime), transform.position.y);
        }
        else
        {
            transform.position = Vector2.Lerp(transform.position, _controller.getPlayerPos(), touchMoveSpeed * Time.fixedDeltaTime);
        }
	}

    /// <summary>
    /// When the enemy catches up with the player.
    /// </summary>
    public void touchedPlayer()
    {
        isChasing = false;
        _controller.touchedPlayer();
    }
}
