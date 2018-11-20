using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : MonoBehaviour {
    public Transform target;
    //public float maxHealth = 20f; //the max health of enemy gameObject
    //public float currentHealth; //current health of the enemy gameObject

    public float speed = 2;
    public int damage = 1;
    public float range = 3;

    public float time = 5;

    // Use this for initialization
    void Start() {
        //currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update() {

        if (Vector2.Distance(transform.position, target.position) <= range)//Allows players to dodge homing obj.
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);//Move towards players.
            if ((Vector2.Distance(transform.position, target.position) < 0.5))
                Debug.Log("attack");
        }
        else
            transform.Translate(new Vector2(0, (-speed * Time.deltaTime)));//Move down if not near player.
        die();
    }

    void die(){
        Destroy(gameObject, time);
    }
}
