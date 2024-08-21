using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    /* 
     * Basic scenemanagement script run in backround of every level
     * Used to jump between scenes using unity canvas buttons
    */


    //Sound effect : played on every buttonpress 
    [SerializeField] private AudioClip soundEffect;

    //Main method thus enabling simple addjustions to code
    private void changeScene(string scene)
    {
        SoundFXManager.soundFXManagerInstance.playSoundFXClip(soundEffect, this.transform);
        SceneManager.LoadScene(scene);
        Time.timeScale = 1;
    }

    //Callable methods used by different buttons throughout the game
    public void goToMain()
    {
        Time.timeScale = 1;
        changeScene("Main Menu");
    }

    public void goToLevelSelelect()
    {
        changeScene("Level Select");
    }

    public void goToSectorA()
    {
        changeScene("Sector A");
    }
    public void goToSectorB()
    {
        changeScene("Sector B");
    }
    public void goToSectorC()
    {
        changeScene("Sector C");
    }
    public void goToSectorD()
    {
        changeScene("Sector D");
    }

    public void goToTable()
    {
        changeScene("Table");
    }

    //Ran when quiting the application (Windows based exports only)
    public void quitAplication()
    {
        SoundFXManager.soundFXManagerInstance.playSoundFXClip(soundEffect, this.transform);
        Application.Quit();
    }

    public void restart()
    {
        changeScene(SceneManager.GetActiveScene().name);
    }
}