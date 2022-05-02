using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
       
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.I))
        {
            currentWeather = weather.sunny;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
           
            currentWeather = weather.snowy;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
           
            currentWeather = weather.rainy;
        }

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
