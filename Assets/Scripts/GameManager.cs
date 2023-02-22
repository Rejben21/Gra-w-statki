using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] ships;

    [Header("UI")]
    public Button nextButton;
    public Button rotateButton;

    private bool setupComplete = false;
    private bool playerTurn = true;
    private int shipIndex = 0;
    private ShipController shipController;

    void Start()
    {
        shipController = ships[shipIndex].GetComponent<ShipController>();
        nextButton.onClick.AddListener(() => NextShipClicked());
        rotateButton.onClick.AddListener(() => RotateShipClicked());
    }

    private void NextShipClicked()
    {
        if(shipIndex <= ships.Length -2)
        {
            shipIndex++;
            shipController = ships[shipIndex].GetComponent<ShipController>();
        }
    }

    void Update()
    {
        
    }

    public void TileClicked(GameObject tile)
    {
        if(setupComplete && playerTurn)
        {
            
        }
        else if(!setupComplete)
        {
            PlaceShip(tile);
            shipController.SetClickedTile(tile);
        }
    }

    public void RotateShipClicked()
    {
        shipController.RotateShip();
    }

    private void PlaceShip(GameObject tile)
    {
        shipController = ships[shipIndex].GetComponent<ShipController>();
        shipController.ClearTileList();
        Vector3 newPos = shipController.GetOffSetPos(tile.transform.position);
        ships[shipIndex].transform.localPosition = newPos;
    }
}
