using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiggle : MonoBehaviour {

    public GameObject enemy;
    private bool move;
    private int counter;
	// Use this for initialization
	void Start () {
        move = true;
        counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
        if (move)
        {
            enemy.transform.Translate(0.005f, 0f, 0f);
            counter++;

            if (counter == 30)
            {
                counter = 0;
                move = false;
            }
        }

        else
        {
            enemy.transform.Translate(-0.005f, 0f, 0f);
            counter++;

            if (counter == 30)
            {
                counter = 0;
                move = true;
            }
        } 

	}
}
