using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakePiece
{
	public bool isHead;
	public Transform piece;

	public float dist;

	public SnakePiece (Transform _piece)
	{
		piece = _piece;
	}

	public SnakePiece(bool _isHead, Transform _piece)
	{
		isHead = _isHead;
		piece = _piece;
	}

	public void NewPosition (SnakePiece pos)
	{
		//Posiciona la piece local en la posición de la piece de pos.

		if (piece == null) Debug.Log ("Ñoc");

		piece.position = pos.piece.position;
	}

	public bool Collision (Vector3 headPos)
	{		
		//true si la distancia entre piece y headPos < 0.5f.
		dist = Vector3.Distance(headPos, piece.position);

		Debug.Log ("Prepárate a morir, MUAJAJAJA");

		if (dist < 0.5f && !isHead) 
		{
			return true;
		} 
		else return false;
	}
}