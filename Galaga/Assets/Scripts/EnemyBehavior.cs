using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    public GameObject father;
    public GameObject enemy;
    public GameObject laser;
    public float extraTime;
    public int direction;
    public int road;
    public bool special;
    public bool off;
    public bool frontLines;

    private float Timer;
    private int counter;
    private bool getBack;
    private bool firstShot;
    private bool secondShot;
    private bool thirdShot;
    private Vector3 newPosition;

    // Use this for initialization
    void Start () {
        firstShot = true;
        secondShot = true;
        thirdShot = true;
        getBack = false;
        counter = 0;

        
    }
	
	// Update is called once per frame
	void Update () {

        Timer += Time.deltaTime; //Time.deltaTime will increase the value with 1 every second.

        if (!off)
        {
            if (Timer >= 5.5f + extraTime)
            {
                if (special)
                    attack();

                else
                {
                    if (Timer >= 6.5f + extraTime && firstShot)
                    {
                        attack();
                        firstShot = false;
                    }
                    else if (Timer >= 8.5f + extraTime && secondShot)
                    {
                        attack();
                        secondShot = false;
                    }
                    else if (Timer >= 10.5f + extraTime && thirdShot)
                    {
                        attack();
                        thirdShot = false;
                    }
                }

                enemy.transform.Translate(0.006f * direction, 0f, 0.020f);
            }

        }

        if ((Timer >= 6.5 + extraTime ) && !frontLines)
        {
            enemy.transform.Translate(0f , 0f, 0.015f);

            if (Timer >= 7.5f + extraTime)
            {
                road = road - 1;

                if (road == 1)
                {
                    frontLines = true;
                    off = false;
                }

                Timer = 0;
               
            }

        }

        if (enemy.transform.position.z < -4.5f)
        {
            if (direction == 0)
                enemy.transform.Translate(0f, 0f, -9.6f);

            else
                enemy.transform.Translate(-2.085f * direction, 0f, -9.65f);

            Timer = 0.0f;
            off = true;
            getBack = true;
            frontLines = false;
            road = 3;

            firstShot = true;
            secondShot = true;
            thirdShot = true;

        }

        if (getBack && Timer < 1.25f)
        {
            enemy.transform.Translate(0f, 0f, 0.01f);
        }

        if (getBack && Timer > 1.2f)
        {
            getBack = false;
        }

    }

    void attack()
    {
        Vector3 initialPosition = new Vector3(enemy.transform.position.x, enemy.transform.position.y, enemy.transform.position.z - 0.50f);
        Quaternion initialRotation = new Quaternion(0f, 0f, 0f, 0f);
        GameObject shot = Instantiate(laser, initialPosition, initialRotation);

        shot.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, -8f);
    }
}
