
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public Text displayText;
    public Text turn;
    public TextMeshProUGUI wPawnCount;
    public TextMeshProUGUI wKnightCount;
    public TextMeshProUGUI wBishopCount;
    public TextMeshProUGUI wRookCount;
    public TextMeshProUGUI wQueenCount;
    public TextMeshProUGUI wKingCount;
    public TextMeshProUGUI bPawnCount;
    public TextMeshProUGUI bKnightCount;
    public TextMeshProUGUI bBishopCount;
    public TextMeshProUGUI bRookCount;
    public TextMeshProUGUI bQueenCount;
    public TextMeshProUGUI bKingCount;
    public GameObject wSelBar;
    public GameObject bSelBar;
    public GameObject cheatButton;


    public static int currentIndex = 0;
    public bool flag = true;
    void Start()
    {

    }

    void Update()
    {
        if (CameraSwitcher.chessing)
        {
            cheatButton.SetActive(false);
            wSelBar.SetActive(false);
            bSelBar.SetActive(false);
            displayText.enabled = false;
            turn.enabled = false;
        }
        else
        {
            cheatButton.SetActive(true);
            displayText.enabled = true;
            turn.enabled = true;
            if (GameController.WhiteTurn)
            {
                wSelBar.SetActive(true);
                bSelBar.SetActive(false);
                turn.text = "White's";
                turn.color = Color.white;
                wPawnCount.text = pieceCounter.wArray[0].ToString();
                wKnightCount.text = pieceCounter.wArray[1].ToString();
                wBishopCount.text = pieceCounter.wArray[2].ToString();
                wRookCount.text = pieceCounter.wArray[3].ToString();
                wQueenCount.text = pieceCounter.wArray[4].ToString();
                wKingCount.text = pieceCounter.wArray[5].ToString();
            }
            else
            {
                bSelBar.SetActive(true);
                wSelBar.SetActive(false);
                turn.text = "Black's";
                turn.color = Color.black;
                bPawnCount.text = pieceCounter.bArray[0].ToString();
                bKnightCount.text = pieceCounter.bArray[1].ToString();
                bBishopCount.text = pieceCounter.bArray[2].ToString();
                bRookCount.text = pieceCounter.bArray[3].ToString(); 
                bQueenCount.text = pieceCounter.bArray[4].ToString();
                bKingCount.text = pieceCounter.bArray[5].ToString(); 
            }
            
            
        }
        
        
    }


}



