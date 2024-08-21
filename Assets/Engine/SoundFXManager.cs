using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.VisualScripting.Member;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager soundFXManagerInstance;

    [SerializeField] private float soundFXVolume;
    [SerializeField] private float musicVolume;
    [SerializeField] private AudioSource soundFXObject;

    [SerializeField] AudioClip mainMenuClip;
    [SerializeField] AudioClip soundtrackClip;
    private AudioSource musicSource;

    private string lastScene;
    private GameObject mainCamera;

    private void Awake()
    {
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

    void Start()
    {

    }
    void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name != lastScene)
        {
            musicSource.volume = musicVolume;
            mainCamera = FindObjectOfType<VirtualCamera>().gameObject;
            lastScene = SceneManager.GetActiveScene().name;

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

        if (mainCamera != null)
        {
            this.transform.position = mainCamera.transform.position;
        }
    }
}
