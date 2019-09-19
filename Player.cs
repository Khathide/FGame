//Namespaces allows us to use code libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
    //public variables are manipulated by the environment as well
    //private variables only manipulated by the player
    //[SerializeField] for other designers to edit
    private float _speed = 3.5f;
    
    //Allows me to make object private 
    //Can still access from inspector
    [SerializeField]
    private GameObject _laserPrefab;
    private float _fireRate = 0.15f;
    private float _canFire = -1f;
    
    [SerializeField]
    private int _lives = 5;

    


    // Start is called before the first frame update
    void Start()
    {
       //take current position = new position (0, 0, 0)
       transform.position = new Vector3(0, 0, 0); 
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        if(Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            FireLaser();
        }
        
    }
    
    //Void runs all the code underneath from beginning to end
    void PlayerMovement()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
       
        transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
        transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);
         
     if (transform.position.y < -3.88f)
     {
         transform.position = new Vector3(transform.position.x,
         -3.88f, transform.position.z);
     }
     else if (transform.position.y > 1.5f)
    {
        transform.position = new Vector3(transform.position.x, 1.5f, 
        transform.position.z);
    }
     

     if (transform.position.x < -9.16f)
     {
         transform.position = new Vector3(-9.16f, transform.position.y,
         transform.position.z);
     }
     else if (transform.position.x > 9.16f)
     {
         transform.position = new Vector3(9.16f, transform.position.y,
         transform.position.z);
     }
    }


    void FireLaser()
    {

        //space key must spawn Laser
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            _canFire = Time.time + _fireRate;
            Instantiate(_laserPrefab, transform.position + 
            new Vector3(0, 0.8f, 0),
             Quaternion.identity);
            Debug.Log("Space Key Pressed");
        }
    }
    public void Damage()
    {
        _lives -= 1;
        //_lives = _lives -1;
        //_lives -= 1;

        if (_lives < 1)
        {
            Destroy(this.gameObject);
        }

    }
}
