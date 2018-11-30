using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour {

    public static int playerTurn = 0;

	void Start () {
		
	}
	void Update () {
	}
    public void TurnChange()
    {
        playerTurn = 1 - playerTurn;
        Debug.Log("player: " + playerTurn);
    }
}
