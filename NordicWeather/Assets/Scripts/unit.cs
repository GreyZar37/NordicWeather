using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum EnemyType { Human, Troll, beast}

public class unit : MonoBehaviour
{
    public EnemyType type;

    public string unitName;
    public int unitLevel;

    public int damage;
    public float shieldPanetration;

    public float currentHealth;
    public float maxHealth;

    public string element;
    public float shield_;

    public string bio;

    

    
  
    public bool takeDamage(float damage, float shieldPanetration, TextMeshProUGUI damageTxt)
    {
        print(shieldPanetration);
        shield_ -= shieldPanetration;
        if (shield_ <= 1)
        {
            shield_ = 1;
        }

        currentHealth -= Mathf.Round((damage - (damage * (shield_ / 100))));
       damageTxt.text = "-" + Mathf.Round((damage - (damage * (shield_ / 100)))).ToString();

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
