using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAudioPlayer : MonoBehaviour
{
    public Button[] relatedButtons;
    public Color disabledColor;
    public float disableDuration = 2f;

    private Coroutine disableCoroutine;

    public void DisableRelatedButtonsWithTimer()
    {
        // Disable related buttons
        if (disableCoroutine != null)
        {
            StopCoroutine(disableCoroutine);
        }
        disableCoroutine = StartCoroutine(DisableButtonsCoroutine());

        // Start a coroutine to re-enable buttons after the disable duration
        StartCoroutine(EnableButtonsAfterDelayCoroutine());
    }

    private IEnumerator DisableButtonsCoroutine()
    {
        // Disable related buttons
        foreach (Button button in relatedButtons)
        {
            // Disable the button and change its color
            button.interactable = false;
            var image = button.GetComponent<Image>();
            if (image != null)
            {
                image.color = disabledColor;
            }
        }

        // Wait for the disable duration
        yield return new WaitForSeconds(disableDuration);

        // Enable related buttons
        EnableRelatedButtons();
    }

    private IEnumerator EnableButtonsAfterDelayCoroutine()
    {
        // Wait for the disable duration
        yield return new WaitForSeconds(disableDuration);

        // Enable related buttons
        EnableRelatedButtons();
    }

    private void EnableRelatedButtons()
    {
        foreach (Button button in relatedButtons)
        {
            // Enable the button and restore its original color
            button.interactable = true;
            var image = button.GetComponent<Image>();
            if (image != null)
            {
                image.color = Color.white;
            }
        }
    }
}
