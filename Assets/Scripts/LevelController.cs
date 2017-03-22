using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelController : MonoBehaviour
{
    public int ID;
    private bool hasBeenCompleted;
    public bool hasMapPiece;
    private bool mapPieceWasFound;
	public GameObject mapPiece;

	public void Start()
	{
		if (hasMapPiece) 
		{
			mapPiece.SetActive (false);
		}
	}

    public void mapPieceFound()
    {
        mapPieceWasFound = true;
    }

    public int getID()
    {
        return ID;
    }

    public bool getHasBeenCompleted()
    {
        return hasBeenCompleted;
    }

    public bool gethasMapPiece()
    {
        return hasMapPiece;
    }

    public bool getMapPieceFound()
    {
        return mapPieceWasFound;
    }

    public void foundMapPiece()
    {
        mapPieceWasFound = true;
    }

    public void print()
    {
        string data = "ID: " + ID + ", completed: " + hasBeenCompleted + ", hasMapPiece: " + hasMapPiece + ", mapPieceWasFound: " + mapPieceWasFound;
        Console.WriteLine(data);
    }
}