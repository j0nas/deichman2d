﻿using UnityEngine;
using System.Collections;

public class GameManagerSpawnerScript : MonoBehaviour {

    public GameObject _GM;


	// Use this for initialization
	void Awake () {
        if (!GameObject.Find("GameManager")) {
            GameObject GM = GameObject.Instantiate(_GM);
            GM.name = "GameManager";
        }
	}
	
}