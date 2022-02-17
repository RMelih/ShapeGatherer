using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Variable om te checken of de game is beëindigd
    bool gameHasEnded = false;

    //Variable voor de restart delay van de game
    [SerializeField] float restartDelay = 1f;

    //Variable voor de randomSpawner gameobject
    public GameObject randomSpawner;

    //Functie voor de beëindiging van de game
    public void EndGame()
    {
        //Uitzetten van de enemy spawner zodat er niet meer nieuwe vijanden verschijnen
        randomSpawner.SetActive(false);
        //Call de functie 'LoadGameOverScreen' metrestart delay
        Invoke("LoadGameOverScreen", restartDelay);
    }

    //Functie om de game over screen te laden
    public void LoadGameOverScreen()
    {
        //Laad the game over screen
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Functie voor de starten van de game
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Functie voor de restarten van de game
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    //Functie voor het verlaten van de game
    public void QuitGame()
    {
        Application.Quit();
    }

    //Functie om terug te gaan naar het start scherm 
    public void MenuGame()
    {
        SceneManager.LoadScene("StartScrene");
    }
}
