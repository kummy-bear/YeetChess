using System.Collections.Generic;
using UnityEngine;

public class Piece
{
    public string Name { get; private set; }
    public string Color { get; private set; }
    public int Weight { get; private set; }

    public Piece(string fullName)
    {
        string[] temp = fullName.Split(' ');
        Name = temp[1];
        Color = temp[0];

        if (Name == "Rook")
        {
            Weight = 0;
        }
        else if (Name == "Pawn")
        {
            Weight = 0;
        }
        else if (Name == "Knight")
        {
            Weight = 0;
        }
        else if (Name == "Princess")
        {
            Weight = 0;
        }
        else if (Name == "Horse")
        {
            Weight = 0;
        }
        else if (Name == "King")
        {
            Weight = 0;
        }
    }
}