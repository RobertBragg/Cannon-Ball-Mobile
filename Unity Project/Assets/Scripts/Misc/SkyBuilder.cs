using UnityEngine;
using System.Collections;

public class SkyBuilder : MonoBehaviour 
{
    public GameObject[] skyPieces;
    public float sizeOfPieces;
    float top;

    public Transform playerTrans;

    void Start()
    {
        top = 10;
    }

    void Update()
    {
        float pos = top + sizeOfPieces * 2;
        if (playerTrans != null && playerTrans.position.y > top - sizeOfPieces * 2)
        {
            GameObject sky = (GameObject)Instantiate(skyPieces[Random.Range(0, skyPieces.Length)], new Vector3(0, pos, 1), Quaternion.identity);
            sky.transform.localScale *= 2;
            top += sizeOfPieces;
        }
    }
}
