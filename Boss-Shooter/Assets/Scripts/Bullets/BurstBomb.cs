using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstBomb : MonoBehaviour {

    public GameObject bitprefab;

    public GameObject explosionprefab;

    public float speed;

    public float detonation;

    private float fuse;

    private int limit;


	// Use this for initialization
	void Start () {

        fuse = 0;

        limit = 0;
		
	}
	
	// Update is called once per frame
	void Update () {

        fuse += 1 * Time.deltaTime;

        if (fuse <= detonation){

            transform.Translate(new Vector2(0, (speed * Time.deltaTime)));

        }

        if (fuse >= detonation)
        {
            if (limit == 0){

                Explode();

             
            }

            limit = 1;
        }

        

    }

    void Explode()
    {
        GameObject BitD;

        GameObject BitU;

        GameObject BitR;

        GameObject BitL;

        BitD = (Instantiate(bitprefab, transform.position, transform.rotation)) as GameObject;

        BitU = (Instantiate(bitprefab, transform.position, transform.rotation)) as GameObject;

        BitU.GetComponent<Rigidbody2D>().transform.Rotate(new Vector3(0, 0, 180));

        BitR = (Instantiate(bitprefab, transform.position, transform.rotation)) as GameObject;

        BitR.GetComponent<Rigidbody2D>().transform.Rotate(new Vector3(0, 0, 90));

        BitL = (Instantiate(bitprefab, transform.position, transform.rotation)) as GameObject;

        BitL.GetComponent<Rigidbody2D>().transform.Rotate(new Vector3(0, 0, 270));

        Destroy(BitD, 3);

        Destroy(BitU, 3);

        Destroy(BitR, 3);

        Destroy(BitL, 3);


        GameObject Explosion;

        Explosion = (Instantiate(explosionprefab, transform.position, transform.rotation)) as GameObject;

        Destroy(Explosion, 1);
    }
}
