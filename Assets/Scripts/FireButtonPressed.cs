using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireButtonPressed : MonoBehaviour
{
    [SerializeField] GameObject FireButton;
    public GameObject playerControllerScript;
    

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        FireButton = GameObject.Find("FireButton");
        //playerControllerScript = GameObject.Find("GameObject").GetComponent<PlayerController>();

    }

    private void OnMouseDown()
    {
        if (gameObject == FireButton)
        {
            //playerControllerScript.horizontalInput++;
            Debug.Log("Fire");
            //playerControllerScript.FireAGun();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
