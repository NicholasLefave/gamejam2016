using UnityEngine;
using System.Collections;

public class PlayerController2D : MonoBehaviour {

    public Transform _groundCheck;
	// Use this for initialization
	void Start () {
	}

    void Awake()
    {
        _groundCheck = transform.Find("groundCheck");
    }
	
	// Update is called once per frame
	void Update () {
        var move = Input.GetAxis("Horizontal");

        if (move > 0)
        {
            if(transform.localScale.x < 0f)
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

            // TODO check if grounded to set run animation
        }
        else if (move < 0)
        {
            if(transform.localScale.x > 0f)
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

            // TODO check if grounded to set run animation
        }
        else
        {
            // TODO Character not moving, set idle animation if grounded
        }
	}
}
