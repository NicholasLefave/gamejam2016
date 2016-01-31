using UnityEngine;
using System.Collections;

public class PlayerController2D : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        var move = Input.GetAxis("Horizontal");

        if (move > 0)
        {
            if(transform.localScale.x < 0f)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }
        else if (move < 0)
        {
        }
        else
        {
        }
	}
}
