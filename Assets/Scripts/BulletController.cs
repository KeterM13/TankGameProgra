using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 0.1f;
    Vector3 bulletMovement;
    public Rigidbody rb;
    public int damage = 1;

     void Start()
    {
        rb.velocity = transform.forward * speed;
    }


    private void OnTriggerEnter(Collider hit)
    {
      Tank tank =  hit.GetComponent<Tank>();
        if(tank!= null)
        {
            tank.Damage(damage);
        }
        Destroy(gameObject);
    }

    



}
