using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType { Human, Troll, beast}

public class unit : MonoBehaviour
{
    public EnemyType type;

    public string unitName;
    public int unitLevel;

    public int damage;

    public int currentHealth;
    public int maxHealth;

    public string element;
    public float sheild;

    public string bio;

    
  
    public bool takeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
   
}
