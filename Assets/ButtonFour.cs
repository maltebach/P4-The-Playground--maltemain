using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFour : MonoBehaviour
{
    public AudioSource audioSource;
    private bool isInitialized = false;

    private void Start()
    {
        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();
    }

    // This method will be called when the button is clicked
    public void OnButtonClick()
    {
        // Only play the audio clip if it hasn't been played before
        if (!isInitialized)
        {
            // Play the sound
            audioSource.Play();

            // Mark the audio clip as played
            isInitialized = true;
        }

        // Your code here to handle the button click event
        Debug.Log("Button 4 Clicked!");
    }
}

