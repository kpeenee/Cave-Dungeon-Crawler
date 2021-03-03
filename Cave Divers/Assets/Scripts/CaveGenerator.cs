using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveGenerator : MonoBehaviour
{
    [SerializeField] List<GameObject> caveCorridoor = new List<GameObject>();
    [SerializeField] List<GameObject> caveDeadEnd = new List<GameObject>();
    [SerializeField] List<GameObject> caveTurnLeft = new List<GameObject>();
    [SerializeField] List<GameObject> caveTurnRight = new List<GameObject>();

    private int xCor = 0;
    private int yCor = 0;
    private int rotation = 0;
    

    private void Start()
    {
        GenerateCave();
    }

    private void GenerateCave()
    {
        rotation = 180;
        PlaceDeadEnd();
        rotation = 0;
        MoveCor();
        for(int i = 0; i< 5; i++)
        {
            GenCorridoor();
            GenTurn();
        }


        PlaceDeadEnd();
    }

    private void GenTurn()
    {
        int chooseDir = UnityEngine.Random.Range(0, 3);
        if(chooseDir <= 1)
        {
            GameObject cavePiece = Instantiate(caveTurnLeft[0], transform.position, Quaternion.identity);
            cavePiece.transform.position = new Vector3(8 * xCor, 0, 8 * yCor);
            cavePiece.transform.rotation = Quaternion.Euler(0, rotation, 0); 
            rotation -= 90;
            CheckRotation();
            MoveCor();
        }
        else
        {
            GameObject cavePiece = Instantiate(caveTurnRight[0], transform.position, Quaternion.identity);
            cavePiece.transform.position = new Vector3(8 * xCor, 0, 8 * yCor);
            cavePiece.transform.rotation = Quaternion.Euler(0, rotation, 0);
            rotation += 90;
            CheckRotation();
            MoveCor();
        }
    }

    private void MoveCor()
    {
        if(rotation == 0)
        {
            xCor++;
        }else if(rotation == 90)
        {
            yCor--;
        }else if(rotation == 180)
        {
            xCor--;
        }else if(rotation == 270)
        {
            yCor++;
        }
    }

    private void CheckRotation()
    {
        if(rotation< 0)
        {
            rotation = 270;
        }
        if(rotation > 270)
        {
            rotation = 0;
        }
    }

    private void PlaceDeadEnd()
    {
        int ranNumb = UnityEngine.Random.Range(0, caveDeadEnd.Count);
        GameObject caveEnd = Instantiate(caveDeadEnd[ranNumb], transform.position, Quaternion.identity);
        caveEnd.transform.position = new Vector3(8 * xCor, 0, 8 * yCor);
        caveEnd.transform.rotation = Quaternion.Euler(0, rotation, 0);
        
    }

    private void GenCorridoor()
    {
        for (int i = 0; i < 5; i++)
        {
            int ranNum = UnityEngine.Random.Range(0, caveCorridoor.Count);
            GameObject cavePiece = Instantiate(caveCorridoor[ranNum], transform.position, Quaternion.identity);
            cavePiece.transform.position = new Vector3(8 * xCor, 0, 8 * yCor);
            cavePiece.transform.rotation = Quaternion.Euler(0, rotation, 0);
            MoveCor();
        }
    }
}
