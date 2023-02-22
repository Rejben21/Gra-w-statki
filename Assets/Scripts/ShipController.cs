using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    List<GameObject> touchTiles = new List<GameObject>();
    public float xOffset = 0, yOffset = 0, zOffset = 0;
    private float nextYRotation = 90;
    private GameObject clickedTile;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ClearTileList()
    {
        touchTiles.Clear();
    }

    public Vector3 GetOffSetPos(Vector3 tilePos)
    {
        return new Vector3(tilePos.x + xOffset, tilePos.y + yOffset, tilePos.z + zOffset);
    }

    public void RotateShip()
    {
        touchTiles.Clear();
        transform.localEulerAngles += new Vector3(0, nextYRotation, 0);
        nextYRotation *= -1;
        float temp = xOffset;
        xOffset = zOffset;
        zOffset = temp;
        SetPosition(clickedTile.transform.position);
    }

    public void SetPosition(Vector3 newPos)
    {
        transform.localPosition = new Vector3(newPos.x + xOffset, newPos.y + yOffset, newPos.z + zOffset);
    }

    public void SetClickedTile(GameObject tile)
    {
        clickedTile = tile;
    }
}
