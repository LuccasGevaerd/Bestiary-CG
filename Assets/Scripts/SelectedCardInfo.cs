using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedCardInfo : MonoBehaviour {

    public GameObject cardGCReference;

    public static Card cardReference;


    public Text cardDescription;

	void Start () {
		
	}

	void Update () {
		
	}
    void SetCard()
    {
        cardGCReference.SendMessage("ReciveCardsSetings",CardsController.modifiedCard);
        cardDescription.text = CardsController.modifiedCard.description;
    }
}
