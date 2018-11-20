using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsController : MonoBehaviour {

    public List<Card> playerDeck = new List<Card>();
    public List<Card> playerFieldCards = new List<Card>();
    public List<Card> playerHandCards = new List<Card>();

    public GameObject cardPrefab;
    public GameObject playerHand;

    public int inicialHandCards;

	void Start () {
        GetHandCards(playerDeck,playerHandCards,playerHand,inicialHandCards);
	}

	void Update () {
		
	}
    void GetHandCards(List<Card>Deck, List<Card> HandCards, GameObject Hand, int CardsToRecive)
    {
        for (int i = 0; i<CardsToRecive; i++)
        {
            int cardsListNumber = Random.Range(0, Deck.Count);
            GameObject card = Instantiate(cardPrefab,new Vector3 (),new Quaternion());
            card.transform.SetParent(Hand.transform);
            card.transform.localScale = new Vector3(1, 1, 1);
            card.transform.rotation = new Quaternion(0, 0, 0, 0);
            card.transform.position = Hand.transform.position;
            card.SendMessage("ReciveCardsSetings", Deck[cardsListNumber]);
            HandCards.Add(Deck[cardsListNumber]);
            Deck.Remove(Deck[cardsListNumber]);
        }
    }
}
