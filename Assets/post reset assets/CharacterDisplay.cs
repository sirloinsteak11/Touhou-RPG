using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDisplay : MonoBehaviour
{

    public Character character;

    public Image charaImage;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI damageText;
    public TextMeshProUGUI defenseText;
    public TextMeshProUGUI spAtkText;
    public TextMeshProUGUI healthText;

    // Start is called before the first frame update
    void Start()
    {
        charaImage.sprite = character.design;
        charaImage.preserveAspect = true;

        nameText.text = character.Name;
        descriptionText.text = character.description;
        levelText.text = $"Level: {character.Level}";
        damageText.text = $"Damage: {character.damage}";
        defenseText.text = $"Defense: {character.defense}";
        spAtkText.text = $"Spell Card Damage: {character.spAtk}";
        healthText.text = $"HP: {character.currentHP} / {character.maxHP}";
    }
}
