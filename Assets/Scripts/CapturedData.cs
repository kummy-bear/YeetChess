using System.Collections.Generic;
using UnityEngine;

public static class CaptureData
{
    public static List<Piece> destroyedByWhite = new List<Piece>();
    public static List<Piece> destroyedByBlack = new List<Piece>();
    public static GameObject SelectedPiece;
    public static bool same = false;
}