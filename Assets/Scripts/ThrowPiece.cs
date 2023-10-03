using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ObjectThrower : MonoBehaviour
{
    public float throwForce = 10f;
    private Camera arCamera;
    public GameObject whitePawn;
    public GameObject blackPawn;
    public GameObject whiteRook;
    public GameObject blackRook;
    public GameObject whiteHorse;
    public GameObject blackHorse;
    public GameObject whiteBishop;
    public GameObject blackBishop;
    public GameObject whiteQueen;
    public GameObject blackQueen;
    public GameObject whiteKing;
    public GameObject blackKing;


    private void Start()
    {
        arCamera = Camera.main; // Get the AR camera
    }

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (!IsPointerOverUIObject())
            {
                ThrowObject();
            }
        }
    }

    private void ThrowObject()
    {
        if (!CameraSwitcher.chessing)
        {
            GameObject objectToThrow = whitePawn;
            if (GameController.WhiteTurn)
            {
                if (CaptureData.destroyedByWhite[0].Color == "White")
                {
                    if (CaptureData.destroyedByWhite[0].Name == "Pawn")
                    {
                        objectToThrow = whitePawn;
                    }
                    if (CaptureData.destroyedByWhite[0].Name == "Rook")
                    {
                        objectToThrow = whiteRook;
                    }
                    if (CaptureData.destroyedByWhite[0].Name == "Horse")
                    {
                        objectToThrow = whiteHorse;
                    }
                    if (CaptureData.destroyedByWhite[0].Name == "Bishop")
                    {
                        objectToThrow = whiteBishop;
                    }
                    if (CaptureData.destroyedByWhite[0].Name == "Queen")
                    {
                        objectToThrow = whiteQueen;
                    }
                    if (CaptureData.destroyedByWhite[0].Name == "King")
                    {
                        objectToThrow = whiteKing;
                    }
                }
                if (CaptureData.destroyedByWhite[0].Color == "Black")
                {
                    if (CaptureData.destroyedByWhite[0].Name == "Pawn")
                    {
                        objectToThrow = blackPawn;
                    }
                    if (CaptureData.destroyedByWhite[0].Name == "Rook")
                    {
                        objectToThrow = blackRook;
                    }
                    if (CaptureData.destroyedByWhite[0].Name == "Horse")
                    {
                        objectToThrow = blackHorse;
                    }
                    if (CaptureData.destroyedByWhite[0].Name == "Bishop")
                    {
                        objectToThrow = blackBishop;
                    }
                    if (CaptureData.destroyedByWhite[0].Name == "Queen")
                    {
                        objectToThrow = blackQueen;
                    }
                    if (CaptureData.destroyedByWhite[0].Name == "King")
                    {
                        objectToThrow = blackKing;
                    }
                }
            }
            else
            {
                if (CaptureData.destroyedByBlack[0].Color == "White")
                {
                    if (CaptureData.destroyedByBlack[0].Name == "Pawn")
                    {
                        objectToThrow = whitePawn;
                    }
                    if (CaptureData.destroyedByBlack[0].Name == "Rook")
                    {
                        objectToThrow = whiteRook;
                    }
                    if (CaptureData.destroyedByBlack[0].Name == "Horse")
                    {
                        objectToThrow = whiteHorse;
                    }
                    if (CaptureData.destroyedByBlack[0].Name == "Bishop")
                    {
                        objectToThrow = whiteBishop;
                    }
                    if (CaptureData.destroyedByBlack[0].Name == "Queen")
                    {
                        objectToThrow = whiteQueen;
                    }
                    if (CaptureData.destroyedByBlack[0].Name == "King")
                    {
                        objectToThrow = whiteKing;
                    }
                }
                if (CaptureData.destroyedByBlack[0].Color == "Black")
                {
                    if (CaptureData.destroyedByBlack[0].Name == "Pawn")
                    {
                        objectToThrow = blackPawn;
                    }
                    if (CaptureData.destroyedByBlack[0].Name == "Rook")
                    {
                        objectToThrow = blackRook;
                    }
                    if (CaptureData.destroyedByBlack[0].Name == "Horse")
                    {
                        objectToThrow = blackHorse;
                    }
                    if (CaptureData.destroyedByBlack[0].Name == "Bishop")
                    {
                        objectToThrow = blackBishop;
                    }
                    if (CaptureData.destroyedByBlack[0].Name == "Queen")
                    {
                        objectToThrow = blackQueen;
                    }
                    if (CaptureData.destroyedByBlack[0].Name == "King")
                    {
                        objectToThrow = blackKing;
                    }
                }
                
            }
            // Create the object clone
            GameObject objClone = Instantiate(objectToThrow, arCamera.transform.position, arCamera.transform.rotation);
            objClone.AddComponent<BoxCollider>();
            // Get the rigidbody
            Rigidbody rb = objClone.AddComponent<Rigidbody>();
            rb.useGravity = true;
            rb.mass = CaptureData.destroyedByWhite[0].Weight;
            // Apply force to throw the object forward
            rb.AddForce(arCamera.transform.forward * throwForce * CaptureData.destroyedByWhite[0].Weight, ForceMode.Impulse);
        }
        
    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        // Raycast to check if the pointer (touch) is over a UI element
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

        return results.Count > 0;
    }
}
