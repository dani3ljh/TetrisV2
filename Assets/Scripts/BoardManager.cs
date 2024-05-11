using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the state of the board
/// </summary>
public class BoardManager : MonoBehaviour
{
    [SerializeField] private Transform cellsParent;
    [SerializeField] private GameObject cellPrefab;
    [SerializeField] private Material[] materials;

    [HideInInspector] public GameManager gm;

    #nullable enable
    private Cell?[,] cells = new Cell?[10, 20];

    /// <summary>
    /// Start is called on the frame when a script is enabled just before any of the Update methods are called
    /// </summary>
    private void Start() {

    }

    /// <summary>
    /// Update is called every fram, if the MonoBehaviour is enabled
    /// </summary>
    private void Update() {
        
    }

    public void PlaceCell(int x, int y, CellColor? color) {
        Cell? oldCellScript = cells[x, y];

        // remove extra cell if it exists
        if (oldCellScript != null)
            Destroy(oldCellScript.gameObject);

        if (color == null)
            return;

        Vector3 cellSize = cellPrefab.GetComponent<SpriteRenderer>().bounds.size;

        // 4.5 cellsWidth left plus x cellsWidth right then factor out cellsWidth, do same for y
        Vector3 position = new Vector3(cellSize.x * (-4.5f + x), cellSize.y * (9.5f - y), 0);
        
        GameObject cell = Instantiate(cellPrefab, position, cellPrefab.transform.rotation, cellsParent);

        Cell cellScript = cell.GetComponent<Cell>();

        cells[x, y] = cellScript;
        cellScript.color = color ?? CellColor.Color1;

        SetMaterial(cellScript);

        cell.name = $"Cell ({x}, {y})";
    }

    public void UpdateCellsLevel() {
        for (int x = 0; x > 10; x++) {
            for (int y = 0; y > 20; y++) {
                Cell? cellScript = cells[x, y];

                if (cellScript == null)
                    continue;

                SetMaterial(cellScript);
            }
        }
    }

    private void SetMaterial(Cell cellScript) {
        int materialIndex = 3 * gm.level;

        if (cellScript.color == CellColor.Color2)
            materialIndex += 1;
        else if (cellScript.color == CellColor.Color3)
            materialIndex += 2;
                
        cellScript.gameObject.GetComponent<SpriteRenderer>().material = materials[materialIndex];
    }
}