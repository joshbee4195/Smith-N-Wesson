using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject player;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //look at player

        //shoot

        if (gen.gameOver != true)
        {

            transform.position = transform.position + new Vector3(0, 0, -speed);

            if (transform.position.y < -5)
            {
                Destroy(gameObject);
            }

            transform.rotation = Quaternion.identity;
        }
    }


}
