using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelChanger : MonoBehaviour {

    public GameObject Maga;
    public GameObject Guerreiro;
    public GameObject Arqueiro;
    public GameObject Gigante;
    public GameObject Dragão;
    public GameObject Lobo;

    void ChangeModel()
    {
        DesableAll();
      switch(CardsController.cardSelectedConfig.cardName)
        {
            case "Maga": Maga.SetActive(true); break;
            case "Guerreiro": Guerreiro.SetActive(true); break;
            case "Arqueiro": Arqueiro.SetActive(true); break;
            case "Gigante": Gigante.SetActive(true); break;
            case "Dragão": Dragão.SetActive(true); break;
            case "Lobo": Lobo.SetActive(true); break;
        }
    }
    void DesableAll()
    {
        Maga.SetActive(false);
        Guerreiro.SetActive(false);
        Arqueiro.SetActive(false);
        Gigante.SetActive(false);
        Dragão.SetActive(false);
        Lobo.SetActive(false);
    }
}
