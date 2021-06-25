using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TutorialDisplay : MonoBehaviour
{
    [SerializeField]
    private GameObject tutorialUI1;
    [SerializeField]
    private GameObject tutorialUI2;
    [SerializeField]
    private GameObject tutorialUI3;
    [SerializeField]
    private GameObject tutorialUI4;
    [SerializeField]
    private GameObject tutorialUI5;
    [SerializeField]
    private GameObject tutorialUI6;
    private bool tu1 = false;
    private bool tu2 = false;
    private bool tu3 = false;
    private bool tu4 = false;
    private bool tu5 = false;
    private bool tu6 = false;
    private GameObject tutoialUIInstance;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var my_pos = transform.position;
        if(my_pos.x == 900 && !tu1)
        {
            if(tutoialUIInstance == null)
            {
                tutoialUIInstance = GameObject.Instantiate(tutorialUI1) as GameObject;
                Time.timeScale = 0f;
                tu1 = true;
                Debug.Log("tu1");
            }
        }
        if (my_pos.x == 1900 && !tu2)
        {
            if (tutoialUIInstance == null)
            {
                tutoialUIInstance = GameObject.Instantiate(tutorialUI2) as GameObject;
                Time.timeScale = 0f;
                tu2 = true;
            }
        }
        if (my_pos.x == 2300 && !tu3)
        {
            if (tutoialUIInstance == null)
            {
                tutoialUIInstance = GameObject.Instantiate(tutorialUI3) as GameObject;
                Time.timeScale = 0f;
                tu3 = true;
            }
        }
        if (my_pos.x == 3800 && !tu4)
        {
            if (tutoialUIInstance == null)
            {
                tutoialUIInstance = GameObject.Instantiate(tutorialUI4) as GameObject;
                Time.timeScale = 0f;
                tu4 = true;
            }
        }
        if (my_pos.x == 4800 && !tu5)
        {
            if (tutoialUIInstance == null)
            {
                tutoialUIInstance = GameObject.Instantiate(tutorialUI5) as GameObject;
                Time.timeScale = 0f;
                tu5 = true;
                
            }
        }
        if (my_pos.x == 6000 && !tu6)
        {
            if (tutoialUIInstance == null)
            {
                tutoialUIInstance = GameObject.Instantiate(tutorialUI6) as GameObject;
                Time.timeScale = 0f;
                tu6 = true;
            }
        }



        if (Input.GetKeyDown("joystick button 2") || Input.GetKeyDown(KeyCode.Backspace))
        {
            Destroy(tutoialUIInstance);
            Time.timeScale = 1f;
        }
    }
}
