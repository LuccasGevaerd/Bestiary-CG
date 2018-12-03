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
        UpdateSettings();
    }
    public void SetConfigCard()
    {
        if(Card.active)
        Card.SendMessage("SetConfigCard");
    }
    void GetAttack()
    {
        if (Card.active) CardsController.attackedPos = cardPositionId;
        else CardsController.attackedPos = 99;
    }
    void UpdateSettings()
    {
        Card.SendMessage("ReciveCardsSetings", carta);
        Card.SendMessage("ChangeModel", carta);
    }
    void GetDamage(int dmg)
    {
        if (Card.active) Card.SendMessage("TakeDamage",dmg);
    }
}
