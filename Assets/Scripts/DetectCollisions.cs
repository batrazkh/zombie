using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DetectCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    public HealthBar healthBar;
    public Animator animator;
    private AudioSource zombie3AS;

    void Start()
    {
        zombie3AS = GameObject.Find("zombie3").GetComponent<AudioSource>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Shell"|| other.gameObject.tag == "Explosion")
        {
            //Debug.Log("Boom");
            int healthLeft = (int) healthBar.slider.value - 50;
            if (healthLeft < 0)
            {
                healthLeft = 0;
                Debug.Log(healthLeft);
                healthBar.SetHealth(0);
                animator.SetBool("is_Death", true);
                zombie3AS.Stop();
            }
            if (healthLeft > 0)
            {
                healthBar.SetHealth(healthLeft);
                Debug.Log(healthLeft);
            }
            if (healthLeft == 0)
            {
                healthBar.SetHealth(0);
                Debug.Log(healthLeft);
                animator.SetBool("is_Death", true);
                zombie3AS.Stop();
            }

        }
    }
}
