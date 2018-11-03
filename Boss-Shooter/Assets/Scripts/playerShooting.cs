using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShooting : MonoBehaviour {
	[Header("Shooting Number Variables")]
	public float shootingDistance = 300.0f; //how far the bullet should travel (detect enemy)
	public Transform firingPoint; //Where the bullet will travel/check from (realistic gun)
    public int dps = 10; // damage per second
    private Vector2 mousePosition; //position of mouse
	private Vector2 firingOrigin; //the (x,y) coordinates of the firingpoint gameObject
	private RaycastHit2D hit; //the line the bullet will follow
    private RaycastHit2D[] spreadHits;
    private Vector2[] spreadDirections;
    private enemyBehavior damaging; //the enemy script to access variables
	private weaponInfo useClip; //the weapon info script to access variables
    private Vector2 fireDirection; // the direction that weapon shoots
    public int firemode = 0; //Different firing modes

	// Use this for initialization
	void Start () {

        useClip = firingPoint.GetComponent<weaponInfo>();
		useClip = firingPoint.GetComponent<weaponInfo>();

        fireDirection = new Vector2(0, 1); // weapon will shoot up
        spreadHits = new RaycastHit2D[3];

        spreadDirections = new Vector2[3];
        spreadDirections[0] = new Vector2(-.5f, ((Mathf.Sqrt(3)/2)));
        spreadDirections[1] = new Vector2(0, 1);
        spreadDirections[2] = new Vector2(.5f, ((Mathf.Sqrt(3))/2));

        firemode = 0;
    }
	
	// Update is called once per frame
	void Update () {
        fire();

        if (Input.GetButtonDown("Switch"))
        {
            firemode = (firemode + 1) % 2;
        }
        //Debug.Log(firemode);
    }

    void fire()
	{if (firemode == 0)
        {
            //if your current ammo is empty, we try to reload
            // if (useClip.currentClip == 0)
            // {
            // 	useClip.reload();
            // }
            // else //you can fire if u have ammo in your clip
            // {
            /*Handles player shooting bullets that checks within a line (hitscan)*/
            firingOrigin = new Vector2(firingPoint.position.x, firingPoint.position.y);
            //mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
            //Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            //Debug.Log(firingOrigin);
            hit = Physics2D.Raycast(firingOrigin, fireDirection);
            //removed mouse imputs

            //Make sure that the firingOrigin is far from the player gameObject 
            //to ensure that the raycast hits the enemies and not collide with the player itself
            //and tag all enemies with the same tag to compare
            Debug.DrawRay(firingOrigin, fireDirection);

            if (hit && hit.collider.CompareTag("Enemy"))
            {
                damaging = hit.collider.GetComponent<enemyBehavior>();
                // Debug.Log(Time.deltaTime);

                damaging.currentHealth -= (Time.deltaTime) * dps;

            }

            //fires one bullet, subtracting from the current ammo 
            // useClip.currentClip--;
            // commented to make no reload
            // }

        }
    if (firemode == 1)
        {
            firingOrigin = new Vector2(firingPoint.position.x, firingPoint.position.y);


            for (int i = 0; i < spreadHits.Length; i++)
            {
                spreadHits[i] = Physics2D.Raycast(firingOrigin, spreadDirections[i], 5);
                hit = spreadHits[i];
                Debug.DrawRay(firingOrigin, spreadDirections[i]);
                if (hit && hit.collider.CompareTag("Enemy"))
                {
                    damaging = hit.collider.GetComponent<enemyBehavior>();
                    // Debug.Log(Time.deltaTime);
                    Debug.Log("weapon: " + i + " hit");

                    damaging.currentHealth -= (Time.deltaTime) * dps;

                }
            }
        }
	}
}
