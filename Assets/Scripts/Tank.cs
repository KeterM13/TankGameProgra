using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tank : MonoBehaviour
{
    Vector3 spawnPosition;
    Quaternion spawnRotation;
    Vector2 tankMovementSpeed;
    public float tankSpeed = 1f;
    public float tankRotSpeed = 10f;
    public Transform bulletShooter;
    public GameObject shell;
    public Vector3 initialPos;
    public bool hasDie=false;
    int health = 5;
    int tankIndex;

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

    public void ReturnToInitialPos()
    {
        transform.SetPositionAndRotation(spawnPosition, spawnRotation);
    }



    public void SetInitialPos(Vector3 position, Quaternion rotation)
    {
        spawnPosition = position;
        spawnRotation = rotation;
        ReturnToInitialPos();


    }
    public void SetIndex(int index)
    {
        tankIndex = index;
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

   public void Damage(int dmg, int hitTankIndex)
    {
        health -= dmg;
        
        if(health<=0)
        {
            GameManager.instance.UpdateKills(hitTankIndex);
            health = 5;
            ReturnToInitialPos();

        }
    }
}
