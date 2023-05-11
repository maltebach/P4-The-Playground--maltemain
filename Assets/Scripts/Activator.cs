using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    // The game objects to activate when the audio clip finishes playing
    public List<GameObject> gameObjectsToActivate;
    public List<GameObject> gameObjectsToActivateWithDelay;

    // The audio source component to play the audio clip
    public AudioSource audioSource;

    // The audio clip to play
    public AudioClip audioClip;

    // Delay before activating game objects with delay (in seconds)
    public float activationDelay = 0f;

    // Called when the object is first created
    void Start()
    {
        // Assign the audio clip to the audio source
        audioSource.clip = audioClip;

        // Play the audio clip
        audioSource.Play();

        // Call the ActivateGameObjects method after the audio clip has finished playing
        if (gameObjectsToActivate.Count > 0)
        {
            Invoke(nameof(ActivateGameObject), audioClip.length);
        }

        // Call the ActivateGameObjectsWithDelay method after the audio clip has finished playing with a delay
        if (gameObjectsToActivateWithDelay.Count > 0)
        {
            Invoke(nameof(ActivateGameObjectWithDelay), audioClip.length + activationDelay);
        }
    }

    // Activates the game objects
    private void ActivateGameObject()
    {
        foreach (GameObject gameObject in gameObjectsToActivate)
        {
            gameObject.SetActive(true);
        }
    }

    // Activates the game objects with delay
    private void ActivateGameObjectWithDelay()
    {
        foreach (GameObject gameObject in gameObjectsToActivateWithDelay)
        {
            gameObject.SetActive(true);
        }
    }
}
