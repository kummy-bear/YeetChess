using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addpieces : MonoBehaviour
{
    public static List<string> pieceList = new List<string>{"Pawn",
            "Horse",
            "Bishop",
            "Rook",
            "Queen",
            "King" };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddObjectToList()
    {
        foreach (string p in pieceList)
        {
            CaptureData.destroyedByBlack.Add(new Piece("White " + p));
            CaptureData.destroyedByWhite.Add(new Piece("Black " + p));

        }
        Debug.Log("cheats on");
        pieceCounter.countPieces();
    }

}
