using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;


public class CaveGenerator : MonoBehaviour
{
    [SerializeField] List<GameObject> cavePieces = new List<GameObject>();
    [SerializeField] int minCorridoorLen = 1;
    [SerializeField] int maxCorridoorLen = 4;
    [SerializeField] int genAmount = 5;
    [SerializeField] int arenaWidth = 3;
    [SerializeField] int arenaHeight = 3;
    [SerializeField] GameObject arena;
    [SerializeField] GameObject endRoom;
    

    private CavePiece[,] cave = new CavePiece[50,50];
    private int xCor = 25;
    private int yCor = 25;
    Direction dir = Direction.North;
    

    private void Start()
    {
        GenerateCave();
        BuildNavMesh();
    }

    private void BuildNavMesh()
    {
        NavMeshSurface[] surfaces = FindObjectsOfType<NavMeshSurface>();
        for(int i = 0; i < surfaces.Length; i++)
        {
            surfaces[i].BuildNavMesh();
        }
    }

    private void GenerateCave()
    {
        for(int i = 0; i<= genAmount; i++)
        {
            CreateCorridoor();
            if(i % 5 == 0)
            {
                CreateArena();
            }
            dir = ChangeDirection();
        }
        PlaceEnd();
        CheckForDestruction();
    }

    private void PlaceEnd()
    {
        bool isPlaced = false;
        do
        {
            if (xCor >= 0 && yCor >= 0 && xCor < cave.GetLength(0) && yCor < cave.GetLength(1))
            {
                if (cave[xCor, yCor] == null)
                {
                    CavePiece currenPiece = Instantiate(endRoom, transform.position, Quaternion.identity).GetComponent<CavePiece>();
                    currenPiece.transform.position = new Vector3(xCor * 8, 0, yCor * 8);
                    cave[xCor, yCor] = currenPiece;
                    isPlaced = true;
                }
            }
            if(isPlaced == false)
            {
                MoveCords();
            }
        } while (isPlaced == false);
    }

    private void CreateArena()
    {
        MoveCords();
        //Save arena midpoint
        int midX = xCor;
        int midY = yCor;
        //Place Cordinates in bottom left of arena
        xCor--;
        yCor--;
        for(int i = 0; i < arenaHeight; i++)
        {
            for(int j = 0; j < arenaWidth; j++)
            {
                if (cave[xCor, yCor] == null)
                {
                    PlaceCavePiece();
                }
                xCor++;
            }
            yCor++;
            xCor -= arenaWidth;
        }

        //Reset cordinates to middle
        xCor = midX;
        yCor = midY;

        GameObject newArena = Instantiate(arena, transform.position, Quaternion.identity);
        newArena.transform.position = new Vector3(xCor * 8, 0, yCor * 8);

        Debug.Log("Success");
    }

    private Direction ChangeDirection()
    {
        float randNum = UnityEngine.Random.Range(0, 2);
        if(dir == Direction.North|| dir == Direction.South)
        {
            if(randNum < 1) { return Direction.West; }
            else { return Direction.East; }
        }
        if(randNum < 1) { return Direction.North; }
        else { return Direction.South; }
    }

    private void CreateCorridoor()
    {
        int howMany = UnityEngine.Random.Range(minCorridoorLen, maxCorridoorLen);
        for(int i = 0; i <= howMany; i++)
        {
            if (cave[xCor, yCor] == null)
            {
                PlaceCavePiece();
                MoveCords();
            }
            else
            {
                MoveCords();
            }
        }
    }

    private void PlaceCavePiece()
    {
        int RandNum = UnityEngine.Random.Range(0, cavePieces.Count);
        CavePiece currenPiece = Instantiate(cavePieces[RandNum], transform.position, Quaternion.identity).GetComponent<CavePiece>();
        currenPiece.transform.position = new Vector3(xCor * 8, 0, yCor * 8);
        cave[xCor, yCor] = currenPiece;
    }

    private void CheckForDestruction()
    {
        for (int i = 0; i < cave.GetLength(0); i++)
        {
            for (int j = 0; j < cave.GetLength(1); j++)
            {
                if (cave[i, j] != null)
                {
                    FindWallsToDestroy(i, j);
                }
            }
        }
    }

    private void FindWallsToDestroy(int i, int j)
    {
        if (i + 1 < cave.GetLength(0))
        {
            if (cave[i + 1, j] != null)
            {
                cave[i, j].DestroyWall("east");
            }
        }
        if (i - 1 >= 0)
        {
            if (cave[i - 1, j] != null)
            {
                cave[i, j].DestroyWall("west");
            }
        }
        if (j + 1 < cave.GetLength(1))
        {
            if (cave[i, j + 1] != null)
            {
                cave[i, j].DestroyWall("north");
            }
        }
        if (j - 1 >= 0)
        {
            if (cave[i, j - 1] != null)
            {
                cave[i, j].DestroyWall("south");
            }
        }
    }

    private void MoveCords()
    {
        if(dir == Direction.North) { xCor++; }
        else if(dir == Direction.East) { yCor++; }
        else if(dir == Direction.South) { xCor--; }
        else if(dir == Direction.West) { yCor--; }

        if(xCor < 0 || xCor >= cave.GetLength(0))
        {
            ResetCords();
        }
        if(yCor < 0 || yCor >= cave.GetLength(1))
        {
            ResetCords();
        }
    }

    private void ResetCords()
    {
        xCor = 25;
        yCor = 25;
    }
}
