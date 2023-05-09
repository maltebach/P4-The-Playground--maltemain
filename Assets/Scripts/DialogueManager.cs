using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public AudioClip[] dialogueClips; // Array of audio clips to play
    public float dialogueVolume = 1f; // Volume of audio clips
    public AudioSource dialogueSource; // AudioSource to play the audio clips

    void Start()
    {
        dialogueSource.volume = dialogueVolume;
    }

    public void PlayDialogueClip(int clipIndex)
    {
        if (clipIndex < dialogueClips.Length)
        {
            dialogueSource.clip = dialogueClips[clipIndex];
            dialogueSource.Play();
        }
    }

    // Example usage: call this method when a trigger is entered
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayDialogueClip(0);
        }
    }
}
