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

    public LineRenderer laserLineRenderer;

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

        SetupLine();
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

    void SetupLine()
    {
        laserLineRenderer.sortingLayerName = "OnTop";
        laserLineRenderer.sortingOrder = 5;
        laserLineRenderer.SetVertexCount(2);
        laserLineRenderer.SetWidth(0.1f, 0.1f);
        laserLineRenderer.useWorldSpace = true;
        laserLineRenderer.material.color = Color.white;
    }

    void fire()
	{
        if (firemode == 0)
        {
            firingOrigin = new Vector2(firingPoint.position.x, firingPoint.position.y);
            hit = Physics2D.Raycast(firingOrigin, fireDirection);
            Debug.DrawRay(firingOrigin, fireDirection);

            if (hit && hit.collider.CompareTag("Enemy"))
            {
                damaging = hit.collider.GetComponent<enemyBehavior>();
            }
			firingOrigin = new Vector2(firingPoint.position.x, firingPoint.position.y);

			hit = Physics2D.Raycast(firingOrigin, fireDirection);
            Vector2 endPosition = firingOrigin + ( shootingDistance * fireDirection );

            if (hit) {
                endPosition = hit.point;
            }

            laserLineRenderer.SetPosition(0, firingOrigin);
            laserLineRenderer.SetPosition(1, endPosition);

			if (hit && hit.collider.CompareTag("Enemy"))
			{
				damaging = hit.collider.GetComponent<enemyBehavior>();
                // Debug.Log(Time.deltaTime);

                damaging.currentHealth -= (Time.deltaTime) * dps;

            }

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
