using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameSaveFile : MonoBehaviour
{
    // Start is called before the first frame update
    public data data;
    public unit playerPref;


    public bool save;
    public bool load;
    
    void Start()
    {
      
            if (load == true)
            {
                loadData(playerPref);
            }
        

    }

    // Update is called once per frame
    void Update()
    {
        
            if (save == true)
            {
                saveData(playerPref);
            
            }
 


    }

    public void saveData(unit playerDataSave) {
        data.unitLevel = playerDataSave.unitLevel;
        data.unitName = playerDataSave.unitName;
        data.damage = playerDataSave.damage;
        data.maxHealth = playerDataSave.maxHealth;
        data.sheild = playerDataSave.shield_;
        data.unitElement = playerDataSave.element;
        data.textBio = playerDataSave.bio;
    }

    public void loadData(unit playerDataLoad)
    {
        playerDataLoad.maxHealth = data.maxHealth;
        playerDataLoad.damage = data.damage;
        playerDataLoad.unitLevel = data.unitLevel;
        playerDataLoad.unitName = data.unitName;
        playerDataLoad.shield_ = data.sheild;
        playerDataLoad.element = data.unitElement;
        playerDataLoad.bio = data.textBio;

    }

    public void playerData(unit playerPrefab)
    {
     playerPref = playerPrefab;
    }

}
