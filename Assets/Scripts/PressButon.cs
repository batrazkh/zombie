using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButon : MonoBehaviour
{
    [SerializeField] GameObject UpButton;
    private GameObject FireButton;
    private GameObject playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        UpButton = GameObject.Find("UpButton");
        FireButton = GameObject.Find("FireButton");
        //playerControllerScript = GameObject.Find("Gun").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        Debug.Log("awake");
        UpButton = GameObject.Find("UpButton");
    }
    private void OnMouseDown()
    {
        Debug.Log("button pressed");
        if (gameObject == UpButton)
        {
            //playerControllerScript.horizontalInput++;
            Debug.Log("Get the gun higher");
        }
        
        if (gameObject == FireButton)
        {
            //playerControllerScript.horizontalInput++;
            Debug.Log("Fire");
        }
    }
    private void OnMouseDrag()
    {
        Debug.Log("Get the gun higher");
    }
    private void OnMouseUp()
    {
        Debug.Log("Get the gun higher");
    }
}
