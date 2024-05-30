using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    public float speed_f = 2;
    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * -speed_f);
        if (healthBar.slider.value == 0)
        {
            speed_f = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle" )
        {
            speed_f *= -1;
            Vector3 characterscale = gameObject.transform.localScale;
            characterscale.x *= -1;
            gameObject.transform.localScale = characterscale;
        }
    }
}
