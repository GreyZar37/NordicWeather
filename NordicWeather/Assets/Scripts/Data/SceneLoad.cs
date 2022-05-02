using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SceneLoad : MonoBehaviour
{


    public TextMeshProUGUI[] statTxt;
    public TextMeshProUGUI[] levelGods;

    public GameObject prefabToSpawn;
    public GameObject spawnedCharacter;
    public unit playerUnit;

    public GameObject[] godsAndCreatures;

    public Transform spawnPoint;

    public data data;
    public GameSaveFile gameSaveFile;

    // Start is called before the first frame update
    void Start()
    {
      
        switch (data.unitName)
        {
            case "TROLL":

                spawnedCharacter = godsAndCreatures[0];
                prefabToSpawn = godsAndCreatures[0];
                break;
            case "ODIN":
                spawnedCharacter = godsAndCreatures[1];
                prefabToSpawn = godsAndCreatures[1];
                break;
            case "THOR":
                spawnedCharacter = godsAndCreatures[2];
                prefabToSpawn = godsAndCreatures[2];
                break;

            default:
                break;
        }
        LoadData();
        spawnedCharacter = Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity);
        playerUnit = spawnedCharacter.GetComponent<unit>();
        gameSaveFile.playerData(playerUnit);
    }

    // Update is called once per frame
    void Update()
    {
        playerUnit = spawnedCharacter.GetComponent<unit>();
        gameSaveFile.playerData(playerUnit);


        LoadData();

    }

    public void LoadData()
    {
        statTxt[0].text = data.maxHealth.ToString();
        statTxt[1].text = data.damage.ToString();
        statTxt[2].text = data.sheild.ToString();
        statTxt[3].text = data.unitElement;
        statTxt[4].text = data.unitName;
        statTxt[5].text = data.unitName;
        statTxt[6].text = data.textBio;




    }

    public void characterChange(string unitName)
    {
       


        switch (unitName)
        {

            case "TROLL":
                Destroy(spawnedCharacter);
                prefabToSpawn = godsAndCreatures[0];
                spawnedCharacter = Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity);

                break;
            case "ODIN":
                Destroy(spawnedCharacter);

                prefabToSpawn = godsAndCreatures[1];
                spawnedCharacter = Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity);

                break;
            case "THOR":
                Destroy(spawnedCharacter);

                prefabToSpawn = godsAndCreatures[2];
                spawnedCharacter = Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity);

                break;

            default:
                break;
        }
    }
}
