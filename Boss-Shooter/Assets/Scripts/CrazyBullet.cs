using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrazyBullet : MonoBehaviour {

    private float interval;

    public int speed;


	// Use this for initialization
	void Start () {

        interval = 75;
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(new Vector2(0, (speed * Time.deltaTime)));

        if (interval >= 50)
        {
            transform.Translate(new Vector2((8 * Time.deltaTime), 0));
        }

        if (interval < 50)
        {
            transform.Translate(new Vector2((-8 * Time.deltaTime), 0));
        }

        interval += 100 * Time.deltaTime;

        if (interval >= 100)
        {
            interval = 0;
        }

    }
}
