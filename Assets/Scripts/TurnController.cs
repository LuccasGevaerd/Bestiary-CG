using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour {

    public static int playerTurn = 0;

	void Start () {
		
	}
	void Update () {
        if (Input.GetKeyDown(KeyCode.T)) playerTurn = 1 - playerTurn;
	}
}
