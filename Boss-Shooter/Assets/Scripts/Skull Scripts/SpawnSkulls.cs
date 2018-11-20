using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSkulls : MonoBehaviour
{
    public GameObject skull;
    //public GameObject enemy;

    public float time;
    public float range;
    public Transform target;
    //public Transform test;
    public bool use_health = false;

    private Homing settingsH;
    private Look settingsL;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !use_health)
        {
            Debug.Log("Fired");
            GameObject Clone;

            Clone = (Instantiate(skull, transform.position, transform.rotation)) as GameObject;
            settingsH = Clone.GetComponent<Homing>();
            settingsH.time = time;
            settingsH.target = target;

            settingsL = Clone.GetComponent<Look>();
            settingsL.target = target;
            settingsL.range = range;
        }

        //else if(use_health )
        //{

        //}
    }
}
