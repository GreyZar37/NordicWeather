using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum weather
{
    sunny,
    rainy,
    snowy
}
public class WeatherSystem : MonoBehaviour
{
    public GameObject sommer;
    public GameObject winter;
    public GameObject spring;

    public static weather currentWeather;


    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            float randomWeather;

            switch (randomWeather = Random.Range(0, 3))
            {
                case 0:
                    currentWeather = weather.sunny;
                    break;
                case 1:
                    currentWeather = weather.rainy;
                    break;
                case 2:
                    currentWeather = weather.snowy;
                    break;
            }
        }
    
    }

    // Update is called once per frame
    void Update()
    {
     
        

        switch (currentWeather)
        {
            case weather.sunny:
                sommer.SetActive(true);
                winter.SetActive(false);
                spring.SetActive(false);
                break;
            case weather.rainy:
                sommer.SetActive(false);
                winter.SetActive(false);
                spring.SetActive(true);
                break;
            case weather.snowy:
                sommer.SetActive(false);
                winter.SetActive(true);
                spring.SetActive(false);
                break;
        }



    }
}
