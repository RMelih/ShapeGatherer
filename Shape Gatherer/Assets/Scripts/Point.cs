using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    //Bewerkbare variabelen in de inspector
    [Range(0, 10)]
    [SerializeField] float speedObject = 2f;

    [Range(-20, 0)]
    [SerializeField] float PostionYAxis;

    [SerializeField] GameObject effectPoint;
    [SerializeField] GameObject effectPointNumber;

    void Update()
    {
        //Call 'PointMovement' functie 
        PointMovement();
        //Call 'PointDestroy' functie 
        PointDestroy();
    }

    void PointMovement()
    {
        //Object naar beneden verplaatsen * het snelheid van het punt onafhankelijk van de frame rate
        transform.Translate(Vector2.down * speedObject * Time.deltaTime);
    }

    void PointDestroy()
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
            //Spawn het effect effectPoint in positie en rotatie
            Instantiate(effectPoint, transform.position, Quaternion.identity);
            //Spawn het effect effectPointNumber in positie en rotatie
            Instantiate(effectPointNumber, transform.position, Quaternion.identity);
        }
    }
}
