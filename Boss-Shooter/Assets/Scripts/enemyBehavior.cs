using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyBehavior : MonoBehaviour {
	[Header("Enemy Health")]
	public float startingHealth = 1f; //the max health of enemy gameObject
	public float currentHealth; //current health of the enemy gameObject
    public Image healthBar;
    public Text healthText;

    // Use this for initialization
    void Start () {
		//initalize the current health to starting health
		currentHealth = startingHealth;
        healthText.text = (currentHealth / startingHealth * 100).ToString() + "%";
        healthBar.fillAmount = currentHealth / startingHealth;
    }
	
	// Update is called once per frame
	void Update () {
        //if current health is 0, this object should die
        healthText.text = (currentHealth).ToString() + "%";
        healthBar.fillAmount = currentHealth;
        if (currentHealth <= 0)
		{
            healthText.text = 0.ToString() + "%";
            Die();

		}
        Debug.Log(currentHealth);
    }

	void Die()
	{
		//kill this object
		Destroy(gameObject);
	}
}
