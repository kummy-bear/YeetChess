
using UnityEngine;

using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public Text displayText;
    public Text left;
    public Text turn;
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
            left.enabled = false;
            turn.enabled = false;
            changeTextButton.enabled = false;
            changeTextButton.gameObject.SetActive(false);
        }
        else
        {
            displayText.enabled = true;
            left.enabled = true;
            turn.enabled = true;
            changeTextButton.enabled = true;
            changeTextButton.gameObject.SetActive(true);
        }
        if (!GameController.WhiteTurn)
        {
            left.text = currentIndex+1 + "/" + CaptureData.destroyedByBlack.Count.ToString();
            left.color = Color.black;
            turn.text = "black";
            turn.color = Color.black;
        }
        else
        {
            left.text = currentIndex+1 + "/" + CaptureData.destroyedByWhite.Count.ToString();
            left.color = Color.white;
            turn.text = "white";
            turn.color = Color.white;
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
        // Update the text
        if (!GameController.WhiteTurn)
        {
            if (CaptureData.destroyedByBlack.Count > 0)
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
                displayText.text = "empty";
                displayText.color = Color.black;
            }
        }
        else
        {
            if (CaptureData.destroyedByWhite.Count > 0)
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
            else
            {
                displayText.text = "empty";
                displayText.color = Color.white;
            }
        }


    }
}



