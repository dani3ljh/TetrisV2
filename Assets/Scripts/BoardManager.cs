using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a cell's state of either empty, color1, color2, or color3
/// </summary>
public enum CellType {
    Empty,
    Color1,
    Color2,
    Color3
}

/// <summary>
/// Manages the state of the board
/// </summary>
public class BoardManager : MonoBehaviour
{
    public CellType[,] cells = new CellType[10, 20];

    [SerializeField] private Transform cellsParent;
    [SerializeField] private GameObject cellPrefab;
    [SerializeField] private Material[] materials;

    [HideInInspector] public GameManager gm;

    #nullable enable
    private GameObject?[,] cellGameObjects = new GameObject?[10, 20];

    /// <summary>
    /// Start is called on the frame when a script is enabled just before any of the Update methods are called
    /// </summary>
    private void Start() {
        // Initialize cells
        for (int x = 0; x < 10; x++) {
            for (int y = 0; y < 20; y++) {
                cells[x, y] = CellType.Empty;
            }
        }
    }

    /// <summary>
    /// Update is called every fram, if the MonoBehaviour is enabled
    /// </summary>
    private void Update() {
        
    }

    public void PlaceCell(int x, int y, CellType color) {
        cells[x, y] = color;

        if (color == CellType.Empty) {
            GameObject? cellGameObject = cellGameObjects[x, y];
            if (cellGameObject != null)
                Destroy(cellGameObject);
            return;
        }

        Vector3 cellSize = cellPrefab.GetComponent<SpriteRenderer>().bounds.size;

        // 4.5 cellsWidth left plus x cellsWidth right then factor out cellsWidth, do same for y
        Vector3 position = new Vector3(cellSize.x * (-4.5f + x), cellSize.y * (9.5f - y), 0);
        
        GameObject cell = Instantiate(cellPrefab, position, cellPrefab.transform.rotation, cellsParent);

        cellGameObjects[x, y] = cell;

        int materialIndex = 3 * gm.level;

        if (color == CellType.Color2)
            materialIndex += 1;
        else if (color == CellType.Color3)
            materialIndex += 2;

        cell.GetComponent<SpriteRenderer>().material = materials[materialIndex];
    }
}