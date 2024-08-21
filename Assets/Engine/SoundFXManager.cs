using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.VisualScripting.Member;

/* 
 * Manager for all sound effects in the game
 *  - Done using the Singleton method ensuring only one SoundManager is present at any given moment
 *  - Works by creating a temporary instance of a sound game object to play neccessary sound
 *  - Handless both creation and destruction of sound objects
*/
public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager soundFXManagerInstance;

    //Variables able to be adjusted from Unity
    //Volume adjustments
    [SerializeField] private float soundFXVolume;
    [SerializeField] private float musicVolume;

    //Prefab for sound game object
    [SerializeField] private AudioSource soundFXObject;

    //Music clips
    [SerializeField] AudioClip mainMenuClip;
    [SerializeField] AudioClip soundtrackClip;

    //Necessary variables
    private AudioSource musicSource;
    private string lastScene;

    //Reffers to camera GameObject
    private GameObject mainCamera;

    //ran upon initializing the script
    private void Awake()
    {
        //ensuring singleton propeties
        musicSource = this.GetComponent<AudioSource>();
        if (soundFXManagerInstance == null)
        {
            soundFXManagerInstance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    //method called upon by other gameobjects to play a single sound clip
    public void playSoundFXClip(AudioClip audioClip, Transform spawnTransform)
    {
        //spawning in game object to play sound
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        //assingning the audioFile
        audioSource.clip = audioClip;

        //assigning volume
        audioSource.volume = soundFXVolume;

        //playing the clip
        audioSource.Play();

        //assigning lenght of clip
        float clipLenght = audioSource.clip.length;

        //killing the object
        Destroy(audioSource.gameObject, clipLenght);
    }

    //method called upon by other gameobjects to randobly pick and play a sound clip out of an array
    public void playRandomSoundFXClip(AudioClip[] audioClip, Transform spawnTransform)
    {
        //getting random index
        int randint = Random.Range(0, audioClip.Length);

        //spawning in game object to play sound
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        //assingning the audioFile
        audioSource.clip = audioClip[randint];

        //assigning volume
        audioSource.volume = soundFXVolume;

        //playing the clip
        audioSource.Play();

        //assigning lenght of clip
        float clipLenght = audioSource.clip.length;

        //killing the object
        Destroy(audioSource.gameObject, clipLenght);
    }

    //checks for scene changes and changes music based on current scene
    void FixedUpdate()
    {
        //checks current scene name for change
        if (SceneManager.GetActiveScene().name != lastScene)
        {
            musicSource.volume = musicVolume;
            mainCamera = FindObjectOfType<VirtualCamera>().gameObject;
            lastScene = SceneManager.GetActiveScene().name;

            // check for lobby music
            if (lastScene == "Main Menu" || lastScene == "Level Select" || lastScene == "Table")
            {
                if (musicSource.clip != mainMenuClip)
                {
                    musicSource.Stop();
                    musicSource.clip = mainMenuClip;
                    musicSource.Play();
                }
            }
            else if (musicSource.clip != soundtrackClip)
            {
                musicSource.Stop();
                musicSource.clip = soundtrackClip;
                musicSource.Play();
            }

        }

        //ensures that sounds are locked to the cameras position
        if (mainCamera != null)
        {
            this.transform.position = mainCamera.transform.position;
        }
    }
}
