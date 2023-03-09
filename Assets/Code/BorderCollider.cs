using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderCollider : MonoBehaviour
{
    private bool isCollidingPlayer = false;
    private bool isCollidingEnemy = false;

    private List<BoxCollider2D> colliders = new List<BoxCollider2D>();

    void Start()
    {
        //Collider2D[] collidersArray = Physics2D.OverlapAreaAll(transform.position - transform.localScale * 0.5f, transform.position + transform.localScale * 0.5f, LayerMask.GetMask("MapBoundary"));
        //foreach (Collider2D collider in collidersArray)
        //{
        //    if (collider.CompareTag("MapBoundary"))
        //    {
        //        colliders.Add(collider.GetComponent<BoxCollider2D>());
        //    }
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        //if (isCollidingPlayer)
        //{
        //    // Move the character away from the colliders
        //    Vector2 characterPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        //    foreach (BoxCollider2D collider in colliders)
        //    {
        //        Vector2 colliderPosition = collider.transform.position;
        //        Vector2 direction = (characterPosition - colliderPosition).normalized;
        //        float distance = Vector2.Distance(characterPosition, colliderPosition);
        //        float characterRadius = 0.5f; // Replace this with your character's radius
        //        float colliderRadius = Mathf.Max(collider.size.x, collider.size.y) * 0.5f;
        //        float minDistance = characterRadius + colliderRadius;
        //        float pushDistance = Mathf.Max(0f, minDistance - distance);
        //        GameObject.FindGameObjectWithTag("Player").transform.Translate(direction * pushDistance);
        //    }
        //}

        //if (isCollidingEnemy)
        //{
        //    // Move the character away from the colliders
        //    Vector2 characterPosition = GameObject.FindGameObjectWithTag("Enemy").transform.position;
        //    foreach (BoxCollider2D collider in colliders)
        //    {
        //        Vector2 colliderPosition = collider.transform.position;
        //        Vector2 direction = (characterPosition - colliderPosition).normalized;
        //        float distance = Vector2.Distance(characterPosition, colliderPosition);
        //        float characterRadius = 0.5f; // Replace this with your character's radius
        //        float colliderRadius = Mathf.Max(collider.size.x, collider.size.y) * 0.5f;
        //        float minDistance = characterRadius + colliderRadius;
        //        float pushDistance = Mathf.Max(0f, minDistance - distance);
        //        GameObject.FindGameObjectWithTag("Enemy").transform.Translate(direction * pushDistance);
        //    }
        //}
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
        }

        //if (other.CompareTag("Player"))
        //{
        //    isCollidingPlayer = true;
        //}

        //if (other.CompareTag("Enemy"))
        //{ 
        //    isCollidingEnemy = true;
        //}


    }

    //void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        isCollidingPlayer = false;
    //    }

    //    if (other.CompareTag("Enemy"))
    //    { 
    //        isCollidingEnemy = false;
    //    }
    //}



}
