using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    // The game object to activate when the audio clip finishes playing
    public List<GameObject> gameObjectsToActivate;
    public List<GameObject> gameObjectsToDeactivate;

    // The audio source component to play the audio clip
    public AudioSource audioSource;

    // The audio clip to play
    public AudioClip audioClip;

    // Called when the object is first created
    void Start()
    {
        // Assign the audio clip to the audio source
        audioSource.clip = audioClip;

        // Play the audio clip
        audioSource.Play();

        // Call the Deactivate/ActivateGameObjects method after the audio clip has finished playing
        if (gameObjectsToActivate.Count > 0)
        {
            Invoke("ActivateGameObject", audioClip.length);
        }
        
        if (gameObjectsToDeactivate.Count > 0)
        {
            Invoke("DeactivateGameObject", audioClip.length);
        }
    }

    // Activates the game object
    private void ActivateGameObject()
    {
        foreach (GameObject gameObject in gameObjectsToActivate)
        {
            gameObject.SetActive(true);
        }
    }

    // Deactivates the game object
    private void DeactivateGameObject()
    {
        foreach (GameObject gameObject in gameObjectsToDeactivate)
        {
            gameObject.SetActive(false);
        }
    }
}