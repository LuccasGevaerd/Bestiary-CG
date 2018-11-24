using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldCards : MonoBehaviour {

    public GameObject Card;

    Card carta;

	void Start () {
		
	}

	void Update () {
		
	}

    void SetFieldCard()
    {
        carta = CardsController.cardSelectedConfig;
        Card.SetActive(true);
        Card.SendMessage("ReciveCardsSetings",carta);
        Card.SendMessage("ChangeModel");
    }
}
