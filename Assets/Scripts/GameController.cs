﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject Board;
    public GameObject WhitePieces;
    public GameObject BlackPieces;
    public GameObject SelectedPiece;
    public bool WhiteTurn = true;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SelectPiece(GameObject piece)
    {
        if (piece.tag == "White" && WhiteTurn == true || piece.tag == "Black" && WhiteTurn == false)
        {
            DeselectPiece();
            SelectedPiece = piece;

            // Highlight
            SelectedPiece.GetComponent<SpriteRenderer>().color = Color.yellow;

            // Put above other pieces
            Vector3 newPosition = SelectedPiece.transform.position;
            newPosition.z = -1;
            SelectedPiece.transform.SetPositionAndRotation(newPosition, SelectedPiece.transform.rotation);
        }
    }

    public void DeselectPiece()
    {
        if (SelectedPiece != null)
        {
            // Remove highlight
            SelectedPiece.GetComponent<SpriteRenderer>().color = Color.white;

            // Put back on the same level as other pieces
            Vector3 newPosition = SelectedPiece.transform.position;
            newPosition.z = 0;
            SelectedPiece.transform.SetPositionAndRotation(newPosition, SelectedPiece.transform.rotation);

            SelectedPiece = null;
        }
    }

    public void EndTurn()
    {
        // TODO: ignore
        // bool kingIsInCheck = false;

        // TODO: change false -> true
        bool hasValidMoves = true;

        WhiteTurn = !WhiteTurn;

        if (WhiteTurn)
        {
            foreach (Transform piece in WhitePieces.transform)
            {
                // TODO: ignore
                // if (hasValidMoves == false && HasValidMoves(piece.gameObject))
                // {
                //     hasValidMoves = true;
                // }

                if (piece.name.Contains("Pawn"))
                {
                    piece.GetComponent<PieceController>().DoubleStep = false;
                }
                // TODO: edit king's logic
                // IGNORE CHECK
                // else if (piece.name.Contains("King"))
                // {
                //     kingIsInCheck = piece.GetComponent<PieceController>().IsInCheck(piece.position);
                // }
            }
        }
        else
        {
            foreach (Transform piece in BlackPieces.transform)
            {
                // TODO: ignore
                // if (hasValidMoves == false && HasValidMoves(piece.gameObject))
                // {
                //     hasValidMoves = true;
                // }

                if (piece.name.Contains("Pawn"))
                {
                    piece.GetComponent<PieceController>().DoubleStep = false;
                }
                // TODO: edit king's logic
                // IGNORE CHECK
                // else if (piece.name.Contains("King"))
                // {
                //     kingIsInCheck = piece.GetComponent<PieceController>().IsInCheck(piece.position);
                // }
            }
        }

        // TODO: edit 
        // IGNORE 
        // if (hasValidMoves == false)
        // {
        //     if (kingIsInCheck == false)
        //     {
        //         Stalemate();
        //     }
        //     else
        //     {
        //         Checkmate();
        //     }
        // }
    }

    // TODO: ignore
    // bool HasValidMoves(GameObject piece)
    // {
    //     PieceController pieceController = piece.GetComponent<PieceController>();
    //     GameObject encounteredEnemy;

    //     foreach (Transform square in Board.transform)
    //     {
    //         if (pieceController.ValidateMovement(piece.transform.position, new Vector3(square.position.x, square.position.y, piece.transform.position.z), out encounteredEnemy))
    //         {
    //             Debug.Log(piece + " on " + square);
    //             return true;
    //         }
    //     }
    //     return false;
    // }

    // TODO: ignore
    // void Stalemate()
    // {
    //     Debug.Log("Stalemate!");
    // }

    // TODO: ignore
    // void Checkmate()
    // {
    //     Debug.Log("Checkmate!");
    // }
}
