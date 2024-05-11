using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the entire game
/// </summary>
public class GameManager : MonoBehaviour
{
    public int level;

    private BoardManager bm;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before any of the Update methods are called.
    /// </summary>
    private void Start() {
        bm = GetComponent<BoardManager>();
        // gm runs first so set bm.gm
        bm.gm = this;

        // J piece
        bm.PlaceCell(6, 9, CellColor.Color2);
        bm.PlaceCell(6, 10, CellColor.Color2);
        bm.PlaceCell(5, 10, CellColor.Color2);
        bm.PlaceCell(4, 10, CellColor.Color2);
        
        // test overlap removal
        bm.PlaceCell(5, 10, CellColor.Color3);
    }

    /// <summary>
    /// Update is called every fram, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update() {
        
    }
}
