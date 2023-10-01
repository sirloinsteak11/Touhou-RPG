using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterLinker : MonoBehaviour
{

    public Character character;
    public NewBattleSystem battleSystem;

    public GameObject PlayerName, EnemyName, PlayerHealthCounter, EnemyHealthCounter, BattleLog, BattleSystem;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI battleLogText;

    // Start is called before the first frame update
    void Start()
    {
        PlayerName = GameObject.FindWithTag("playerName");
        EnemyName = GameObject.FindWithTag("enemyName");
        PlayerHealthCounter = GameObject.FindWithTag("playerHealthCounter");
        EnemyHealthCounter = GameObject.FindWithTag("enemyHealthCounter");

        BattleLog = GameObject.FindWithTag("battleLog");
        battleLogText = BattleLog.GetComponent<TextMeshProUGUI>();

        BattleSystem = GameObject.FindWithTag("battleSystem");
        battleSystem = BattleSystem.GetComponent<NewBattleSystem>();

        if (character.Type == Character.CharaTypes.PLAYER)
        {
            nameText = PlayerName.GetComponent<TextMeshProUGUI>();
            healthText = PlayerHealthCounter.GetComponent<TextMeshProUGUI>();
        }
        if (character.Type == Character.CharaTypes.ENEMY)
        {
            nameText = EnemyName.GetComponent<TextMeshProUGUI>();
            healthText = EnemyHealthCounter.GetComponent<TextMeshProUGUI>();

            if (battleSystem.state == BattleState.START)
            {
                battleLogText.text = $"{character.Name} has appeared!";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = $"{character.currentHP} / {character.maxHP}";
        nameText.text = $"Lv{character.Level} {character.Name}";
    }
}
