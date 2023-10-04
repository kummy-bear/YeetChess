
using UnityEngine;

using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public Text displayText;
    public Button changeTextButton;
    public static int currentIndex = 0;
    public bool flag = true;
    void Start()
    {
        // Attach a method to the button's click event
        changeTextButton.onClick.AddListener(ChangeText);
    }

    void Update()
    {
        if (CameraSwitcher.chessing)
        {
            displayText.enabled = false;
            changeTextButton.enabled = false;
            changeTextButton.gameObject.SetActive(false);
        }
        else
        {
            displayText.enabled = true;
            changeTextButton.enabled = true;
            changeTextButton.gameObject.SetActive(true);
        }
        if (!flag)
        {
            if (GameController.WhiteTurn && CaptureData.destroyedByWhite.Count == 0)
            {
                displayText.text = "no pieces";
                displayText.color = Color.white;
                return;
            }
            else if (!GameController.WhiteTurn && CaptureData.destroyedByBlack.Count == 0)
            {
                displayText.text = "no pieces";
                displayText.color = Color.black;
                return;
            }
            if (!GameController.WhiteTurn)
            {
                // Increment the index and loop back to the beginning if necessary
                displayText.text = CaptureData.destroyedByBlack[currentIndex].Name;
                string col = CaptureData.destroyedByBlack[currentIndex].Color;
                if (col == "White")
                {
                    displayText.color = Color.white;
                }
                else
                {
                    displayText.color = Color.black;
                }
            }
            else
            {
                displayText.text = CaptureData.destroyedByWhite[currentIndex].Name;
                string col = CaptureData.destroyedByWhite[currentIndex].Color;
                if (col == "White")
                {
                    displayText.color = Color.white;
                }
                else
                {
                    displayText.color = Color.black;
                }
            }
        }
    }

    void ChangeText()
    {
        flag = false;
        // Initialize the text with the first item from the list
        if (GameController.WhiteTurn && CaptureData.destroyedByWhite.Count == 0)
        {
            displayText.text = "no pieces";
            displayText.color = Color.white;
            return;
        }
        else if (!GameController.WhiteTurn && CaptureData.destroyedByBlack.Count == 0)
        {
            displayText.text = "no pieces";
            displayText.color = Color.black;
            return;
        }

        // Update the text
        if (!GameController.WhiteTurn)
        {
            // Increment the index and loop back to the beginning if necessary
            currentIndex = (currentIndex + 1) % CaptureData.destroyedByBlack.Count;
            displayText.text = CaptureData.destroyedByBlack[currentIndex].Name;
            string col = CaptureData.destroyedByBlack[currentIndex].Color;
            if (col == "White")
            {
                displayText.color = Color.white;
            }
            else
            {
                displayText.color = Color.black;
            }
        }
        else
        {
            currentIndex = (currentIndex + 1) % CaptureData.destroyedByWhite.Count;
            displayText.text = CaptureData.destroyedByWhite[currentIndex].Name;
            string col = CaptureData.destroyedByWhite[currentIndex].Color;
            if (col == "White")
            {
                displayText.color = Color.white;
            }
            else
            {
                displayText.color = Color.black;
            }
        }


    }
}



