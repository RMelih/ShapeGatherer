using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSysteem : MonoBehaviour
{
    //Toegankelijk in alle scripts variable 'health' met min/max waarde
    [Range(0, 3)]
    public int healthPlayer;

    //Bewerkbare 'Image' array variabele in de inspector met
    [SerializeField] private Image[] heartsImage;

    // Update is called once per frame
    private void Update()
    {
        //Functie voor het overige hart afbeeldingen
        RemainingHearts();
    }


    //Controleer object triggers en vraag informatie over de andere object
    void OnTriggerEnter2D(Collider2D col)
    {
        //Controleer of de andere object de 'Obstacle' is
        //Als dat zo is voer het onderstaande code uit
        if (col.CompareTag("Obstacle"))
        {
            //health -1 elke keer de player in aanraking komt met de 'Obstacle' 
            healthPlayer -= 1;
        }
    }

    void RemainingHearts()
    {
        //Controleer of de health is gelijk aan 0 of minder
        if (healthPlayer <= 0)
        {
            //Vind de GameManager script en call de functie'EndGame'
            FindObjectOfType<GameManager>().EndGame();
        }

        //loop door de hearts array
        for (int i = 0; i < heartsImage.Length; i++)
        {
            //Controleer of de hearts array is kleiner of gelijk aan de health van de player
            //Als dat zo is voer het onderstaande code uit
            if (i >= healthPlayer)
            {
                //     heart afbeelding finden en uitzetten
                heartsImage[i].gameObject.GetComponent<Image>().enabled = false;
            }
        }
    }
}
