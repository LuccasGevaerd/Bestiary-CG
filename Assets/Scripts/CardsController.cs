using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsController : MonoBehaviour {

    public List<Card> playerDeck = new List<Card>();
    public List<Card> playerFieldCards = new List<Card>();
    public List<Card> playerHandCards = new List<Card>();

    public GameObject cardPrefab;
    public GameObject playerHand;
    public GameObject selectedCard;
    public GameObject desabledTemporaryCard;

    public static Card cardSelectedConfig;

    public int inicialHandCards;

	void Start () {
        GetHandCards(playerDeck,playerHandCards,playerHand,inicialHandCards);
	}

	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            GetMouseSelection();
        }
    }
    void GetHandCards(List<Card>Deck, List<Card> HandCards, GameObject Hand, int CardsToRecive)
    {
        if (Deck.Count > 0)
        {
            for (int i = 0; i < CardsToRecive; i++)
            {
                int cardsListNumber = Random.Range(0, Deck.Count);
                GameObject card = Instantiate(cardPrefab, new Vector3(), new Quaternion());
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
    void GetMouseSelection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast (ray, out hit))
        {
            if (hit.transform.tag == "HandCard")
            {
                hit.transform.gameObject.SendMessage("SetConfigCard");
                if (desabledTemporaryCard != null)
                {
                    desabledTemporaryCard.SetActive(true);
                }
                hit.transform.gameObject.SetActive(false);
                selectedCard.SetActive(true);
                selectedCard.SendMessage("SetCard", cardSelectedConfig);
                desabledTemporaryCard = hit.transform.gameObject;
                Debug.Log("Hand Card");
            }
            else
            {
                if (hit.transform.tag == "Field Card"  && selectedCard.active)
                {
                    Debug.Log("Field Card");
                    selectedCard.SetActive(false);
                    hit.transform.gameObject.SendMessage("SetFieldCard");
                    if (desabledTemporaryCard != null)
                    {
                        Destroy(desabledTemporaryCard);
                    }
                    cardSelectedConfig = null;
                }
                else
                {
                    selectedCard.SetActive(false);
                    if (desabledTemporaryCard != null)
                    {
                        desabledTemporaryCard.SetActive(true);
                    }
                }
            }
            if (hit.transform.tag == "BuyDeck")
            {
                GetHandCards(playerDeck, playerHandCards, playerHand, 1);
                Debug.Log("BuyDeckCard");
            }
        }

    }
}
