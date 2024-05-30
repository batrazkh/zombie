using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour

{
    [SerializeField] float rotationSpeed = 10f;
    private Rigidbody shellRb;
    public int SheelsLeft = 5;
    private Vector3 shellStartPosition = new Vector3(-9.021f, -4.18f, 0);
    private bool canShoot;
    public GameObject projectilePrefab;
    public GameObject gun;
    public GameObject barell;
    public GameObject wheel;
    public TextMeshProUGUI angleText;
    public TextMeshProUGUI tablo;
    [SerializeField] GameObject plate;
    private float angle;
    //public GameObject barell;
    [SerializeField] GameObject enemyPrefab;
    public bool gameOver;
    public float horizontalInput;
    private float spawnDelay = 2;
    private float spawnInterval = 2f;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        InvokeRepeating("SpawnObjects", spawnDelay, spawnInterval);
        angle = Quaternion.Angle(gun.transform.rotation, plate.transform.rotation);
        angleText.text = "Angle: " + Mathf.Round(angle) + " degree";
        tablo.text = SheelsLeft + "X";
        canShoot = true;
    }

    
    // Update is called once per frame
    void Update()
    {
        //horizontalInput = Input.GetAxis("Horizontal");
        horizontalInput = SimpleInput.GetAxis("Horizontal");
        barell.transform.Rotate(Vector3.forward, horizontalInput * -rotationSpeed * Time.deltaTime);
        //barell.transform.Rotate(0, 0, (Quaternion.Angle(gun.transform.rotation, wheel.transform.rotation) / 13));
        //Debug.Log(wheel.transform.rotation.z/5);
        //Debug.Log(Quaternion.Angle(wheel.transform.rotation, gun.transform.rotation));
        //Debug.Log(transform.rotation.z);
        angle = Quaternion.Angle(gun.transform.rotation, plate.transform.rotation);
        angleText.text = "Angle: " + Mathf.Round(angle-27) + " degree";
    }

    /// <summary>
    /// Fire the gun
    /// </summary>
    public void fireAGun()
    {
             if (canShoot==true && SheelsLeft > 0)
             {
                shellStartPosition = (gun.transform.position);
                Instantiate(projectilePrefab, shellStartPosition, gun.transform.rotation);
                SheelsLeft = SheelsLeft - 1;
                //Debug.Log("ShellFired");
                tablo.text = SheelsLeft+"X";
                canShoot = false;
                Invoke("shootEnabled", 1f);
             }   
    }

    /// <summary>
    /// Enables the shooting
    /// </summary>
    void shootEnabled()
    {
        canShoot = true;
    }

    /// <summary>
    /// Get the gun up
    /// </summary>
    public void GunUp()
    {
        barell.transform.Rotate(0,0,2);
        //angle = new Quaternion(gun.transform.rotation.x, gun.transform.rotation.y, gun.transform.rotation.z, 0).z;
        angle =Quaternion.Angle(gun.transform.rotation, plate.transform.rotation);
        angleText.text = "Angle: " + Mathf.Round(angle) + " degree";
        //Debug.Log(angle);
    }

    /// <summary>
    /// Lower the gun
    /// </summary>
    public void GunDown()
    {
        barell.transform.Rotate(0,0,-2);
        angle = Quaternion.Angle(gun.transform.rotation, plate.transform.rotation);
        angleText.text = "Angle: " + Mathf.Round(angle) + " degree";
        //Debug.Log(angle);
    }

    /// <summary>
    /// Spqwn Objects
    /// </summary>
    void SpawnObjects()
    {
        // Set random spawn location and random object index
       // Vector3 spawnLocation = new Vector3(0.154f, 0.159f, 0);
        // If game is still active, spawn new object
        if (!gameOver)
        {
           // Instantiate(enemyPrefab, spawnLocation, enemyPrefab.transform.rotation);
        }

    }

    private void OnMouseOver()
    {
        
    }
    /// <summary>
    /// Restart the Game
    /// </summary>
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
