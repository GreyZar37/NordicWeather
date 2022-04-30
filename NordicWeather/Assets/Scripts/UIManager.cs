using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject[] menu;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void openStats()
    {
        menu[0].GetComponent<Animator>().SetTrigger("open");
    }
    public void openGODmenu()
    {
        
    }
    
}
