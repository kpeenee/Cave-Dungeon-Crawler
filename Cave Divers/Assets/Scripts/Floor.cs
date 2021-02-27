using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField] int minRooms;
    [SerializeField] int maxRooms;
    [SerializeField] GameObject room;
    private Room[,] roomGrid = new Room[10,5];

    void Start()
    {
        GenerateMainPath();
        RemoveWalls();
    }

    

    private void GenerateMainPath()
    {
        int currX = 4;
        int currY = 2;

        GameObject CurrentRoom = Instantiate(room, transform.position, Quaternion.identity);
        CurrentRoom.transform.position = new Vector3(40 * currX, 0, 40 * currY);
        roomGrid[currX, currY] = CurrentRoom.GetComponent<Room>();

        int numOfAttempts = 0;
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

                numOfAttempts++;
                if(canMove == false && numOfAttempts > 50)
                {
                    if(currX + 1 < roomGrid.GetLength(0))
                    {
                        currX++;
                    }
                    else
                    {
                        currX--;
                    }
                    if(currY + 1 < roomGrid.GetLength(1))
                    {
                        currY++;
                    }
                    else
                    {
                        currY--;
                    }
                    numOfAttempts = 0;
                }
            }

            CurrentRoom = Instantiate(room, transform.position, Quaternion.identity);
            CurrentRoom.transform.position = new Vector3(40 * currX, 0, 40 * currY);
            roomGrid[currX, currY] = CurrentRoom.GetComponent<Room>();
            numOfAttempts = 0;
        }
    }

    private void RemoveWalls()
    {
        for (int i = 0; i < roomGrid.GetLength(0); i++)
        {
            for (int j = 0; j < roomGrid.GetLength(1); j++)
            {
                if (roomGrid[i, j] != null)
                {
                    //Check Left
                    if (i - 1 >= 0 && roomGrid[i - 1, j] != null)
                    {
                        roomGrid[i, j].RemoveWall("Left");
                    }
                    //Check Right
                    if (i + 1 < roomGrid.GetLength(0) && roomGrid[i + 1, j] != null)
                    {
                        roomGrid[i, j].RemoveWall("Right");
                    }
                    //Check Up
                    if (j + 1 < roomGrid.GetLength(1) && roomGrid[i, j + 1] != null)
                    {
                        roomGrid[i, j].RemoveWall("Up");
                    }
                    //Check Down
                    if (j - 1 >= 0 && roomGrid[i, j - 1] != null)
                    {
                        roomGrid[i, j].RemoveWall("Down");
                    }
                }
            }
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
        if (roomGrid[xPos,yPos] != null)
        {
            return false;
        } else
        {
            return true;
        }
    }
}
