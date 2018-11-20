using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFiring : MonoBehaviour
{

    public GameObject bulletprefab;

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Fired");
            GameObject Clone;
            
            Clone = (Instantiate(bulletprefab, transform.position, transform.rotation)) as GameObject;
            Destroy(Clone, 1);
        }
    }
}
