//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.PlayerLoop;

public enum Ore_TB
{
    None,
    Ore_A,
    Ore_B,
    Ore_C,
    Ore_D,
    Ore_E,
    Ore_F,
    Ore_G,
    Ore_H,
}

public class Ore : MonoBehaviour
{
   
    public int ore_a = 0;          //zÎA‚Ì‰Šú‰»
    public int ore_b = 0;          //zÎB‚Ì‰Šú‰»
    public int ore_c = 0;          //zÎC‚Ì‰Šú‰»
    private bool Updeta = false;     //ƒAƒbƒvƒf[ƒg‚ğfalse‚É‰Šú‰»
    private bool Updeta_t = false; //zÎ‚ğ‚Ù‚©‚ÌƒXƒNƒŠƒvƒg‚É“n‚·                           

    public Ore_TB m_type = Ore_TB.None;
    // Update is called once per frame

    public void Start()
    {

    }
    void Update()
    {
        if (Updeta_t)
        {
            if (Updeta == true)
            {
                ore_a = 0;          //zÎA‚Ì‰Šú‰»
                ore_b = 0;          //zÎB‚Ì‰Šú‰»
                ore_c = 0;          //zÎC‚Ì‰Šú‰»

                //ƒf[ƒ^‚ğ“n‚·ˆ—‚ğs‚¤
                SoundManager.Instance.Play_SE(0, 18);
                //ƒfƒXƒgƒƒCˆ—
                Destroy(gameObject);
            }

        }
        else
        {
            //Player_HP‚ğƒAƒbƒvƒf[ƒg‚µ‚Ä‚¢‚­
            if (Updeta == true)
            {
                Ore_processing();
            }
        }
    }
    void Ore_processing()
    {
        Ore ore = this.gameObject.GetComponent<Ore>();
        switch (ore.m_type)
        {
            //zÎA‚ªˆ—‚³‚ê‚Ä‚¢‚é‚©Œ©‚é
            case Ore_TB.Ore_A:
                ore_a = 1;   //”½ËzÎ1ŒÂ—^‚¦‚é
                ore_b = 2;      //d—ÍzÎ2ŒÂ—^‚¦‚é
                GameMainContol.Instance.addCrystal(ore_a, ore_b, ore_c);
                Updeta_t = true; //ˆ—‚ÉˆÚ“®
                break;
            //zÎB‚ªˆ—‚³‚ê‚Ä‚¢‚é‚©Œ©‚é
            case Ore_TB.Ore_B:
                ore_a = 2;      //”½ËzÎ2ŒÂ—^‚¦‚é
                ore_b = 1;      //d—ÍzÎ1ŒÂ—^‚¦‚é
                GameMainContol.Instance.addCrystal(ore_a, ore_b, ore_c);
                Updeta_t = true; //ˆ—‚ÉˆÚ“®
                break;
            //zÎC‚ªˆ—‚³‚ê‚Ä‚¢‚é‚©Œ©‚é
            case Ore_TB.Ore_C:
                ore_a = 1;      //”½ËzÎ1ŒÂ—^‚¦‚é
                ore_b = 3;      //d—ÍzÎ3ŒÂ—^‚¦‚é
                GameMainContol.Instance.addCrystal(ore_a, ore_b, ore_c);
                Updeta_t = true; //ˆ—‚ÉˆÚ“®
                break;
            //zÎD‚ªˆ—‚³‚ê‚Ä‚¢‚é‚©Œ©‚é
            case Ore_TB.Ore_D:
                ore_a = 3;      //”½ËzÎ3ŒÂ—^‚¦‚é
                ore_b = 1;      //d—ÍzÎ1ŒÂ—^‚¦‚é
                GameMainContol.Instance.addCrystal(ore_a, ore_b, ore_c);
                Updeta_t = true; //ˆ—‚ÉˆÚ“®
                break;
            //zÎE‚ªˆ—‚³‚ê‚Ä‚¢‚é‚©Œ©‚é
            case Ore_TB.Ore_E:
                ore_a = 1;   //”½ËzÎ1ŒÂ—^‚¦‚é
                ore_b = 1;      //d—ÍzÎ1ŒÂ—^‚¦‚é
                ore_c = 2;      //”š”­zÎ2ŒÂ—^‚¦‚é
                GameMainContol.Instance.addCrystal(ore_a, ore_b, ore_c);
                Updeta_t = true; //ˆ—‚ÉˆÚ“®
                break;
            //zÎF‚ªˆ—‚³‚ê‚Ä‚¢‚é‚©Œ©‚é
            case Ore_TB.Ore_F:
                ore_a = 1;      //”½ËzÎ1ŒÂ—^‚¦‚é
                ore_b = 0;      //d—ÍzÎ0ŒÂ—^‚¦‚é
                ore_c = 3;      //”š”­zÎ3ŒÂ—^‚¦‚é
                GameMainContol.Instance.addCrystal(ore_a, ore_b, ore_c);
                Updeta_t = true; //ˆ—‚ÉˆÚ“®
                break;
            //zÎG‚ªˆ—‚³‚ê‚Ä‚¢‚é‚©Œ©‚é
            case Ore_TB.Ore_G:
                ore_a = 1;      //”½ËzÎ1ŒÂ—^‚¦‚é
                ore_b = 2;      //d—ÍzÎ2ŒÂ—^‚¦‚é
                ore_c = 1;      //”š”­zÎ1ŒÂ—^‚¦‚é
                GameMainContol.Instance.addCrystal(ore_a, ore_b, ore_c);
                Updeta_t = true; //ˆ—‚ÉˆÚ“®
                break;
            //zÎH‚ªˆ—‚³‚ê‚Ä‚¢‚é‚©Œ©‚é
            case Ore_TB.Ore_H:
                ore_a = 2;      //”½ËzÎ2ŒÂ—^‚¦‚é
                ore_b = 0;      //d—ÍzÎ0ŒÂ—^‚¦‚é
                ore_c = 2;      //”š”­zÎ2ŒÂ—^‚¦‚é
                GameMainContol.Instance.addCrystal(ore_a, ore_b, ore_c);
                Updeta_t = true; //ˆ—‚ÉˆÚ“®
                break;
        }
    }


    //•¨‚ª’Ê‰ß‚µ‚½‚©Œ©‚é
    void OnTriggerEnter2D(Collider2D collision2d)
    {
        //Debug.Log("zÎƒhƒƒbƒv");
        //Debug.Log("•¨‚É‚ ‚½‚Á‚½a");
        //ƒvƒŒƒCƒ„[‚ª“–‚½‚Á‚Ä‚¢‚é‚©‚Ì”»’è
        if (collision2d.gameObject.CompareTag("P_A"))
        {
            Debug.Log("ƒvƒŒƒCƒ„[‚ğŠm”F");
            Updeta = true;
        }
    }
}
