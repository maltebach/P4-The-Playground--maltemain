using UnityEngine;
using System.Collections.Generic;

public class PlayAudioClipsFromList : MonoBehaviour
{
    // The list of audio clips to play
    public List<AudioClip> audioClipList;

    // The audio source component to play the audio clips
    public AudioSource audioSource;

    // Index of the current audio clip being played
    private int currentIndex = 0;

    // List of indices at which to call the MoveToFirstTarget method
    public List<int> indicesToCallMoveToFirstTarget;


    void Awake()
    {
        if (audioClipList.Count > 0)
        {
            // Get the first audio clip from the list
            AudioClip audioClip1 = audioClipList[0];

            // Play the first audio clip
            audioSource.clip = audioClip1;
            audioSource.Play();

            // Wait for the first clip to finish playing
            while (audioSource.isPlaying)
            {
                // Do nothing
            }

            // Get the second audio clip from the list
            AudioClip audioClip2 = audioClipList[1];

            // Play the second audio clip
            audioSource.clip = audioClip2;
            audioSource.Play();
        }
    }


    void Update()
    {
        // Check if the current index is in the list of indices to call MoveToFirstTarget
        if (indicesToCallMoveToFirstTarget.Contains(currentIndex) && !audioSource.isPlaying)
        {
            // Call the MoveToFirstTarget method from another script
            MoveToTarget otherScript = GetComponent<MoveToTarget>();
            otherScript.MoveToFirstTarget();
        }
    }

    // Called to play the next audio clip from the list
    public void PlayNextAudioClipFromList()
    {
        if (audioClipList.Count > 0)
        {
            // Get the next audio clip from the list
            AudioClip audioClip = audioClipList[currentIndex];

            // Play the audio clip
            audioSource.clip = audioClip;
            audioSource.Play();

            // Move to the next index in the list, or loop back to the beginning if we've reached the end
            currentIndex = (currentIndex + 1) % audioClipList.Count;
        }
    }
}
