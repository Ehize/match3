﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovablePiece : MonoBehaviour
{
    //GamePiece is attach to this script
    private GamePiece piece;
    private IEnumerator moveCoroutine;

    void Awake()
    {
        //Reference our GamePiece
        piece = GetComponent<GamePiece>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(int newX, int newY, float time)
	{
		if (moveCoroutine != null) {
			StopCoroutine(moveCoroutine);
		}
	    
		moveCoroutine = MoveCoroutine (newX, newY, time);
		StartCoroutine(moveCoroutine);
	}

    //Move piece a tiny bit each frame
    private IEnumerator MoveCoroutine(int newX, int newY, float time)
	{
		piece.X = newX;
		piece.Y = newY;
		
		Vector3 startPos = transform.position;
		Vector3 endPos = piece.GridRef.GetWorldPosition(newX, newY);
		
		for (float t = 0; t <= 1 * time; t += Time.deltaTime) {
			piece.transform.position = Vector3.Lerp(startPos, endPos, t / time);
			yield return 0;
		}
		
		piece.transform.position = endPos;
	}
}
