using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    //variable voor de text van de aantal punten
    [SerializeField] GameObject textScore;

    //variable vor de aantal aantal punten
    private int theScore;

    //variable voor de audio effect van vernietigd object
    public AudioSource ASDestoySound;

    //variable voor de audio effect van verzamelde punten
    public AudioSource AsCollectSound;

    // Start is called before the first frame update
    private void Start()
    {
        //Zet de aantal punten op 0 aan de start van de game
        theScore = 0;

        //Krijg toegang tot de audiobron voor de vernietiging en verzamel geluidseffecten
        AudioSource ASDestoySound = GetComponent<AudioSource>();
        AudioSource AsCollectSound = GetComponent<AudioSource>();
    }

    //Controleer object triggers en vraag informatie over de andere object
    void OnTriggerEnter2D(Collider2D col)
    {
        //Controleer of de andere object de 'Obstacle' is
        //Als dat zo is voer het onderstaande code uit
        if (col.CompareTag("Obstacle"))
        {
            //Speel het geluidseffect voor het vernietigde object
            ASDestoySound.Play();
            //Vernietig het 'Obstacle' object
            Destroy(col.gameObject);
        }

        //Controleer of de andere object de 'Point' is
        //Als dat zo is voer het onderstaande code uit
        if (col.CompareTag("Point"))
        {
            //Zet de score + 1 wanner de speler de point object aanraakt
            theScore += 1;
            //Update de aantal punten tekst 
            textScore.GetComponent<Text>().text = theScore.ToString();

            //Speel het geluidseffect voor het verzamelde punt
            AsCollectSound.Play();

            //Vernietig het 'Point' object
            Destroy(col.gameObject);
        }
    }
}
