using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject[] menu;


   //camera
    public Camera cam;
  

    // Touch controls 
    Vector2 startTouchPosition;
    Vector2 endTouchPosition;

    bool hasClosed;

    // scripts
    public SceneManager_ sceneManager_;

    
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(sceneManager_.searching != true)
        {
            controls();
        }
        
    }
  
    
    void closeAllMenus(){
        foreach (GameObject m in menu)
        {
            m.SetActive(false);
        }
        hasClosed = true;
    }

    public void controls()
    {

        if (cam.transform.position.x == -4.7f && hasClosed == false)
        {
            closeAllMenus();
            menu[0].SetActive(true);
        }
        else if (cam.transform.position.x == 4.7f && hasClosed == false)
        {
            closeAllMenus();
            menu[1].SetActive(true);
        }
        else if (cam.transform.position.x == 0f && hasClosed == false)
        {
            closeAllMenus();
            menu[2].SetActive(true);
        }



        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {


            if (cam.transform.position.x < 4.7f)
            {
                Debug.Log("Swipe Right");
                cam.transform.position = new Vector3(cam.transform.position.x + 4.7f, cam.transform.position.y, cam.transform.position.z);
                hasClosed = false;
            }

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (cam.transform.position.x > -4.7f)
            {
                Debug.Log("Swipe Left");
                cam.transform.position = new Vector3(cam.transform.position.x - 4.7f, cam.transform.position.y, cam.transform.position.z);

                hasClosed = false;
            }
        }



        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                startTouchPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                endTouchPosition = touch.position;
                if (endTouchPosition.x - startTouchPosition.x > 100)
                {
                    if (cam.transform.position.x < 4.7f)
                    {
                        Debug.Log("Swipe Right");
                        cam.transform.position = new Vector3(cam.transform.position.x + 4.7f, cam.transform.position.y, cam.transform.position.z);
                        hasClosed = false;
                    }


                }
                else if (startTouchPosition.x - endTouchPosition.x > 100)
                {
                    if (cam.transform.position.x > -4.7f)
                    {
                        Debug.Log("Swipe Left");
                        cam.transform.position = new Vector3(cam.transform.position.x - 4.7f, cam.transform.position.y, cam.transform.position.z);

                        hasClosed = false;
                    }


                }
            }
        }
    }    
}
