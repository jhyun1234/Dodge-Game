using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] Vector2 direction;
    [SerializeField] Transform targetTransform;
    [SerializeField] float speed = 5.0f;
    
    void Start()
    {
        targetTransform = GameObject.Find("Player").transform;

        direction = (Vector2)targetTransform.position - (Vector2)transform.position;

        direction.Normalize();
    }

    
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(direction * speed *  Time.deltaTime);
    }
}
