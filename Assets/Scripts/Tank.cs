using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tank : MonoBehaviour
{
    public Vector3 spawnPosition;
    Vector2 tankMovementSpeed;
    public float tankSpeed = 1f;
    public float tankRotSpeed = 10f;
    public Transform bulletShooter;
    public GameObject shell;
    public Vector3 initialPos;
    public bool hasDie=false;
    int health = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(tankSpeed * tankMovementSpeed.y * Time.deltaTime * Vector3.forward);
        transform.Rotate(tankRotSpeed * tankMovementSpeed.x * Time.deltaTime * Vector3.up);
       
        
    }

    public void SetInitialPos(Vector3 position)
    {
        spawnPosition = position;
        transform.position = position;
        initialPos = position;
       
        
    }

    public void Fire(InputAction.CallbackContext callbackContext)
    {
        if (!gameObject.activeInHierarchy) return;
        if (callbackContext.phase != InputActionPhase.Started) return;

        ShootBullet();
    }

    public void Move(InputAction.CallbackContext context)
    {
       
        tankMovementSpeed = context.ReadValue<Vector2>();
        //transform.Translate(10 * context.ReadValue<Vector2>().y * Time.deltaTime * Vector3.forward);
    }

    void ShootBullet()
    {
        Instantiate(shell, bulletShooter.position, bulletShooter.rotation);
    }

   public void Damage(int dmg)
    {
        health -= dmg;
        Debug.Log("Me Dieron" + health);
        if(health<=0)
        {
            
            gameObject.SetActive(false);
            
        }
    }
}