using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyBehavior : MonoBehaviour {
	[Header("Enemy Health")]
	public float maxHealth = 100f; //the max health of enemy gameObject
	public float currentHealth; //current health of the enemy gameObject

    public Image healthBar;
    //public Text healthText;
    public bool has_health_UI = false;

    //public Transform target;//Used to get target's location for movement/looking.

    // Use this for initialization
    void Start () {
		//initalize the current health to starting health
		currentHealth = maxHealth;
        if (has_health_UI)
        {
            //healthText.text = (currentHealth).ToString("F2") + "%";//Adjusts text showing health. "F2" to indicate up to 2 dec.
            healthBar.fillAmount = currentHealth / maxHealth;//Fills up the red bar according to health percentage.
        }
    }
	
	// Update is called once per frame
	void Update () {
        //if current health is 0, this object should die
        if (has_health_UI)
        {
            //healthText.text = (currentHealth).ToString("F2") + "%";
            healthBar.fillAmount = currentHealth / maxHealth;
        }
        if (currentHealth <= 0)
            Die();

        //Debug.Log(currentHealth);

        //Method call to look at player.
        //Look(target);
    }

	void Die()
	{
		//kill this object
		Destroy(gameObject);
	}

    //private void Look(Transform toLook)//Taken from Luna Scene
    //{
        //Vector3 dir = toLook.position - transform.position;
        //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90f;//Calculates the angle the object should turn.
                                                                      //90f added to account for starting facing position
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);//Vector3.forward default look is to the right
                                                                          //Reason why 90f is needed.
    //}
}
