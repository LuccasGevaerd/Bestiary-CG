using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    public int startEnergy;
    public int maxLife;

    public static int playerAtualEnergy;
    public static int playerAtualLife;

    public Text playerEnergyText;
    public Text playerLifeText;

    public Image playerLifeBar;

	void Start () {
        playerAtualEnergy = startEnergy;
        playerAtualLife = maxLife;
	}

	void Update () {
        playerLifeBar.fillAmount = playerAtualLife / maxLife;
        playerEnergyText.text = "" + playerAtualEnergy;
        playerLifeText.text = playerAtualLife  + "/" + maxLife;
    }
}
