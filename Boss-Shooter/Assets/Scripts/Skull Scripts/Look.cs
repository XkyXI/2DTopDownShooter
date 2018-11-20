using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour {
    public Transform target;
    public float range = 0;
    public bool toggle_always = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (toggle_always || Vector2.Distance(transform.position, target.position) <= range)
        {
            Vector3 dir = target.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90f;//Calculates the angle the object should turn.
                                                                          //90f added to account for starting facing position
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

    }
}
