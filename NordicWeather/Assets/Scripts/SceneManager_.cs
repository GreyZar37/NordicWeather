using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneManager_ : MonoBehaviour
{
    public Button searchButton;
    public Button returnButton;

    bool sceneLoading;

    public bool searching;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (searchButton != null)
        {
            searchButton.onClick.AddListener(() =>
            {
                searching = true;
                StartCoroutine(findMatch());
            });
        }

        if (returnButton != null)
        {
            returnButton.onClick.AddListener(() =>
            {
                StartCoroutine(returnToMain());
            });
        }

    }


    IEnumerator findMatch()
    {
        if (sceneLoading == false) 
        {
            searching = true;
            sceneLoading = true;
            searchButton.GetComponentInChildren<TextMeshProUGUI>().text = "Searching...";
            yield return new WaitForSeconds(1);

            SceneManager.LoadScene("BattleScene");
        }
   


    }

    IEnumerator returnToMain()
    {
        if (sceneLoading == false)
        {
            print("Returning");
            sceneLoading = true;

            yield return new WaitForSeconds(1);

            SceneManager.LoadScene("MainMenu");
        }

    }
}
