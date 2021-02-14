using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField] int minRooms;
    [SerializeField] int maxRooms;
    [SerializeField] GameObject room;
    private int[,] roomGrid = new int[10,5];

    private void Awake()
    {
        InitArray();
    }

    // Start is called before the first frame update
    void Start()
    {
        GenerateMainPath();
    }

    private void GenerateMainPath()
    {
        int currX = 4;
        int currY = 2;

        GameObject CurrentRoom = Instantiate(room, transform.position, Quaternion.identity);
        CurrentRoom.transform.position = new Vector3(40 * currX, 0, 40 * currY);
        roomGrid[currX, currY] = 1;
        for(int i = 0; i< 10; i++)
        {
            bool canMove = false;
            while (canMove == false)
            {
                float randNum = UnityEngine.Random.Range(0, 10);
                if (randNum >= 0 && randNum < 2.5f)
                {
                   canMove = CheckPos(currX - 1, currY);
                   if (canMove == true) { currX--; }
                }
                if (randNum >= 2.5f && randNum < 5)
                {
                   canMove = CheckPos(currX + 1, currY);
                   if (canMove == true) { currX++; }
                }
                if (randNum >= 5 && randNum < 7.5f)
                {
                   canMove = CheckPos(currX, currY - 1);
                   if (canMove == true) { currY--; }
                }
                if (randNum >= 7.5f && randNum < 10)
                {
                   canMove = CheckPos(currX, currY + 1);
                   if(canMove == true) { currY++; }
                }
            }

            CurrentRoom = Instantiate(room, transform.position, Quaternion.identity);
            CurrentRoom.transform.position = new Vector3(40 * currX, 0, 40 * currY);
            roomGrid[currX, currY] = 1;

        }
    }

    private bool CheckPos(int xPos, int yPos)
    {
        if(xPos < 0 || xPos >= roomGrid.GetLength(0))
        {
            return false;
        }
        if (yPos < 0 || yPos >= roomGrid.GetLength(1))
        {
            return false;
        }
        if (roomGrid[xPos,yPos] == 1)
        {
            return false;
        } else
        {
            return true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitArray()
    {
        for (int i = 0; i < roomGrid.GetLength(0); i++)
        {
            for (int j = 0; j < roomGrid.GetLength(1); j++)
            {
                roomGrid[i, j] = 0;
                Debug.Log(roomGrid[i, j]);
            }
        }
    }
}
