using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldCards : MonoBehaviour {

    public GameObject Card;
    public int cardPositionId;
    public bool enemy;
    public Card atualCard;

    Card carta;

	void Start () {
		
	}

	void Update () {
		
	}

    void SetFieldCard()
    {
            carta = CardsController.cardSelectedConfig;
            atualCard = carta;
        Card.SetActive(false);
        Card.SetActive(true);
            GameObject Gc = GameObject.FindGameObjectWithTag("GameController");
            if (!enemy)
            {
                Gc.SendMessage("FieldCardPlace", cardPositionId);
            }
            else Gc.SendMessage("FieldEnemyPlace", cardPositionId);
            Card.SendMessage("ReciveCardsSetings", carta);
            Card.SendMessage("ChangeModel");
    }
    void SetConfigCard()
    {
            CardsController.cardSelectedConfig = atualCard;
        if (CardsController.cardSelectedConfig != null)
        {
            Debug.Log("Setted: " + CardsController.cardSelectedConfig.name);
        }
    }
}
