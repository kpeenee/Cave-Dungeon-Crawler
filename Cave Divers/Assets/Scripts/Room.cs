using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Room : MonoBehaviour
{
    [Header("Walls")]
    [SerializeField] Transform leftWall;
    [SerializeField] Transform frontWall;
    [SerializeField] Transform rightWall;
    [SerializeField] Transform backWall;

    public void RemoveWall(string wallToRemove)
    {
        if(wallToRemove == "Left")
        {
            Destroy(leftWall.gameObject);
        }else if(wallToRemove == "Right")
        {
            Destroy(rightWall.gameObject);
        }else if(wallToRemove == "Up")
        {
            Destroy(frontWall.gameObject);
        }else if(wallToRemove == "Down")
        {
            Destroy(backWall.gameObject);
        }
    }
}
