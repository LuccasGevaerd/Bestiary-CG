using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsController : MonoBehaviour {

    [Header("Enemy lists")]
    [Space(5)]

    public List<Card> playerDeck = new List<Card>();
    public List<GameObject> playerFieldCardsGCs = new List<GameObject>();
    public List<Card> playerHandCards = new List<Card>();

    [Header("Enemy lists")]
    [Space(5)]

    public List<Card> enemyDeck = new List<Card>();
    public List<GameObject> enemyFieldCardsGCs = new List<GameObject>();
    public List<Card> enemyHandCards = new List<Card>();

    public GameObject cardPrefab;
    public GameObject playerHand;
    public GameObject selectedCard;
    public GameObject desabledTemporaryCard;

    public static Card cardSelectedConfig;
    public static Card cardSelectedField;
    public static Card modifiedCard;
    public Card modifiedCardBase;

    public static int attackedPos;

    public int inicialHandCards;

    public bool attackMode;

    [Header("Effects lists")]
    [Space(5)]
    [Tooltip("Fire,Water,Earth,Ice,Lightning,Wind")]
    public GameObject[] effectsPrefabs;
    public GameObject attackEffect;

    void Start () {
        modifiedCard = modifiedCardBase;
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
        if (TurnController.playerTurn == 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (!attackMode && hit.transform.tag == "HandCard")
                {
                    cardSelectedConfig = null;
                    hit.transform.gameObject.SendMessage("SetConfigCard");
                    if (desabledTemporaryCard != null)
                    {
                        desabledTemporaryCard.SetActive(true);
                    }
                    hit.transform.gameObject.SetActive(false);
                    selectedCard.SetActive(false);
                    selectedCard.SetActive(true);
                    selectedCard.SendMessage("SetCard", cardSelectedConfig);
                    desabledTemporaryCard = hit.transform.gameObject;
                    Debug.Log("Hand Card");
                }
                if (!attackMode && (hit.transform.tag == "Field Card" || hit.transform.tag == "Enemy Field Cards"))
                {

                    if (!attackMode && cardSelectedConfig != null && selectedCard.active && desabledTemporaryCard != null && cardSelectedConfig.cost <= PlayerStats.playerAtualEnergy)
                    {
                        PlayerStats.playerAtualEnergy -= cardSelectedConfig.cost;
                        selectedCard.SetActive(false);
                        hit.transform.gameObject.SendMessage("SetFieldCard");
                        Destroy(desabledTemporaryCard);
                        cardSelectedConfig = null;
                        Debug.Log("Field Card Place");
                    }
                    else
                    {
                        hit.transform.gameObject.SendMessage("SetConfigCard");
                        if (cardSelectedConfig != null)
                        {
                            if (desabledTemporaryCard != null)
                            {
                                desabledTemporaryCard.SetActive(true);
                            }
                            selectedCard.SetActive(false);
                            selectedCard.SetActive(true);
                            selectedCard.SendMessage("SetCard");
                            Debug.Log("Field Card Selected");
                            cardSelectedConfig = null;
                        }
                    }
                }
                if (hit.transform.tag != "HandCard" && hit.transform.tag != "Field Card" && hit.transform.tag != "Enemy Field Cards")
                {
                    selectedCard.SetActive(false);
                    if (desabledTemporaryCard != null)
                    {
                        desabledTemporaryCard.SetActive(true);
                    }
                }
                if (attackMode)
                {
                    if (hit.transform.tag == "Field Card")
                    {
                        hit.transform.gameObject.SendMessage("SetConfigCard");
                        if (cardSelectedConfig != null)
                        {
                            selectedCard.SetActive(false);
                            selectedCard.SetActive(true);
                            selectedCard.SendMessage("SetCard");
                            Debug.Log("Field Card Selected");
                        }

                    }
                    if (cardSelectedConfig != null && hit.transform.tag == "Enemy Field Cards")
                    {
                        hit.transform.gameObject.SendMessage("GetAttack");
                        if (attackedPos != 99 && cardSelectedConfig.cost <= PlayerStats.playerAtualEnergy)
                        {
                            PlayerStats.playerAtualEnergy -= cardSelectedConfig.cost;
                            Instantiate(attackEffect, new Vector3(hit.transform.position.x, 2, hit.transform.position.z), attackEffect.transform.rotation);
                            switch (cardSelectedConfig.cardName)
                            {
                                case "Maga": Attack(3, cardSelectedConfig.attack); break;
                                case "Guerreiro": Attack(1, cardSelectedConfig.attack); break;
                                case "Lobo": Attack(1, cardSelectedConfig.attack); break;
                                case "Dragão": Attack(5, cardSelectedConfig.attack); break;
                                case "Gigante": Attack(5, cardSelectedConfig.attack); break;
                                case "Arqueiro": Attack(1, cardSelectedConfig.attack); break;
                            }
                        }
                    }
                }
            }
        }

    }
    public void AttackMode()
    {
        if(!attackMode) attackMode = true;
        else attackMode = false;
        Debug.Log("Attack Mode : " + attackMode);
    }

    void Buy()
    {
        GetHandCards(playerDeck, playerHandCards, playerHand, 1);
        Debug.Log("BuyDeckCard");
    }

    //

    void Attack(int range,int dmg)
    {
        if (dmg > 0)
        {
            enemyFieldCardsGCs[attackedPos].SendMessage("GetDamage",dmg);
            EffectSpawner(enemyFieldCardsGCs[attackedPos]);
        }

        if (range == 3)
        {
            if (attackedPos < enemyFieldCardsGCs.Count - 1 && enemyFieldCardsGCs[attackedPos + 1] != null)
            {
                enemyFieldCardsGCs[attackedPos + 1].SendMessage("GetDamage", dmg);
                EffectSpawner(enemyFieldCardsGCs[attackedPos + 1]);
            }

            if (attackedPos > 0 && enemyFieldCardsGCs[attackedPos - 1] != null)
            {
                enemyFieldCardsGCs[attackedPos - 1].SendMessage("GetDamage", dmg);
                EffectSpawner(enemyFieldCardsGCs[attackedPos - 1]);
            }
        }

        if (range == 5)
        {
            for (int y = 0; y < enemyFieldCardsGCs.Count; y++) {
                if (enemyFieldCardsGCs[y] != null)
                {
                    enemyFieldCardsGCs[y].SendMessage("GetDamage", dmg);
                    EffectSpawner(enemyFieldCardsGCs[y]);
                }
            }
        }
    }
    void EffectSpawner(GameObject hit)
    {
        switch (cardSelectedConfig.element)
        {
            case "fire":
                Instantiate(effectsPrefabs[0], new Vector3(hit.transform.position.x, 2, hit.transform.position.z), effectsPrefabs[0].transform.rotation);
                break;
            case "wather":
                Instantiate(effectsPrefabs[1], new Vector3(hit.transform.position.x, 2, hit.transform.position.z), effectsPrefabs[1].transform.rotation);
                break;
            case "earth":
                Instantiate(effectsPrefabs[2], new Vector3(hit.transform.position.x, 2, hit.transform.position.z), effectsPrefabs[2].transform.rotation);
                break;
            case "ice":
                Instantiate(effectsPrefabs[3], new Vector3(hit.transform.position.x, 2, hit.transform.position.z), effectsPrefabs[3].transform.rotation);
                break;
            case "lightning":
                Instantiate(effectsPrefabs[4], new Vector3(hit.transform.position.x, 2, hit.transform.position.z), effectsPrefabs[4].transform.rotation);
                break;
            case "wind":
                Instantiate(effectsPrefabs[5], new Vector3(hit.transform.position.x, 2, hit.transform.position.z), effectsPrefabs[5].transform.rotation);
                break;

        }
    }
}
