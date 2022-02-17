using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    //variable voor de array posities van de spawn plekken
    [SerializeField] Transform[] spawnPoints;

    //variable voor de array objecten die gaan spawnen
    [SerializeField] GameObject[] objectPrefabs;

    //de variabele voor de tijd tussen spawn voor object
    [Range(0,15)]
    public float startTimeForTheFirstSpawn;
    
    //de variabele voor de starttijd van het object tussen elke spawn 
    [Range(0,5)]
    [SerializeField] float TimeBtwEachSpawn;
    
    [Range(0, 1)]
    //de variabele voor de afnamesnelheid van object
    [SerializeField] float decreaseTime;
    
    [Range(0, 2)]
    //variable voor de min time die een object kan hebben om te spawnen 
    [SerializeField] float minTime = 1f;

    // Update is called once per frame
    void Update()
    {
        //Call 'RandomSpawnObject' functie 
        RandomSpawnObject();
    }
    

    void RandomSpawnObject()
    {
        //Controleer of de tijd start tijd voor de eerste spawn kleiner of gelijk is aan 0
        //Als dat zo is voer het onderstaande code uit
        if (startTimeForTheFirstSpawn <= 0)
        {
            //Randomiseer het spawn-object op arraylengte
            int randObject = Random.Range(0, objectPrefabs.Length);
            //Randomiseer het spawnpunt-object op arraylengte
            int randSpawnPoint = Random.Range(0, spawnPoints.Length);
            //Maak een object in positie, rotatie en onder het bovenliggende object
            Instantiate(objectPrefabs[randObject], spawnPoints[randSpawnPoint].position, transform.rotation, transform);
            //Stel de tijd tussen spawn in om de tijd tussen tijd te starten
            startTimeForTheFirstSpawn = TimeBtwEachSpawn;
            //controleer of start tussen tijd groter is dan min tijd
            if (TimeBtwEachSpawn > minTime)
            {
                //Als dat zo is voer het onderstaande code uit
                //Verlaag de start tijd 
                TimeBtwEachSpawn -= decreaseTime;
            }
        }

        //Als dat niet zo is het onderstaande code uit
        else
        {
            //Verlaag de tijd om het spel sneller en moeilijker te maken
            startTimeForTheFirstSpawn -= Time.deltaTime;
        }
    }
}
