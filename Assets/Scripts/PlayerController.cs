using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	public Snake snake;

	void Update () 
	{
		//Inputs movimiento en X y en Z de snake (snake.direction).
		if (Input.GetKey (KeyCode.A)) snake.direction = new Vector3(-1f,0f,0f);
		if (Input.GetKey (KeyCode.D)) snake.direction = new Vector3(1f,0f,0f);
		if (Input.GetKey (KeyCode.W)) snake.direction = new Vector3(0f,0f,1f);
		if (Input.GetKey (KeyCode.S)) snake.direction = new Vector3(0f,0f,-1f);
	}
}