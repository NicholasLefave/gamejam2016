using UnityEngine;
using System.Collections;

public class TerrainGeneration : MonoBehaviour {
	public GameObject player;
	public GameObject tile;
	public float size;
	private bool stop=true;
	private Vector2 pos;
	// Use this for initialization
	void Start () {
		pos = player.transform.position;


	}

	// Update is called once per frame
	void Update() {
		if (player.transform.position.x - this.transform.position.x < 3.0f && stop) {
			stop = false;
			pos.x += 3;
			GameObject newTile = Instantiate (tile, pos, tile.transform.rotation)as GameObject;
		}
	}
	void FixedUpdate () {
		//createTile ();
	}
	void createTile()
	{

		pos = player.transform.position;
		for (int i = 0; i < 5; i++) {
			pos.x += 4;
			GameObject newTile = Instantiate (tile, pos, tile.transform.rotation)as GameObject;
			newTile.SetActive (true);
		}

	}
	void GenFloor()
	{
		InvokeRepeating ("createTile", 0, 0.5f);
	}
}