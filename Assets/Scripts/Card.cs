using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Beast")]
public class Card : ScriptableObject {
    public string cardName;
    public string description;
    public string element;

    public int level;
    public int cost;
    public int life;
    public int attack;
    public int shield;

    public Sprite fireArt;
    public Sprite windArt;
    public Sprite watherArt;
    public Sprite earthArt;
    public Sprite lightningArt;
    public Sprite iceArt;
    public Sprite specialArt;

    public GameObject cardMesh;
    public Material cardMeshMaterial;

    public Card nextLevelCard;
}
