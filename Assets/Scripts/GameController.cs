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
    public static bool WhiteTurn = true;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!CameraSwitcher.chessing) { DeselectPiece(); }
    }

    public void SelectPiece(GameObject piece)
    {
        if (piece.tag == "White" && WhiteTurn == true || piece.tag == "Black" && WhiteTurn == false)
        {
            DeselectPiece();
            SelectedPiece = piece;

            SelectedPiece.GetComponent<SpriteRenderer>().color = Color.yellow;

            Vector3 newPosition = SelectedPiece.transform.position;
            //newPosition.z = this.transform.position.z;
            SelectedPiece.transform.SetPositionAndRotation(newPosition, SelectedPiece.transform.rotation);
        }
    }

    public void DeselectPiece()
    {
        if (SelectedPiece != null)
        {
            SelectedPiece.GetComponent<SpriteRenderer>().color = Color.white;

            Vector3 newPosition = SelectedPiece.transform.position;
            //newPosition.z = this.transform.position.z;
            SelectedPiece.transform.SetPositionAndRotation(newPosition, SelectedPiece.transform.rotation);

            SelectedPiece = null;
        }
    }

    public void EndTurn()
    {
        WhiteTurn = !WhiteTurn;

        if (CaptureData.same)
        {
            Destroy(CaptureData.SelectedPiece);
            CaptureData.same = false;
        }

        if (WhiteTurn)
        {
            foreach (Transform piece in WhitePieces.transform)
            {
                if (piece.name.Contains("Pawn"))
                {
                    piece.GetComponent<PieceController>().DoubleStep = false;
                }
            }
        }
        else
        {
            foreach (Transform piece in BlackPieces.transform)
            {
                if (piece.name.Contains("Pawn"))
                {
                    piece.GetComponent<PieceController>().DoubleStep = false;
                }
            }
        }
    }
}