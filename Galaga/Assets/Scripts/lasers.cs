using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lasers : MonoBehaviour {

    public GameObject shot;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {

        if (shot.transform.position.z > 5f)
            Destroy (shot);

        if (shot.transform.position.z < -6f)
            Destroy(shot);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
        {

            if (other.gameObject.CompareTag("Enemy"))
            {
                Destroy(other.gameObject);
            }

            else
            {
                other.GetComponent<Rigidbody>().AddTorque(0f, 200f, 0f);
                other.GetComponent<Rigidbody>().AddForce(0f, 0f, -50f);
            }

            Destroy(shot);
        }
    }
}
