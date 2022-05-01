using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleHUD : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI levelText;

    public TextMeshProUGUI hpValueTxt;

    public Slider hpSlider;

    public void SetHUD(unit unit)
    {
        nameText.text = unit.unitName;
        levelText.text = "Lvl " + unit.unitLevel;
        hpSlider.maxValue = unit.maxHealth;
        hpSlider.value = unit.currentHealth;
    }

    public void SetHP(int hp)
    {
        hpSlider.value = hp;
        hpValueTxt.text = hp.ToString() + "/" + hpSlider.maxValue.ToString();
    }




}
