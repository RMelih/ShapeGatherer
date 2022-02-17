using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObject : MonoBehaviour
{
    //Bewerkbare variabelen in de inspector
    [Range(0, 10)]
    [SerializeField] float speedObject = 2f;

    [Range(-20, 0)]
    [SerializeField] float PostionYAxis;

    [SerializeField] GameObject EnemyObjectEffect;
    [SerializeField] GameObject EnemyObjectEffectHearth;

    // Update is called once per frame
    void Update()
    {
        //Functie voor beweging van het object
        ObjectMovement();
        //Functie voor vernietigen van het object
        ObjectDestroy();
    }

    void ObjectMovement()
    {
        //Object omlaag verplaatsen * de snelheid van het object onafhankelijk van de frame rate
        transform.Translate(Vector2.down * speedObject * Time.deltaTime);
    }

    void ObjectDestroy()
    {
        //Controleer of de huidige positie van het object kleiner of gelijk is aan bepaalde positie
        if (transform.position.y <= PostionYAxis)
        {
            //Als het kleiner of gelijk is voer het onderstaande code uit 
            //Vernietig het object
            Destroy(gameObject);
        }
    }

    //Controleer object triggers en vraag informatie over de andere object
    void OnTriggerEnter2D(Collider2D col)
    {
        //Controleer of de andere object de 'Player' is
        //Als dat zo is voer het onderstaande code uit
        if (col.CompareTag("Player"))
        {
            //Spawn het effect EnemyObjectEffectHearth in positie en rotatie
            Instantiate(EnemyObjectEffectHearth, transform.position, Quaternion.identity);
            //Spawn het effect EnemyObjectEffect in positie en rotatie
            Instantiate(EnemyObjectEffect, transform.position, Quaternion.identity);
        }
    }
}
