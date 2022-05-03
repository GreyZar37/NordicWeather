using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST, ESCAPED }
public enum attackTypeState { light = 0, medium = 1, heavy = 2}


public class Combat : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject[] enemyPrefab;

    public GameObject matchStatMenu;
    public TextMeshProUGUI lootTxt;
    public TextMeshProUGUI gameStatusTxt;
    public TextMeshProUGUI returnButtonTxt;

    public GameObject[] godsAndCreatures;

    public data data;
    public GameSaveFile gameSaveFile;


    public Transform[] battleStations;

    public BattleState state;
    public attackTypeState attackType;


    unit playerUnit;
    unit enemyUnit;
    float elementDamageBonus;


    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public TextMeshProUGUI damageTxt;
    public TextMeshProUGUI TurnTxt;

    public ShakeScreen shakeScreen;

    public ParticleSystem playerHit;
    public ParticleSystem enemyHit;

    public SoundManager audioSorces;

    // Start is called before the first frame update
    void Start()
    {
        print("DataGiven");
        playerSpawner();
        state = BattleState.START;
        StartCoroutine(setUpBattle());
    }

    // Update is called once per frame
    void Update()
    {

    }



    IEnumerator setUpBattle()
    {
        

        int randomEnemy = Random.Range(0, enemyPrefab.Length);
        GameObject enemy = Instantiate(enemyPrefab[randomEnemy], battleStations[1].position, Quaternion.identity);
        enemyUnit = enemy.GetComponent<unit>();

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);
        enemyUnit.currentHealth = enemyUnit.maxHealth;
        playerUnit.currentHealth = playerUnit.maxHealth;

        enemyHUD.SetHP(enemyUnit.currentHealth);
        playerHUD.SetHP(playerUnit.currentHealth);

        StartCoroutine(playerTurn());

        yield return null;
    }

    IEnumerator playerTurn()
    {
        yield return new WaitForSeconds(1f);
        TurnTxt.enabled = true;
        yield return new WaitForSeconds(2f);
        TurnTxt.enabled = false;
        state = BattleState.PLAYERTURN;
        print("playerTurn");

    }

    public void attack(int attackTypeValue)
    {
        float rngNumber;


        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        switch (attackTypeValue)
        {
            case 0:
                rngNumber = Random.Range(0, 100);
                attackType = attackTypeState.light;

                if (rngNumber <= 85)
                {

                    StartCoroutine(playerAttack(1));
                }
                else
                {
                    StartCoroutine(missed());
                }
                break;
            case 1:
                rngNumber = Random.Range(0, 100);
                attackType = attackTypeState.medium;

                if (rngNumber <= 65)
                {
                    StartCoroutine(playerAttack(2));
                }
                else
                {
                    StartCoroutine(missed());
                
                }

                break;
            case 2:
                rngNumber = Random.Range(0, 100);
                attackType = attackTypeState.heavy;

                if (rngNumber <= 35)
                {
                    StartCoroutine(playerAttack(3));

                }
                else
                {
                    StartCoroutine(missed());
                 
                }
                break;
            case 3:
                rngNumber = Random.Range(0, 100);
                if (rngNumber <= 75)
                {
                    state = BattleState.ESCAPED;

                    endBattle();
                }
                else
                {

                    state = BattleState.ENEMYTURN;
                    enemyAttackType();
                }

                break;
            default:
                break;
        }


    }

    public void enemyAttackType()
    {
        float attackPickNumber = Random.Range(0, 3);
        float rngNumber;
 
     

        switch (attackPickNumber)
        {
            case 0:
                rngNumber = Random.Range(0, 100);
                attackType = attackTypeState.light;

                if (rngNumber <= 85)
                {
                    print("light");

                    StartCoroutine(enemyAttack(1));


                }
                else
                {

                    StartCoroutine(missed());
                }
                break;
            case 1:
                rngNumber = Random.Range(0, 100);
                attackType = attackTypeState.medium;

                if (rngNumber <= 65)
                {
                    
                    StartCoroutine(enemyAttack(2));

                }
                else
                {

                    StartCoroutine(missed());
                }

                break;
            case 2:
                rngNumber = Random.Range(0, 100);
                attackType = attackTypeState.heavy;

                if (rngNumber <= 35)
                {
                    print("Heavy");
                    StartCoroutine(enemyAttack(3));

                }
                else
                {
                    StartCoroutine(missed());

                }
                break;
        }


    }

    IEnumerator playerAttack(int damageMultiplaier)
    {
        StartCoroutine(crountSound());
        state = BattleState.ENEMYTURN;
        yield return new WaitForSeconds(1f);


        switch (playerUnit.element)
        {
            case "Sun":
                
                if (WeatherSystem.currentWeather == weather.sunny)
                {
                    elementDamageBonus = 1.20f;
                }
                else
                {
                    elementDamageBonus = 1.00f;
                }
                break;
            case "Rain":
                
                if (WeatherSystem.currentWeather == weather.rainy)
                {
                    elementDamageBonus = 1.20f;
                }
                else
                {
                    elementDamageBonus = 1.00f;
                }

                break;
            case "Snow":
             
                if (WeatherSystem.currentWeather == weather.snowy)
                {
                    elementDamageBonus = 1.20f;
                }
                else
                {
                    elementDamageBonus = 1.00f;
                }

                break;


        }
      
        
        bool isDead = enemyUnit.takeDamage((playerUnit.damage * damageMultiplaier) * elementDamageBonus, playerUnit.shieldPanetration, damageTxt);

        
        enemyHUD.SetHP(enemyUnit.currentHealth);
        shakeScreen.StartCoroutine(shakeScreen.shaking(0.1f * damageMultiplaier));
        attackSoundWoosh();

        


        enemyHit.Play();


        damageTxt.enabled = true;

        yield return new WaitForSeconds(1f);
        
        damageTxt.enabled = false;

        if (isDead)
        {
            state = BattleState.WON;
            endBattle();
        }
        else
        {
            enemyAttackType();

        }
    }

    IEnumerator enemyAttack(int damageMultiplaier)
    {
       StartCoroutine(crountSound());
        yield return new WaitForSeconds(1f);

        switch (enemyUnit.element)
        {
            case "Sun":

                if (WeatherSystem.currentWeather == weather.sunny)
                {
                    elementDamageBonus = 1.20f;
                }
                else
                {
                    elementDamageBonus = 1.00f;
                }
                break;
            case "Rain":

                if (WeatherSystem.currentWeather == weather.rainy)
                {
                    elementDamageBonus = 1.20f;
                }
                else
                {
                    elementDamageBonus = 1.00f;
                }

                break;
            case "Snow":

                if (WeatherSystem.currentWeather == weather.snowy)
                {
                    elementDamageBonus = 1.20f;
                }
                else
                {
                    elementDamageBonus = 1.00f;
                }

                break;


        }

        bool isDead = playerUnit.takeDamage((enemyUnit.damage * damageMultiplaier) * elementDamageBonus, enemyUnit.shieldPanetration, damageTxt);
        playerHUD.SetHP(playerUnit.currentHealth);
        shakeScreen.StartCoroutine(shakeScreen.shaking(0.1f * damageMultiplaier) );
        
        attackSoundWoosh();
        playerHit.Play();

        

        damageTxt.enabled = true;

        yield return new WaitForSeconds(1f);
        damageTxt.enabled = false;

        if (isDead)
        {
            state = BattleState.LOST;
            endBattle();
            yield break;
        }
        else
        {
           StartCoroutine(playerTurn());
        }
    }

    void endBattle()
    {
        if (state == BattleState.WON)
        {
            matchStatMenu.SetActive(true);
            gameStatusTxt.text = "VICTORY";
            lootTxt.text = "XP 100 \n GOLD 12";
            returnButtonTxt.text = "FOR VALHALLA!";

        }
        else if (state == BattleState.LOST)
        {
            matchStatMenu.SetActive(true);
            lootTxt.text = "XP 10 \n GOLD 2";

            gameStatusTxt.text = "DEFEAT";
            returnButtonTxt.text = "FALL BACK!";



        }
        else if (state == BattleState.ESCAPED)
        {
            gameStatusTxt.text = "ESCAPED";
            lootTxt.text = "XP 0 \n GOLD 0";
            returnButtonTxt.text = "Return home";

            matchStatMenu.SetActive(true);

        }

    }
    IEnumerator missed()
    {
        
        if (state == BattleState.PLAYERTURN)
        {

            state = BattleState.ENEMYTURN;

            yield return new WaitForSeconds(1f);
            attackSoundWoosh();
            damageTxt.text = "Missed";
            damageTxt.enabled = true;

            yield return new WaitForSeconds(1f);
            damageTxt.enabled = false;
            enemyAttackType();
        }
        
        else if (state == BattleState.ENEMYTURN)
        {
            yield return new WaitForSeconds(1f);
            attackSoundWoosh();
            damageTxt.text = "Missed";
            damageTxt.enabled = true;

            yield return new WaitForSeconds(1f);
            damageTxt.enabled = false;

            StartCoroutine(playerTurn());
        }

    }

    void attackSoundWoosh()
    {
        switch (attackType)
        {
            case attackTypeState.light:

                audioSorces.sfxSource.PlayOneShot(audioSorces.whooshSfx[0]);

                break;
            case attackTypeState.medium:
                audioSorces.sfxSource.PlayOneShot(audioSorces.whooshSfx[1]);

                break;
            case attackTypeState.heavy:
                audioSorces.sfxSource.PlayOneShot(audioSorces.whooshSfx[2]);

                break;
            default:
                break;
        }
    }
    
    IEnumerator crountSound()
    {
        
        if(state == BattleState.PLAYERTURN)
        {
            yield return new WaitForSeconds(1);
            if (enemyUnit.type == EnemyType.Troll)
            {
                int randomSound = Random.Range(0, audioSorces.damagedSfxMonsters.Length);
                audioSorces.sfxSource.PlayOneShot(audioSorces.damagedSfxMonsters[randomSound]);

            }
            else if (enemyUnit.type == EnemyType.Human)
            {
                int randomSound = Random.Range(0, audioSorces.damagedSfx.Length);
                audioSorces.sfxSource.PlayOneShot(audioSorces.damagedSfx[randomSound]);

            }
            else if (enemyUnit.type == EnemyType.beast)
            {
                int randomSound = Random.Range(0, audioSorces.damagedSfxBests.Length);
                audioSorces.sfxSource.PlayOneShot(audioSorces.damagedSfxBests[randomSound]);

            }
        }
        else if (state == BattleState.ENEMYTURN)
        {
            yield return new WaitForSeconds(1);

            if (playerUnit.type == EnemyType.Troll)
            {
                int randomSound = Random.Range(0, audioSorces.damagedSfxMonsters.Length);
                audioSorces.sfxSource.PlayOneShot(audioSorces.damagedSfxMonsters[randomSound]);

            }
            else if (playerUnit.type == EnemyType.Human)
            {
                int randomSound = Random.Range(0, audioSorces.damagedSfx.Length);
                audioSorces.sfxSource.PlayOneShot(audioSorces.damagedSfx[randomSound]);

            }
            else if (enemyUnit.type == EnemyType.beast)
            {
                int randomSound = Random.Range(0, audioSorces.damagedSfxBests.Length);
                audioSorces.sfxSource.PlayOneShot(audioSorces.damagedSfxBests[randomSound]);

            }
        }

    }
    void playerSpawner()
    {
        switch (data.unitName)
        {
            case "TROLL":

                playerPrefab = godsAndCreatures[0];
                
                break;
            case "ODIN":
                playerPrefab = godsAndCreatures[1];
                break;
            case "THOR":
                playerPrefab = godsAndCreatures[2];
                break;

            default:
                break;
        }

        GameObject player = Instantiate(playerPrefab, battleStations[0].position, Quaternion.identity);
        playerUnit = player.GetComponent<unit>();
        gameSaveFile.playerData(playerUnit);

    }
}
