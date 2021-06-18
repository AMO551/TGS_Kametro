using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyControl : MonoBehaviour
{
    public float nowPosi;
    public GameObject player;
    public GameObject W_a;
    private float targetTime = 1.0f;
    private float currentTime = 0;
    private float orientation;
    public Transform bullet;
    void Start() 
    {
        nowPosi = this.transform.position.y;
    }

    void Update() 
    {
        transform.position = new Vector3(transform.position.x, nowPosi + Mathf.PingPong(Time.time * 10, 10f)*50, transform.position.z);    
        currentTime += Time.deltaTime;
        if(targetTime<currentTime)
        {

            currentTime = 0;
            var pos = this.gameObject.transform.position;
            Vector2 vec = player.transform.position - pos;
            var t = Instantiate(W_a,bullet) as GameObject;
            if (vec.x <= 0)
            {
                pos = new Vector3 (this.gameObject.transform.position.x-100, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
            }
            if (vec.x > 0)
            {
                pos = new Vector3(this.gameObject.transform.position.x + 100, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
            }
           
            t.transform.position = pos;
            vec = player.transform.position-pos;
            //Debug.Log(vec);
            t.GetComponent<Rigidbody2D>().velocity= vec;
        }
    }
}