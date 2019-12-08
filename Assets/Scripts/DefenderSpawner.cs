using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    List<Defender> defenderList;

    private void Start()
    {
        CreateDefenderList();
    }

    public void OnMouseDown()
    {
        if (defender != null)
        {
            AttemtToPlaceDefenderAt(GetSquareClicked());
        }
    }

    public void SetSelectedDefender (Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    private void AttemtToPlaceDefenderAt(Vector2 gridPos)
    {
        if (IsSquareEmptyAt(gridPos))
        {
            var starDisplay = FindObjectOfType<StarDisplay>();
            int defenderCost = defender.GerStarCost();
            if (starDisplay.HaveEnoughtStars(defenderCost))
            {
                SpawnDefender(gridPos);
                starDisplay.SpendStars(defenderCost);
            }
        }
    }

    private bool IsSquareEmptyAt(Vector2 gridPos)
    {
        foreach (var storedDefender in defenderList)
        {
            if (gridPos.x == storedDefender.transform.localPosition.x
                && gridPos.y == storedDefender.transform.localPosition.y)
            {
                return false;
            }
        }
        return true;
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clicPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clicPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }
    
    private void SpawnDefender(Vector2 coordinates)
    {
        Defender newDefender = Instantiate(defender, coordinates, Quaternion.identity) as Defender;
        defenderList.Add(newDefender);
    }

    public void RemoveDefenderFromList(Defender defenderToRemove)
    {
        defenderList.Remove(defenderToRemove);
    }

    private void CreateDefenderList()
    {
        var alreadyExisringDefenders = FindObjectsOfType<Defender>();
        if (alreadyExisringDefenders.Length > 0)
        {
            defenderList = new List<Defender>(alreadyExisringDefenders);
        }
        else
        {
            defenderList = new List<Defender>();
        }
    }
}
