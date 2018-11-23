using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldCards : MonoBehaviour {

    public GameObject Card;

	void Start () {
		
	}

	void Update () {
		
	}

    void SetFieldCard()
    {
        Card.SetActive(true);
        Card.SendMessage("ReciveCardsSetings",CardsController.cardSelectedConfig);
    }
}
