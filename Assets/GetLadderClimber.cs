﻿using UnityEngine;
using System.Collections;

public class GetLadderClimber : MonoBehaviour {
	public GameObject ladderClimberPrefab;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public GameObject getLadderCLimber() {
		return (ladderClimberPrefab);
	}
}
