using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D explosionRb;
    // Start is called before the first frame update
    /// <summary>
    /// Explosion spawning
    /// </summary>
    void Start()
    {
        explosionRb = GetComponent<Rigidbody2D>();
        explosionRb.constraints = RigidbodyConstraints2D.FreezeAll;
    }
    private IEnumerator Co_WaitForSeconds(float value)
        {
            // Do something before
            yield return new WaitForSeconds(value);
            Destroy(gameObject);
            // Do something after
        }
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Co_WaitForSeconds(1f));
    }
}
