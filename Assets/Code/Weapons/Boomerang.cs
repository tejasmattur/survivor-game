using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : BaseWeapon
{

    void Start()
    {
        weaponDamage = 2;
        setBasicConfigurations();
        _ridgidbody2D.velocity = transform.right * 10;
    }

    void Update()
    {
        //Throw();
    }

    //void Throw()
    //{
    //    thrown = true;
    //    throwPosition = transform.position;
    //    rb.isKinematic = false;
    //    rb.AddForce(transform.forward * speed, ForceMode.Impulse);
    //}

    //void FixedUpdate()
    //{
    //    if (thrown)
    //    {
    //        transform.Rotate(Vector3.up, rotationSpeed * Time.fixedDeltaTime);
    //        if (Time.time > returnTime)
    //        {
    //            Return();
    //        }
    //    }
    //}

    //void Return()
    //{
    //    thrown = false;
    //    transform.position = throwPosition;
    //    transform.rotation = Quaternion.identity;
    //    rb.isKinematic = true;
    //}
}
