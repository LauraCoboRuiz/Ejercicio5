using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour 
{
	[Header("Objects")]
	public Snake snake;

	[Header("Vectors")]
	public Vector2 limX;
	public Vector2 limZ;

	void Update () 
	{
		//Limites en X y Z --> si salen this.GameOver()
		if (snake.transform.position.x >= limX.x) 
		{
			Debug.Log ("LimX.x");
			this.GameOver ();
		}

		if (snake.transform.position.x <= limZ.x) 
		{
			Debug.Log ("LimZ.x");
			this.GameOver ();
		}

		if (snake.transform.position.z >= limX.y) 
		{
			Debug.Log ("LimX.y");
			this.GameOver ();
		}

		if (snake.transform.position.z <= limZ.y) 
		{
			Debug.Log ("LimZ.y");
			this.GameOver ();
		}
	}

	public void GameOver()
	{
		//Destruir Snake script y GameController
		Debug.Log ("Modo Destroyer Activado");

		Destroy (snake);
		Destroy (this);
	}
}