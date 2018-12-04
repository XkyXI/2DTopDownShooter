using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpread1 : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {

        speed = speed / 10;

	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector2(speed*-.5f, (speed*(Mathf.Sqrt(3) / 2))));
    }
}
