using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ex_atk : MonoBehaviour
{
    [SerializeField]
    GameObject Golem;
    [SerializeField]
    GameObject _Ex;
    Rigidbody2D rigidbody2d;
    BoxCollider2D boxcollider2d;
    bool Boss_atk=false;
    private void Start()
    {
        Golem = GameObject.Find("Golem");
        rigidbody2d = this.gameObject.GetComponent<Rigidbody2D>();
        boxcollider2d = this.gameObject.GetComponent<BoxCollider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "rfBlock")
        {
            Boss_atk = true;
            rigidbody2d.velocity = new Vector3(Golem.transform.position.x, Golem.transform.position.y, 0);
            Trigger();
        }
        else if (Golem.GetComponent<golem>().golem_attack5 && collision.gameObject == GameObject.Find("scaffold_1"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);

        }
        else if (!(collision.gameObject.tag == "Boss_Atk"))
        {
            rigidbody2d.constraints = RigidbodyConstraints2D.FreezeAll;  
            Ex();

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Boss_atk)
        {
            Boss_atk = false;
            if (collision.gameObject.tag == "Boss")
            {
                Golem.GetComponent<golem>().Golem_HP -= 4;
                Destroy(gameObject);
            }

        }

    }
    public void Trigger()
    {
        //boxcollider2d.isTrigger = true;
    }
    public void Ex()
    {
        _Ex.SetActive(true);
        StartCoroutine("des");
    }
    IEnumerator des()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

}
