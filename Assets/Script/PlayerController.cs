using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int speed = 5;
    bool onatk = false;
    int hitcounter;
    Animator playerAnim;
    public GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent <Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //walk forward and stop
        if ( Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            playerAnim.SetBool("IsStrafe", true);
        }
        if ( Input.GetKeyUp(KeyCode.W))
        {
            playerAnim.SetBool("IsStrafe", false);
        }


        //walk left and stop
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 270, 0);
            playerAnim.SetBool("IsStrafe", true);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            playerAnim.SetBool("IsStrafe", false);
        }


        //walk backward and stop
        if ( Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            playerAnim.SetBool("IsStrafe", true);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            playerAnim.SetBool("IsStrafe", false);
        }


        //walk right and stop
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0,90, 0);
            playerAnim.SetBool("IsStrafe", true);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            playerAnim.SetBool("IsStrafe", false);
        }


        //attack
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAnim.SetTrigger("TriAtk");
            if( onatk == true)
            {
                hitcounter++;
                if ( hitcounter >= 5)
                {
                    Destroy(cube);
                }
            }
        }
    }

   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube"))
        {
            Debug.Log("Touched");
            playerAnim.SetTrigger("Isdie");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {
            onatk = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if(other.gameObject.CompareTag("Cube"))
        {
            onatk = false;
        }
    }
}
