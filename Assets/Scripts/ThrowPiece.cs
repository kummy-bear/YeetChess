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
    public GameObject empty;

    private int i = TextController.currentIndex;

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
        i = TextController.currentIndex;
    }

    private void ThrowObject()
    {
        if (!CameraSwitcher.chessing)
        {
            int wei = 1;
            GameObject objectToThrow = empty;
            if (GameController.WhiteTurn && CaptureData.destroyedByWhite.Count > 0)
            {
                wei = CaptureData.destroyedByWhite[i].Weight;
                if (CaptureData.destroyedByWhite[i].Color == "White")
                {
                    if (CaptureData.destroyedByWhite[i].Name == "Pawn")
                    {
                        objectToThrow = whitePawn;
                        
                    }
                    if (CaptureData.destroyedByWhite[i].Name == "Rook")
                    {
                        objectToThrow = whiteRook;
                    }
                    if (CaptureData.destroyedByWhite[i].Name == "Horse")
                    {
                        objectToThrow = whiteHorse;
                    }
                    if (CaptureData.destroyedByWhite[i].Name == "Bishop")
                    {
                        objectToThrow = whiteBishop;
                    }
                    if (CaptureData.destroyedByWhite[i].Name == "Queen")
                    {
                        objectToThrow = whiteQueen;
                    }
                    if (CaptureData.destroyedByWhite[i].Name == "King")
                    {
                        objectToThrow = whiteKing;
                    }
                }
                if (CaptureData.destroyedByWhite[i].Color == "Black")
                {
                    if (CaptureData.destroyedByWhite[i].Name == "Pawn")
                    {
                        objectToThrow = blackPawn;
                    }
                    if (CaptureData.destroyedByWhite[i].Name == "Rook")
                    {
                        objectToThrow = blackRook;
                    }
                    if (CaptureData.destroyedByWhite[i].Name == "Horse")
                    {
                        objectToThrow = blackHorse;
                    }
                    if (CaptureData.destroyedByWhite[i].Name == "Bishop")
                    {
                        objectToThrow = blackBishop;
                    }
                    if (CaptureData.destroyedByWhite[i].Name == "Queen")
                    {
                        objectToThrow = blackQueen;
                    }
                    if (CaptureData.destroyedByWhite[i].Name == "King")
                    {
                        objectToThrow = blackKing;
                    }
                }
                CaptureData.destroyedByWhite.RemoveAt(i);
            }
            else if (!GameController.WhiteTurn &&CaptureData.destroyedByBlack.Count > 0)
            {
                wei = CaptureData.destroyedByWhite[i].Weight;
                if (CaptureData.destroyedByBlack[i].Color == "White")
                {
                    if (CaptureData.destroyedByBlack[i].Name == "Pawn")
                    {
                        objectToThrow = whitePawn;
                    }
                    if (CaptureData.destroyedByBlack[i].Name == "Rook")
                    {
                        objectToThrow = whiteRook;
                    }
                    if (CaptureData.destroyedByBlack[i].Name == "Horse")
                    {
                        objectToThrow = whiteHorse;
                    }
                    if (CaptureData.destroyedByBlack[i].Name == "Bishop")
                    {
                        objectToThrow = whiteBishop;
                    }
                    if (CaptureData.destroyedByBlack[i].Name == "Queen")
                    {
                        objectToThrow = whiteQueen;
                    }
                    if (CaptureData.destroyedByBlack[i].Name == "King")
                    {
                        objectToThrow = whiteKing;
                    }
                }
                if (CaptureData.destroyedByBlack[i].Color == "Black")
                {
                    if (CaptureData.destroyedByBlack[i].Name == "Pawn")
                    {
                        objectToThrow = blackPawn;
                    }
                    if (CaptureData.destroyedByBlack[i].Name == "Rook")
                    {
                        objectToThrow = blackRook;
                    }
                    if (CaptureData.destroyedByBlack[i].Name == "Horse")
                    {
                        objectToThrow = blackHorse;
                    }
                    if (CaptureData.destroyedByBlack[i].Name == "Bishop")
                    {
                        objectToThrow = blackBishop;
                    }
                    if (CaptureData.destroyedByBlack[i].Name == "Queen")
                    {
                        objectToThrow = blackQueen;
                    }
                    if (CaptureData.destroyedByBlack[i].Name == "King")
                    {
                        objectToThrow = blackKing;
                    }
                }
                CaptureData.destroyedByBlack.RemoveAt(i);
            }
            // Create the object clone
            GameObject objClone = Instantiate(objectToThrow, arCamera.transform.position, arCamera.transform.rotation);
            objClone.AddComponent<BoxCollider>();
            // Get the rigidbody
            Rigidbody rb = objClone.AddComponent<Rigidbody>();
            rb.useGravity = true;
            rb.mass = wei;
            // Apply force to throw the object forward
            rb.AddForce(arCamera.transform.forward * throwForce * wei, ForceMode.Impulse);
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
