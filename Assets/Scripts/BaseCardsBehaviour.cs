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
    public int atualLife;
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
        atualLife = card.life;
        atualShield = card.shield;
        atualAttack = card.attack;
        costText.text = "" + card.cost;

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
        UpdateCard();
    }
    public void MoveInHierarchy(int delta)
    {
        int index = transform.GetSiblingIndex();
        transform.SetSiblingIndex(index + delta);
    }
    public void SetConfigCard()
    {
        SelectedCardInfo.cardReference = card;
        CardsController.cardSelectedConfig = card;
        Debug.Log("Card Setted");
    }
}
