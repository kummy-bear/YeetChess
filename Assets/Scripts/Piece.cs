using System.Collections.Generic;
using UnityEngine;

public class Piece
{
    public string Name { get; private set; }
    public string Color { get; private set; }
    public int Weight { get; private set; }

    public Piece(string fullName)
    {
        fullName = fullName.split(" ");
        Name = fullName[1];
        Color = fullName[0];

        if (name == "Rook")
        {
            Weight = 0;
        }
        else if (name == "Pawn")
        {
            Weight = 0;
        }
        else if (name == "Knight")
        {
            Weight = 0;
        }
        else if (name == "Princess")
        {
            Weight = 0;
        }
        else if (name == "Horse")
        {
            Weight = 0;
        }
        else if (name == "King")
        {
            Weight = 0;
        }
    }
}