using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private AudioClip soundEffect;

    public void changeScene(string scene)
    {
        SoundFXManager.soundFXManagerInstance.playSoundFXClip(soundEffect, this.transform);
        SceneManager.LoadScene(scene);
        Time.timeScale = 1;
    }

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
    public void quitAplication()
    {
        SoundFXManager.soundFXManagerInstance.playSoundFXClip(soundEffect, this.transform);
        Application.Quit();
    }

    public void restart()
    {
        changeScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
