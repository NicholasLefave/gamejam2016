﻿using UnityEngine;
using System.Collections;

public class touchPlayer : MonoBehaviour {
    public enemy _enemy;


    private GameController _controller;
	// Use this for initialization
	void Start () {
        _controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //_controller.killPlayer();
            if(_enemy)
            {
                _enemy.touchedPlayer();
            }
        }
    }
}
