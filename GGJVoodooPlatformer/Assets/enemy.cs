using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {
    public float moveSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float move = transform.position.x;
        transform.position = new Vector2(move + (moveSpeed * Time.deltaTime), transform.position.y);
	}
}
