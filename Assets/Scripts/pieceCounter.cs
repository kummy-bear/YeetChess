using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pieceCounter : MonoBehaviour
{
    public static int[] wArray = new int[6];
    public static int[] bArray = new int[6];
    public static void countPieces()
    {
        if (GameController.WhiteTurn)
        {
            for (int i = 0; i < pieceCounter.wArray.Length; i++)
            {
                pieceCounter.wArray[i] = 0;
            }
            foreach (Piece p in CaptureData.destroyedByWhite)
            {
                if (p.Name == "Pawn")
                {
                    pieceCounter.wArray[0] += 1;
                }
                if (p.Name == "Horse")
                {
                    pieceCounter.wArray[1] += 1;
                }
                if (p.Name == "Bishop")
                {
                    pieceCounter.wArray[2] += 1;
                }
                if (p.Name == "Rook")
                {
                    pieceCounter.wArray[3] += 1;
                }
                if (p.Name == "Queen")
                {
                    pieceCounter.wArray[4] += 1;
                }
                if (p.Name == "King")
                {
                    pieceCounter.wArray[5] += 1;
                }
            }
        }
        else
        {
            for (int i = 0; i < pieceCounter.bArray.Length; i++)
            {
                pieceCounter.bArray[i] = 0;
            }
            foreach (Piece p in CaptureData.destroyedByBlack)
            {
                if (p.Name == "Pawn")
                {
                    pieceCounter.bArray[0] += 1;
                }
                if (p.Name == "Horse")
                {
                    pieceCounter.bArray[1] += 1;
                }
                if (p.Name == "Bishop")
                {
                    pieceCounter.bArray[2] += 1;
                }
                if (p.Name == "Rook")
                {
                    pieceCounter.bArray[3] += 1;
                }
                if (p.Name == "Queen")
                {
                    pieceCounter.bArray[4] += 1;
                }
                if (p.Name == "King")
                {
                    pieceCounter.bArray[5] += 1;
                }
            }
        }
    }
}

