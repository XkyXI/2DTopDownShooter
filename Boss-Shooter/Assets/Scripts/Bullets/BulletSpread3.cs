using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpread3 : MonoBehaviour {

    public float speed;

    // Use this for initialization
    void Start () {

 
    speed = speed / 9;

}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector2(0, (speed * (Mathf.Sqrt(3) / 2))));
    }
}
