using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseCardsBehaviour : MonoBehaviour
{
    [Header("Base Card")]
    [Space(5)]
    public Card card;

    [Header("Card Values")]
    [Space(5)]
    public int atualLife = 1;
    public int atualAttack;
    public int atualShield;

    [Header("Card Texts")]
    [Space(5)]
    public Text cardName;
    //public Text description;
    public Text lifeText;
    public Text attackText;
    public Text shieldText;
    public Text costText;

    [Header("Card Images")]
    [Space(5)]
    public Image cardArt;
    public Image cardElement;
    public Image backgroundElement;
    public Image levelMoldure;

    [Header("Card Element Symbols")]
    [Space(5)]
    public Sprite fireArt;
    public Sprite windArt;
    public Sprite watherArt;
    public Sprite earthArt;
    public Sprite lightningArt;
    public Sprite iceArt;
    public Sprite specialArt;

    [Header("Card Backgrounds")]
    [Space(5)]
    public Sprite fireArtBKG;
    public Sprite windArtBKG;
    public Sprite watherArtBKG;
    public Sprite earthArtBKG;
    public Sprite lightningArtBKG;
    public Sprite iceArtBKG;
    public Sprite specialArtBKG;

    [Header("Card Level Moldure")]
    [Space(5)]
    public Sprite level1;
    public Sprite level2;
    public Sprite level3;

    void UpdateCard()
    {

        ChangeAtualValues();

        switch (card.element)
        {
            case "fire":
                cardArt.sprite = card.fireArt;
                cardElement.sprite = fireArt;
                backgroundElement.sprite = fireArtBKG;
                break;
            case "wather":
                cardArt.sprite = card.watherArt;
                cardElement.sprite = watherArt;
                backgroundElement.sprite = watherArtBKG;
                break;
            case "earth":
                cardArt.sprite = card.earthArt;
                cardElement.sprite = earthArt;
                backgroundElement.sprite = earthArtBKG;
                break;
            case "ice":
                cardArt.sprite = card.iceArt;
                cardElement.sprite = iceArt;
                backgroundElement.sprite = iceArtBKG;
                break;
            case "lightning":
                cardArt.sprite = card.lightningArt;
                cardElement.sprite = lightningArt;
                backgroundElement.sprite = lightningArtBKG;
                break;
            case "wind":
                cardArt.sprite = card.windArt;
                cardElement.sprite = windArt;
                backgroundElement.sprite = windArtBKG;
                break;
            case "special":
                cardArt.sprite = card.specialArt;
                cardElement.sprite = specialArt;
                backgroundElement.sprite = specialArtBKG;
                break;
        }
        switch (card.level)
        {
            case 1:
                levelMoldure.sprite = level1;
                break;
            case 2:
                levelMoldure.sprite = level2;
                break;
            case 3:
                levelMoldure.sprite = level3;
                break;
        }
    }
    void ChangeAtualValues()
    {
        cardName.text = "" + card.cardName;
        lifeText.text = "" + atualLife;
        attackText.text = "" + atualAttack;
        shieldText.text = "" + atualShield;

    }
    public void ReciveCardsSetings(Card cardSetings)
    {
        card = cardSetings;
        atualLife = card.life;
        atualShield = card.shield;
        atualAttack = card.attack;
        costText.text = "" + card.cost;
        UpdateCard();
    }
    public void MoveInHierarchy(int delta)
    {
        int index = transform.GetSiblingIndex();
        transform.SetSiblingIndex(index + delta);
    }
    public void SetConfigCard()
    {
        CardsController.modifiedCard.cardName = card.cardName;
        CardsController.modifiedCard.level = card.level;
        CardsController.modifiedCard.element = card.element;
        CardsController.modifiedCard.life = atualLife;
        CardsController.modifiedCard.shield = atualShield;
        CardsController.modifiedCard.attack = atualAttack;
        CardsController.modifiedCard.earthArt = card.earthArt;
        CardsController.modifiedCard.fireArt = card.fireArt;
        CardsController.modifiedCard.iceArt = card.iceArt;
        CardsController.modifiedCard.lightningArt = card.lightningArt;
        CardsController.modifiedCard.specialArt = card.specialArt;
        CardsController.modifiedCard.watherArt = card.watherArt;
        CardsController.modifiedCard.windArt = card.windArt;
        CardsController.modifiedCard.description = card.description;
        CardsController.modifiedCard.cost = card.cost;


        SelectedCardInfo.cardReference = CardsController.modifiedCard;
        CardsController.cardSelectedConfig = card;
        Debug.Log("Card " + CardsController.cardSelectedConfig.cardName + " Setted");
    }
    void TakeDamage(int dmg)
    {
        if (atualShield == 0 && atualLife <= dmg)
        {
            PlayerStats.playerAtualLife -= (dmg - atualLife);
            gameObject.SetActive(false);
        }
        else
        {
            if (atualLife > 0)
            {
                if (atualShield > 0) atualShield--;
                else atualLife -= dmg;
            }
        }
        UpdateCard();
        Debug.Log(card.name + " taked damage");
    }
}
