using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CavePiece : MonoBehaviour
{
    [SerializeField] Transform northWall, eastWall, southWall, westWall;

    public void DestroyWall(string wall)
    {
        if(wall == "north")
        {
            Destroy(northWall.gameObject);
        }else if(wall == "east")
        {
            Destroy(eastWall.gameObject);
        }else if(wall == "south")
        {
            Destroy(southWall.gameObject);
        }
        else if(wall == "west")
        {
            Destroy(westWall.gameObject);
        }
    }
}
