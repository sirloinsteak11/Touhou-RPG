using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Character : ScriptableObject
{
    public enum CharaTypes { PLAYER, ENEMY }

    public string Name;
    public string description;
    public Sprite design;
    public CharaTypes Type;
    public int Level;

    public float damage;
    public float defense;
    public float spAtk;

    public int maxHP;
    public int currentHP;

    public bool TakeDamage(int damage)
    {
        currentHP -= damage;

        if (currentHP <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Heal(int amount)
    {
        currentHP += amount;

        if (currentHP == maxHP)
            currentHP = maxHP;
    }

    public void IncreaseDamage(float amount)
    {
        damage += amount;
        spAtk += amount * 0.1f;
    }
}
