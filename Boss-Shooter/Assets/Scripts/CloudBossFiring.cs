using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBossFiring : MonoBehaviour
{

    public GameObject bulletprefab;
    public GameObject spread1prefab;
    public GameObject spread2prefab;
    public GameObject spread3prefab;
    public GameObject SliderRprefab;
    public GameObject BurstBombprefab;
    public GameObject Crazyshotprefab;
    public int test;
    private int phase;
    private float AttackDelay;
    private float AttackDelay2;
    private int limit;
    private int limit2;
    private List<int> AttackQueue = new List<int>();
    private int attack;
    private Rigidbody2D BulletRB;
    private bool testfire;
    private int sliderrandom;


    // Use this for initialization
    void Start()
    {


        testfire = false;

        phase = 0;


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("test_fire"))
        {
            testfire = !testfire;

            AttackDelay = 0;

            limit2 = 0;

        }


        if (AttackDelay >= 3)
        {
            if (testfire == false)

            {
                attack = Random.Range(0, 3);

                //Debug.Log(attack);

                if (attack == 0)
                    StraightShot();
                    AttackDelay = 1;

                if (attack == 1)
                    StraightShot();
                    AttackDelay = 1;

                if (attack == 2)
                    SpreadShot();
                    AttackDelay = 1;
            }
        }

        if (testfire == true)
        {
            if (Input.GetButtonDown("test1"))
            {
                StraightShot();
            }

            if (Input.GetButtonDown("test2"))
            {
                SpreadShot();
            }

            if (Input.GetButtonDown("test3"))
            {
                StraightShot();

                AttackDelay2 = 0;

                limit2 = 0;

                if (AttackDelay2 >= .25 && limit == 0)
                {
                    StraightShot();

                    limit2 = 1;
                }
            }

            if (Input.GetButtonDown("test4"))
            {
                BurstBomb();
            }

            if (Input.GetButtonDown("test5"))
            {
                CrazyShot();
            }

        }

        AttackDelay += 1 * Time.deltaTime;
        AttackDelay2 += 1 * Time.deltaTime;


    }

    void StraightShot()
    {

        GameObject Bullet;

        Bullet = (Instantiate(bulletprefab, transform.position, transform.rotation)) as GameObject;

        GameObject Bullet2;

        Bullet2 = (Instantiate(bulletprefab, transform.position, transform.rotation)) as GameObject;

        Bullet2.GetComponent<Rigidbody2D>().transform.Translate(new Vector3(1, 0, 0));

        GameObject Bullet3;

        Bullet3 = (Instantiate(bulletprefab, transform.position, transform.rotation)) as GameObject;

        Bullet3.GetComponent<Rigidbody2D>().transform.Translate(new Vector3(-1, 0, 0));




        //Bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, bullet_speed*Time.deltaTime));

        //Bullet.transform.Translate(Vector2(0, bullet_speed));

        //Rigidbody Bullet = (Rigidbody)Instantiate(bulletprefab, transform.position + transform.forward, transform.rotation);
        //Bullet.GetComponent<Rigidbody2D>().AddForce(transform.forward * bullet_speed, ForceMode2D.Impulse);

        Destroy(Bullet, 1);

        Destroy(Bullet2, 1);

        Destroy(Bullet3, 1);
    }

    void SpreadShot()
    {
        GameObject Spread1;
        GameObject Spread2;
        GameObject Spread3;

        Spread1 = (Instantiate(spread1prefab, transform.position, transform.rotation)) as GameObject;

        Destroy(Spread1, 2);

        Spread2 = (Instantiate(spread2prefab, transform.position, transform.rotation)) as GameObject;

        Destroy(Spread2, 2);

        Spread3 = (Instantiate(spread3prefab, transform.position, transform.rotation)) as GameObject;

        Destroy(Spread3, 2);

    }

    void SlideShotR()
    {
        GameObject SliderR;

        sliderrandom = Random.Range(-9, 8);

        SliderR = (Instantiate(SliderRprefab, new Vector3(-22, sliderrandom), transform.rotation)) as GameObject;

        SliderR.GetComponent<Rigidbody2D>().transform.Rotate(new Vector3(0, 0, 90));

        Destroy(SliderR, 3);
    }

    void BurstBomb()
    {
        GameObject BurstBomb;

        BurstBomb = (Instantiate(BurstBombprefab, transform.position, transform.rotation)) as GameObject;

        Destroy(BurstBomb, 3);


    }

    void CrazyShot()
    {
        GameObject CrazyShot;

        CrazyShot = (Instantiate(Crazyshotprefab, transform.position, transform.rotation)) as GameObject;

        Destroy(CrazyShot, 3);

    }

}
