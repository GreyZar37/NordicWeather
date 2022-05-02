using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu]

public class data : ScriptableObject
{
    public string textBio;

    public string unitName;
    public int unitLevel;

    public int damage;

    public float currentHealth;
    public float maxHealth;

    public float sheild;
    public string unitElement;

    public int unitLevel_
    {
        get
        {
            return unitLevel;
        }
        set
        {
            unitLevel = value;
        }
    }

    public float maxHealth_
    {
        get
        {
            return maxHealth;
        }
        set
        {
            maxHealth = value;
        }
    }

    public int damage_
    {
        get
        {
            return damage;
        }
        set
        {
            damage = value;
        }
    }

    public string unitName_
    {
        get
        {
            return unitName;
        }
        set
        {
            unitName = value;
        }
    }

   

    public float shield_
    {
        get
        {
            return sheild;
        }
        set
        {
            sheild = value;
        }
    }

    public string unitElement_
    {
        get
        {
            return unitElement;
        }
        set
        {
            unitElement = value;
        }
    }

    public string unitBio_
    {
        get
        {
            return textBio;
        }
        set
        {
            textBio = value;
        }
    }


}
