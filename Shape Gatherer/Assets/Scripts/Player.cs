using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Bewerkbare variabelen in de inspector
    private Vector2 playerPosition;

    [Range(0, 30)]
    [SerializeField] float xAxisIncrement;
    
    [Range(0, 30)]
    [SerializeField] float playerSpeed = 1f;
    
    [Range(0, 1)]
    [SerializeField] float accelerationSpeed = 1.0f;
    
    [Range(0, 60)]
    [SerializeField] float maxSpeed = 60.0f;
    
    [Range(0, 20)]
    [SerializeField] int maxWidth;
    
    [Range(-20, 0)]
    [SerializeField] int minWidth;


    // Start is called before the first frame update
    void Start()
    {
        //Startpositie instellen voor de speler
        playerPosition = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        //Call 'PlayerMovements' functie 
        PlayerMovements();
    }


    void PlayerMovements()
    {
        //Verplaats de speler van zijn huidige positie naar de doelpositie onafhankelijk van de frame rate
        transform.position = Vector2.MoveTowards(transform.position, playerPosition, playerSpeed * Time.deltaTime);

        //Snelheid van de speler in de loop van de tijd versnellen onafhankelijk van de frame rate
        playerSpeed += accelerationSpeed * Time.deltaTime;

        //Controleer of de speler snelheid is groter dan de maximale snelheid
        //Als dat zo is voer het onderstaande code uit
        if (playerSpeed > maxSpeed)
        {
            //Zet de speler snelheid gelijk aan de maximale snelheid
            playerSpeed = maxSpeed;
        }


        //Controleer of spelerinvoer gelijk is aan pijl rechts of key d
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            //Verplaats de player positie naar rechts
            playerPosition = new Vector2(transform.position.x + xAxisIncrement, transform.position.y);
        }

        //Controleer of de player positie groter or gelijk is aan de max breedte
        else if (transform.position.x >= maxWidth)
        {
            //Bounce de speler naar links wanneer die het einde van de rechterkant raakt
            playerPosition = new Vector2(transform.position.x - xAxisIncrement, transform.position.y);
        }

        //Controleer of spelerinvoer gelijk is aan pijl links of key a
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            //Verplaats de player positie naar links
            playerPosition = new Vector2(transform.position.x - xAxisIncrement, transform.position.y);
        }

         //Controleer of de player positie groter or gelijk is aan de min breedte
        else if (transform.position.x <= minWidth)
        {
            //Bounce de speler naar rechts wanneer die het einde van de linker raakt
            playerPosition = new Vector2(transform.position.x + xAxisIncrement, transform.position.y);
        }
    }
}
