using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public AudioSource hit;

    public Renderer rend;
    public Collider col;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

            hit.Play();
            rend.enabled = false;
            col.enabled = false;

            gen.points += 50;
            Destroy(collision.gameObject);
        }

        else
        {


            Destroy(gameObject);
        }
    }
}
