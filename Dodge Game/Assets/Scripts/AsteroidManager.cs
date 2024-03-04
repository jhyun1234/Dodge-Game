using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField] int circleSize = 10;
    [SerializeField] GameObject asteroid;
    [SerializeField] Transform playertransform;

    void Start()
    {
        StartCoroutine(CreateAsteroid());
        
    }

    public IEnumerator CreateAsteroid()
    {
        while(true)
        {
            transform.position = playertransform.position;
         GameObject prefab = Instantiate(asteroid, Random.insideUnitCircle.normalized*circleSize + 
             (Vector2)playertransform.position, Quaternion.identity);


            yield return new WaitForSeconds(1f);
        }
    }

    
}
