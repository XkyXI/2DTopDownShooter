using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloudBossBehavior : MonoBehaviour
{
    [Header("Enemy Health")]
    public float startingHealth = 1f; //the max health of enemy gameObject
    public float currentHealth; //current health of the enemy gameObject
    public Image healthBar;
    public Text healthText;
    public float horspeed;
    public float vertspeed;
    private bool right;
    private bool up;
    private float delay1;
    private float delay2;
    public Transform positionA;
    public Transform positionB;
    public Transform positionC;
    public Transform positionD;

    // Use this for initialization
    void Start()
    {
        //initalize the current health to starting health
        currentHealth = startingHealth;
        healthText.text = (currentHealth / startingHealth).ToString() + "%";
        healthBar.fillAmount = currentHealth / startingHealth;

        up = true;
        right = true;
    }

    // Update is called once per frame
    void Update()
    {
        //if current health is 0, this object should die
        healthText.text = (currentHealth).ToString() + "%";
        healthBar.fillAmount = currentHealth / startingHealth;
        if (currentHealth <= 0)
        {
            healthText.text = 0.ToString() + "%";
            Die();

        }
        Debug.Log(currentHealth);


        if (right == true)
        {
            transform.Translate(Vector2.right * horspeed * Time.deltaTime);
        }

        else
        {
            transform.Translate(Vector2.left * horspeed * Time.deltaTime);
        }


        if (up == true)
        {
            transform.Translate(Vector2.up * vertspeed * Time.deltaTime);
        }

        else
        {
            transform.Translate(Vector2.down * vertspeed * Time.deltaTime);
        }

        //enemy moves until reaching a boundary, then we will flip direction
        if (transform.position.x >= positionA.position.x ||
        transform.position.x < positionB.position.x)
        {
            if (delay1 >= 1)
            {
                right = !right;
                delay1 = 0;

            }
        }

        if (transform.position.y >= positionC.position.y ||
        transform.position.y <= positionD.position.y)
        {
            if (delay2 >= 1)
            {
                up = !up;
                delay2 = 0;
            }
        }

        delay1 += 1 * Time.deltaTime;
        delay2 += 1 * Time.deltaTime;

        Debug.Log(right);
    }

    void Die()
    {
        //kill this object
        Destroy(gameObject);
    }
}
