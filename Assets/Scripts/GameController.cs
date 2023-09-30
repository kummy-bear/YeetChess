using System.Collections;
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

            SelectedPiece.GetComponent<SpriteRenderer>().color = Color.yellow;

            Vector3 newPosition = SelectedPiece.transform.position;
            newPosition.z = -1;
            SelectedPiece.transform.SetPositionAndRotation(newPosition, SelectedPiece.transform.rotation);
        }
    }

    public void DeselectPiece()
    {
        if (SelectedPiece != null)
        {
            SelectedPiece.GetComponent<SpriteRenderer>().color = Color.white;

            Vector3 newPosition = SelectedPiece.transform.position;
            newPosition.z = 0;
            SelectedPiece.transform.SetPositionAndRotation(newPosition, SelectedPiece.transform.rotation);

            SelectedPiece = null;
        }
    }

    public void EndTurn()
    {
        bool hasValidMoves = true;

        WhiteTurn = !WhiteTurn;

        if (CaptureData.same)
        {
            Destroy(CaptureData.SelectedPiece);
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
