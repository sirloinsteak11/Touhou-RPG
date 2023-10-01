using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class NewBattleSystem : MonoBehaviour
{
    public GameObject playerPrefab, enemyPrefab;
    public Transform playerSpawn, enemySpawn;

    public BattleState state;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        SetupBattle();
    }

    // Update is called once per frame
    void SetupBattle()
    {
        Instantiate(playerPrefab, playerSpawn);
        Instantiate(enemyPrefab, enemySpawn);
    }
}
