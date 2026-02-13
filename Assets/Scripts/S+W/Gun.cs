using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public Transform firePoint;

    public float fireForce;

    public GameObject bullet;

    public int shootDelay;

    public int count;

    public AudioSource shoot;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gen.gameOver != true)
        {
            count++;

            if (count > shootDelay)
            {
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    GameObject p1 = Instantiate(bullet, firePoint.transform.position, Quaternion.identity);

                    p1.GetComponent<Rigidbody>().AddForce(transform.forward * fireForce, ForceMode.Impulse);

                    shoot.Play();

                    count = 0;
                }


            }
        }
    }
}
