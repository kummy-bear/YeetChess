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



    int d = -1;
    private void Start()
    {
        arCamera = Camera.main; // Get the AR camera
    }

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (!IsPointerOverUIObject() && ButtonNumberAssignment.buttFlag)
            {
                ThrowObject();
            }
        }
        
    }

    private void ThrowObject()
    {
        ButtonNumberAssignment.buttFlag = false;
        if (!CameraSwitcher.chessing)
        {
            int wei = 1;
            d = -1;
            GameObject objectToThrow = empty;
            if (GameController.WhiteTurn && CaptureData.destroyedByWhite.Count > 0)
            {
                foreach (Piece p in CaptureData.destroyedByWhite)
                {
                    d++;
                    if (p.Name == addpieces.pieceList[TextController.currentIndex])
                    {
                        if(p.Name == "Pawn")
                        {
                            if (p.Color == "White")
                            {
                                objectToThrow = whitePawn;
                            }
                            else
                            {
                                objectToThrow = blackPawn;
                            }
                        }
                        if (p.Name == "Horse")
                        {
                            if (p.Color == "White")
                            {
                                objectToThrow = whiteHorse;
                            }
                            else
                            {
                                objectToThrow = blackHorse;
                            }
                        }
                        if (p.Name == "Bishop")
                        {
                            if (p.Color == "White")
                            {
                                objectToThrow = whiteBishop;
                            }
                            else
                            {
                                objectToThrow = blackBishop;
                            }
                        }
                        if (p.Name == "Rook")
                        {
                            if (p.Color == "White")
                            {
                                objectToThrow = whiteRook;
                            }
                            else
                            {
                                objectToThrow = blackRook;
                            }
                        }
                        if (p.Name == "Queen")
                        {
                            if (p.Color == "White")
                            {
                                objectToThrow = whiteQueen;
                            }
                            else
                            {
                                objectToThrow = blackQueen;
                            }
                        }
                        if (p.Name == "King")
                        {
                            if (p.Color == "White")
                            {
                                objectToThrow = whiteKing;
                            }
                            else
                            {
                                objectToThrow = blackKing;
                            }
                        }
                        break;
                    }
                    
                }
                CaptureData.destroyedByWhite.RemoveAt(d);
            }
            else if (!GameController.WhiteTurn && CaptureData.destroyedByBlack.Count > 0)
            {
                foreach (Piece p in CaptureData.destroyedByBlack)
                {
                    d++;
                    if (p.Name == addpieces.pieceList[TextController.currentIndex])
                    {
                        if (p.Name == "Pawn")
                        {
                            if (p.Color == "White")
                            {
                                objectToThrow = whitePawn;
                            }
                            else
                            {
                                objectToThrow = blackPawn;
                            }
                        }
                        if (p.Name == "Horse")
                        {
                            if (p.Color == "White")
                            {
                                objectToThrow = whiteHorse;
                            }
                            else
                            {
                                objectToThrow = blackHorse;
                            }
                        }
                        if (p.Name == "Bishop")
                        {
                            if (p.Color == "White")
                            {
                                objectToThrow = whiteBishop;
                            }
                            else
                            {
                                objectToThrow = blackBishop;
                            }
                        }
                        if (p.Name == "Rook")
                        {
                            if (p.Color == "White")
                            {
                                objectToThrow = whiteRook;
                            }
                            else
                            {
                                objectToThrow = blackRook;
                            }
                        }
                        if (p.Name == "Queen")
                        {
                            if (p.Color == "White")
                            {
                                objectToThrow = whiteQueen;
                            }
                            else
                            {
                                objectToThrow = blackQueen;
                            }
                        }
                        if (p.Name == "King")
                        {
                            if (p.Color == "White")
                            {
                                objectToThrow = whiteKing;
                            }
                            else
                            {
                                objectToThrow = blackKing;
                            }
                        }
                        break;
                    }
                    
                    
                }
                CaptureData.destroyedByBlack.RemoveAt(d);
            }
            else
            {
                Debug.Log("no pieces?");
                return;
            }
            // Create the object clone
            if (objectToThrow == empty)
            {
                return;
            }
            GameObject objClone = Instantiate(objectToThrow, arCamera.transform.position, arCamera.transform.rotation);
            objClone.AddComponent<BoxCollider>();
            objClone.tag = "Throw";
            // Get the rigidbody
            Rigidbody rb = objClone.AddComponent<Rigidbody>();
            rb.useGravity = true;
            rb.mass = wei;
            // Apply force to throw the object forward
            rb.AddForce(arCamera.transform.forward * throwForce * wei, ForceMode.Impulse);
            pieceCounter.countPieces();
            
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
