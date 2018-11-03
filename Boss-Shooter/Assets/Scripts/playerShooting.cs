using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShooting : MonoBehaviour {
	[Header("Shooting Number Variables")]
	public float shootingDistance = 5f; //how far the bullet should travel (detect enemy)
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

    public LineRenderer[] lineRenderers;
    
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

        // lineRenderers = new LineRenderer[3];
        SetupRenderer(lineRenderers[0]);
        SetupRenderer(lineRenderers[1]);
        SetupRenderer(lineRenderers[2]);
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Switch"))
        {
            firemode = (firemode + 1) % 2;
            changeRenderer();
        }

        fire();
        //Debug.Log(firemode);
    }

    void changeRenderer () {
        if (firemode == 0) {
            lineRenderers[0].enabled = false;
            lineRenderers[2].enabled = false;
        }
        if (firemode == 1) {
            lineRenderers[0].enabled = true;
            lineRenderers[2].enabled = true;
        }
    }

    void SetupRenderer(LineRenderer renderer)
    {
        renderer.sortingLayerName = "OnTop";
        renderer.sortingOrder = 5;
        renderer.SetVertexCount(2);
        renderer.SetWidth(0.1f, 0.1f);
        renderer.useWorldSpace = true;
        renderer.enabled = true;
        renderer.material.color = Color.white;
    }

    void fire()
	{
        firingOrigin = new Vector2(firingPoint.position.x, firingPoint.position.y);

        if (firemode == 0)
        {
            straightShotMode(300f);
        }
        if (firemode == 1)
        {
            spreadShotMode();
        }
	}

    void straightShotMode (float distance) {
        // Debug.DrawRay(firingOrigin, fireDirection);

        hit = Physics2D.Raycast(firingOrigin, fireDirection);
        updateRendererPosititions(lineRenderers[1], hit, fireDirection, distance);

        if (hit && hit.collider.CompareTag("Enemy"))
        {
            damaging = hit.collider.GetComponent<enemyBehavior>();
            // Debug.Log(Time.deltaTime);

            damaging.currentHealth -= (Time.deltaTime) * dps;

        }
    }

    void spreadShotMode () {
        for (int i = 0; i < spreadHits.Length; i++)
        {
            spreadHits[i] = Physics2D.Raycast(firingOrigin, spreadDirections[i], shootingDistance);
            hit = spreadHits[i];
            // Debug.DrawRay(firingOrigin, spreadDirections[i]);
            updateRendererPosititions(lineRenderers[i], spreadHits[i], spreadDirections[i], shootingDistance);
            if (hit && hit.collider.CompareTag("Enemy"))
            {
                damaging = hit.collider.GetComponent<enemyBehavior>();
                // Debug.Log(Time.deltaTime);
                Debug.Log("weapon: " + i + " hit");

                damaging.currentHealth -= (Time.deltaTime) * dps;

            }
        }
    }

    void updateRendererPosititions (LineRenderer renderer, RaycastHit2D hit, Vector2 direction, float distance) {
        Vector2 endPosition = firingOrigin + ( distance * direction );

        if (hit) {
            endPosition = hit.point;
        }

        renderer.SetPosition(0, firingOrigin);
        renderer.SetPosition(1, endPosition);
    }
}
