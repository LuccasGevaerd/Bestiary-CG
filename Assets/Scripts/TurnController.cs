using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour {

    public static int playerTurn = 0;
    public int energyByTurn = 5;

	void Start () {
		
	}
	void Update () {
	}
    public void TurnChange()
    {
        playerTurn = 1 - playerTurn;
        if (playerTurn == 0)
        {
            gameObject.SendMessage("Buy");
            PlayerStats.playerAtualEnergy += energyByTurn;
        }
        Debug.Log("player: " + playerTurn);
    }
}
