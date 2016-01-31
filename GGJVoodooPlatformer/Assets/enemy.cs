using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {
    public float moveSpeed;
    public float touchMoveSpeed = 0.5f;
	public float upDown =.2f;
	public float upDownAdj = .1f;
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
			transform.position = new Vector2(move + (moveSpeed * Time.deltaTime), transform.position.y+(Time.deltaTime * upDown) );
			if(upDown > 0)
			{
				if(upDown > 2)
					upDown = -.2f;
				else
					upDown+= upDownAdj;
			}
			else 
			{
				if(upDown < -2f)
					upDown = .2f;
				else
					upDown -= upDownAdj;
			}
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
        var anim = GetComponent<Animator>();
        anim.SetBool("catch", true);
        _controller.touchedPlayer();
        transform.rotation = Quaternion.identity;
    }
}
