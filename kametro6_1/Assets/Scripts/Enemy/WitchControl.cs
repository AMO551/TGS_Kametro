using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WitchControl : MonoBehaviour
{
    public float nowPosi;
    public GameObject player;
    public GameObject W_a;
    private float targetTime = 1.0f;
    private float currentTime = 0;
    public Transform bullet;
    TriggerControl triggerControl;
    public GameObject Area;
    void Start()
    {
        nowPosi = this.transform.position.y;
        triggerControl = Area.GetComponent<TriggerControl>();
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, nowPosi + Mathf.PingPong(Time.time * 10, 10f) * 50, transform.position.z);
        if (triggerControl.InArea == true)
        {
            currentTime += Time.deltaTime;
            if (targetTime < currentTime)
            {
                currentTime = 0;
                var pos = this.gameObject.transform.position;
                var t = Instantiate(W_a, bullet) as GameObject;
                t.transform.position = pos;
                Vector2 vec = player.transform.position - pos;
                //Debug.Log(vec);
                t.GetComponent<Rigidbody2D>().velocity = vec;
            }
        }
    }
}