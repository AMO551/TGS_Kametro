using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore : MonoBehaviour
{
   
    public float ore_a = 0;          //zÎA‚Ì‰Šú‰»
    public float ore_b = 0;          //zÎB‚Ì‰Šú‰»
    public float ore_c = 0;          //zÎC‚Ì‰Šú‰»
    public float ore_d = 0;          //zÎD‚Ì‰Šú‰»
    private bool Updeta = false;     //ƒAƒbƒvƒf[ƒg‚ğfalse‚É‰Šú‰»
    private bool Ore_A = false;      //zÎA‚Ìfalse‚É‰Šú‰»
    private bool Ore_B = false;      //zÎA‚Ìfalse‚É‰Šú‰»
    private bool Ore_C = false;      //zÎA‚Ìfalse‚É‰Šú‰»
    private bool Ore_D = false;      //zÎA‚Ìfalse‚É‰Šú‰»

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Player_HP‚ğƒAƒbƒvƒf[ƒg‚µ‚Ä‚¢‚­
        if (Updeta == true)
        {
            //zÎA‚ªˆ—‚³‚ê‚Ä‚¢‚é‚©Œ©‚é
            if (Ore_A == true)
            {
                ore_a = 1;@@@//”½ËzÎ1ŒÂ—^‚¦‚é
                ore_b = 2;      //d—ÍzÎ2ŒÂ—^‚¦‚é
                Ore_A = false;  //AzÎ
            }
            //zÎB‚ªˆ—‚³‚ê‚Ä‚¢‚é‚©Œ©‚é
            if (Ore_B == true)
            {
                ore_a = 2;      //”½ËzÎ2ŒÂ—^‚¦‚é
                ore_b = 1;      //d—ÍzÎ1ŒÂ—^‚¦‚é
                Ore_B = false;  //BzÎ
            }
            //zÎC‚ªˆ—‚³‚ê‚Ä‚¢‚é‚©Œ©‚é
            if (Ore_C == true)
            {
                ore_a = 1;      //”½ËzÎ1ŒÂ—^‚¦‚é
                ore_b = 3;      //d—ÍzÎ3ŒÂ—^‚¦‚é
                Ore_C = false;  //CzÎ
            }
            //zÎD‚ªˆ—‚³‚ê‚Ä‚¢‚é‚©Œ©‚é
            if (Ore_D == true)
            {
                ore_a = 3;      //”½ËzÎ3ŒÂ—^‚¦‚é
                ore_b = 1;      //d—ÍzÎ1ŒÂ—^‚¦‚é
                Ore_D = false;  //DzÎ
            }
            Updeta = false;     //update‚Ìfalse‚É‚·‚é
        }
        else
        {
            ore_a = 0;          //A‚ÌzÎ‚Ìó‚¯“n‚µ‚ğ‰Šú‚É–ß‚·
            ore_b = 0;          //B‚ÌzÎ‚Ìó‚¯“n‚µ‚ğ‰Šú‚É–ß‚·
            ore_c = 0;          //C‚ÌzÎ‚Ìó‚¯“n‚µ‚ğ‰Šú‚É–ß‚·
            ore_d = 0;          //D‚ÌzÎ‚Ìó‚¯“n‚µ‚ğ‰Šú‚É–ß‚·
        }

    }
    //•¨‚ª’Ê‰ß‚µ‚½‚©Œ©‚é
    void OnCollisionEnter2D(Collision2D collision2d)
    {
        //Debug.Log("•¨‚É‚ ‚½‚Á‚½");
        //ƒvƒŒƒCƒ„[‚ª“–‚½‚Á‚Ä‚¢‚é‚©‚Ì”»’è
        if (collision2d.gameObject.CompareTag("Player"))
        {
            Debug.Log("ƒvƒŒƒCƒ„[‚ğŠm”F");
            //‚Ç‚ÌzÎ‚ğ‚½‚½‚¢‚½‚Ì‚©‚Ì”»’èiAzÎj
            if (gameObject.CompareTag("Ore_A"))
            {
                //zÎ‚ğÁ‚·
                Destroy(gameObject);
                //zÎA‚ğtrue‚É‚·‚é
                Ore_A = true;
                //Updata‚ğtrue‚É‚·‚é
                Updeta = true;
                Debug.Log("Ore_A‚ğŠm”F");
            }
            //‚Ç‚ÌzÎ‚ğ‚½‚½‚¢‚½‚Ì‚©‚Ì”»’èiBzÎj
            if (gameObject.CompareTag("Ore_B"))
            {
                //zÎ‚ğÁ‚·
                Destroy(gameObject);
                //zÎB‚ğtrue‚É‚·‚é
                Ore_B = true;
                //Updata‚ğtrue‚É‚·‚é
                Updeta = true;
            }
            //‚Ç‚ÌzÎ‚ğ‚½‚½‚¢‚½‚Ì‚©‚Ì”»’èiCzÎj
            if (gameObject.CompareTag("Ore_C"))
            {
                //zÎ‚ğÁ‚·
                Destroy(gameObject);
                //zÎC‚ğtrue‚É‚·‚é
                Ore_C = true;
                //Updata‚ğtrue‚É‚·‚é
                Updeta = true;
            }
            //‚Ç‚ÌzÎ‚ğ‚½‚½‚¢‚½‚Ì‚©‚Ì”»’èiDzÎj
            if (gameObject.CompareTag("Ore_D"))
            if (gameObject.CompareTag("Ore_D"))
            {
                //zÎ‚ğÁ‚·
                Destroy(gameObject);
                //zÎD‚ğtrue‚É‚·‚é
                Ore_D = true;
                //Updata‚ğtrue‚É‚·‚é
                Updeta = true;
            }
        }
    }
}
