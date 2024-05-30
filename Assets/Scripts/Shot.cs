using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    
    //[SerializeField] float speed = 40;
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] float shotPower;
    private Vector3 explosionPos;
    private Rigidbody2D shellRb;

    /// <summary>
    /// Applies force to the shell when shot is called
    /// </summary>
    void Start()
    {
        shellRb = gameObject.GetComponent<Rigidbody2D>();
        shellRb.AddForce(transform.right * shotPower, ForceMode2D.Impulse);
        //playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        if (transform.position.y < -4.35f)
        {
            explosionPos = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
            Instantiate(explosionPrefab, explosionPos, transform.rotation);
            Destroy(gameObject);
        }
        transform.Rotate(0, 0, -0.05f);
    }

    /// <summary>
    /// When shell collides with enemy
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Collision!");
        if (other.gameObject.tag == "Enemy")
        {
            explosionPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Instantiate(explosionPrefab, explosionPos, gameObject.transform.rotation);
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }

    /// <summary>
    /// Collision script, if shell collides with other shell or explosion it wont explode
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {

        //if (collision.gameObject.tag != "Explosion" && collision.gameObject.tag != "Shell" && collision.gameObject.tag != "Player")
        if (collision.gameObject.tag != "Explosion" && collision.gameObject.tag != "Shell")
            {
            explosionPos = new Vector3(transform.position.x, transform.position.y , transform.position.z);
            Instantiate(explosionPrefab, explosionPos,  gameObject.transform.rotation);
            Destroy(gameObject);
            Debug.Log(collision.gameObject.name);
       
        }
        //Destroy(other.gameObject);
    }
}
