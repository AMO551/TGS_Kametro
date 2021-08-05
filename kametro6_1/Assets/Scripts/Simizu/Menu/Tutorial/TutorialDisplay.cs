using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TutorialDisplay : MonoBehaviour
{
    #region éŒ¾
    //private------------------------------------
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
    [SerializeField]
    private GameObject tutorialUI7;
    private bool tu1 = false;
    private bool tu2 = true;
    private bool tu3 = true;
    private bool tu4 = true;
    private bool tu5 = true;
    private bool tu6 = true;
    private bool tu7 = true;
    private GameObject tutoialUIInstance;
    private float tri;
    #endregion
    #region Update
    void Update()
    {
        var my_pos = transform.position;
        //à–¾‚P
        if(my_pos.x >= 900 && !tu1)
        {
            if(tutoialUIInstance == null)
            {
                tutoialUIInstance = GameObject.Instantiate(tutorialUI1) as GameObject;
                //Time.timeScale = 0f;
                tu1 = true;
                tu2 = false;
                Debug.Log("tu1");
            }
        }
        //à–¾‚Q
        if (my_pos.x >= 1900 && !tu2)
        {
            if (tutoialUIInstance == null)
            {
                tutoialUIInstance = GameObject.Instantiate(tutorialUI2) as GameObject;
                //Time.timeScale = 0f;
                tu2 = true;
                tu3 = false;
            }
        }
        //à–¾‚R
        if (my_pos.x >= 2300 && !tu3)
        {
            if (tutoialUIInstance == null)
            {
                tutoialUIInstance = GameObject.Instantiate(tutorialUI3) as GameObject;
                //Time.timeScale = 0f;
                tu3 = true;
                tu4 = false;
            }
        }
        //à–¾‚S
        if (my_pos.x >= 3800 && !tu4)
        {
            if (tutoialUIInstance == null)
            {
                tutoialUIInstance = GameObject.Instantiate(tutorialUI4) as GameObject;
                //Time.timeScale = 0f;
                tu4 = true;
                tu5 = false;
            }
        }
        //à–¾‚T
        if (my_pos.x >= 4800 && !tu5)
        {
            if (tutoialUIInstance == null)
            {
                tutoialUIInstance = GameObject.Instantiate(tutorialUI5) as GameObject;
                //Time.timeScale = 0f;
                tu5 = true;
                tu6 = false;

            }
        }
        //à–¾‚U
        if (my_pos.x >= 6000 && !tu6)
        {
            if (tutoialUIInstance == null)
            {
                tutoialUIInstance = GameObject.Instantiate(tutorialUI6) as GameObject;
                //Time.timeScale = 0f;
                tu6 = true;
                tu7 = false;
            }
        }
        //à–¾‚V
        if (my_pos.x >= 6400 && !tu7)
        {
            if (tutoialUIInstance == null)
            {
                tutoialUIInstance = GameObject.Instantiate(tutorialUI7) as GameObject;
                //Time.timeScale = 0f;
                tu7 = true;
            }
        }
        // ƒuƒƒbƒN‘S”j‰ó
        tri = Input.GetAxis("L_R_Trigger");
        if (tri > 0)
        {
            Debug.Log("R_Trigger");
            Destroy(tutoialUIInstance);
            Time.timeScale = 1f;
            tutoialUIInstance = null;
        }
    }
    #endregion
}
