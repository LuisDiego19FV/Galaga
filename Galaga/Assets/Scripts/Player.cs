using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed;
    public GameObject player;
    public GameObject father;
    public GameObject laser;
    public new AudioClip audio;
    public Text text;

    private AudioSource source;

    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && player.transform.position.x >= -2.9f)
        {
            if (player.transform.rotation.z < 0.35f)
                player.transform.Rotate(0f, 0f, 1.5f);

            father.transform.Translate(-1f * speed, 0f, 0f);

        }

        else if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && player.transform.position.x <= 2.9f)
        {
            if (player.transform.rotation.z > -0.35f)
                player.transform.Rotate(0f, 0f, -1.5f);

            father.transform.Translate(1f * speed, 0f, 0f);

        }

        else
        {
            if (player.transform.rotation.z < 0)
                player.transform.Rotate(0f,0f,1f);

            else if (player.transform.rotation.z > 0 )
                player.transform.Rotate(0f, 0f, -1f);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            source.PlayOneShot(audio);

            Vector3 initialPosition= new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + 0.50f);
            Quaternion initialRotation = new Quaternion(0f, 0f, 0f, 0f);
            GameObject shot = Object.Instantiate(laser, initialPosition, initialRotation);
            

            shot.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 10f);
        }

        if (player.transform.position.z < -5.5f)
        {
            text.text = "YOU LOSE";
        }

        if (Input.GetKey(KeyCode.Escape))
            SceneManager.LoadScene("Start");


    }
}
