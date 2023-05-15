using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    // The game objects to activate when the audio clip finishes playing
    public List<GameObject> gameObjectsToActivate;
    public List<GameObject> gameObjectsToActivateWithDelay;

    // The game objects to deactivate when the audio clip finishes playing
    public List<GameObject> gameObjectsToDeactivate;
    public List<GameObject> gameObjectsToDeactivateWithDelay;

    // The audio source component to play the audio clip
    public AudioSource audioSource;

    // The audio clip to play
    public AudioClip audioClip;

    // Delay before activating game objects with delay (in seconds)
    public float activationDelay = 0f;

    // Delay before deactivating game objects with delay (in seconds)
    public float deactivationDelay = 0f;

    // Delay before playing the audio clip (in seconds)
    public float audioClipDelay = 0f;

    // Called when the object is first created
    void Start()
    {
        // Call the PlayAudioClip method after the audio clip delay
        Invoke(nameof(PlayAudioClip), audioClipDelay);

        // Call the ActivateGameObjects method after the audio clip has finished playing
        if (gameObjectsToActivate.Count > 0)
        {
            Invoke(nameof(ActivateGameObject), audioClipDelay + audioClip.length);
        }

        // Call the ActivateGameObjectsWithDelay method after the audio clip has finished playing with a delay
        if (gameObjectsToActivateWithDelay.Count > 0)
        {
            Invoke(nameof(ActivateGameObjectWithDelay), audioClipDelay + audioClip.length + activationDelay);
        }

        // Call the DeactivateGameObjects method after the audio clip has finished playing
        if (gameObjectsToDeactivate.Count > 0)
        {
            Invoke(nameof(DeactivateGameObject), audioClipDelay + audioClip.length);
        }

        // Call the DeactivateGameObjectsWithDelay method after the audio clip has finished playing with a delay
        if (gameObjectsToDeactivateWithDelay.Count > 0)
        {
            Invoke(nameof(DeactivateGameObjectWithDelay), audioClipDelay + audioClip.length + deactivationDelay);
        }
    }

    // Plays the audio clip
    private void PlayAudioClip()
    {
        // Assign the audio clip to the audio source
        audioSource.clip = audioClip;

        // Play the audio clip
        audioSource.Play();
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

    // Deactivates the game objects
    private void DeactivateGameObject()
    {
        foreach (GameObject gameObject in gameObjectsToDeactivate)
        {
            gameObject.SetActive(false);
        }
    }

    // Deactivates the game objects with delay
    private void DeactivateGameObjectWithDelay()
    {
        foreach (GameObject gameObject in gameObjectsToDeactivateWithDelay)
        {
            gameObject.SetActive(false);
        }
    }
}
