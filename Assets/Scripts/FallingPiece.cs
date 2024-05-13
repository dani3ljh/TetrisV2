using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

/// <summary>
/// Represents the different pieces: either I, O, T, S, Z, J, or L
/// </summary>
public enum Piece
{
    I,
    O,
    T,
    S,
    Z,
    J,
    L
}

/// <summary>
/// Manages the piece as it's falling
/// </summary>
public class FallingPiece : MonoBehaviour
{
    [HideInInspector] public GameManager gm;
    [HideInInspector] public BoardManager bm;
    /* [HideInInspector] */ public Piece piece;

    [SerializeField] private GameObject background;
    [SerializeField] private Transform cellsParent;
    [SerializeField] private bool debug;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before any of the Update methods are called.
    /// </summary>
    private void Start() {
        if (!debug)
            background.SetActive(false);

        Reset();
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update() {
        
    }

    /// <summary>
    /// Resets the Falling piece at the top
    /// </summary>
    public void Reset() {
        transform.position = new Vector3(0, gm.cellSize.y * 8);

        // Remove children
        List<GameObject> children = new List<GameObject>();
        foreach (Transform child in cellsParent) children.Add(child.gameObject);
        children.ForEach(child => Destroy(child));

        // Place Cells
        foreach (Vector2Int coordinate in GetPieceCoordinates()) {
            Vector3 position = new Vector3(gm.cellSize.x * (-1.5f + coordinate.x), gm.cellSize.y * (1.5f - coordinate.y), 0);

            position += transform.position;

            GameObject cell = Instantiate(gm.cellPrefab, position, gm.cellPrefab.transform.rotation, cellsParent);

            Cell cellScript = cell.GetComponent<Cell>();

            cellScript.color = GetPieceColor();

            bm.SetMaterial(cellScript);
        }
    }

    /// <summary>
    /// Uses FallingPiece.piece to find the 4 coordinates to the tetromino
    /// <returns>A vector2int array with length 4, (0, 0) corresponds to top left</returns>
    /// </summary>
    private Vector2Int[] GetPieceCoordinates() {
        switch (piece) {
            case Piece.I:
                return new Vector2Int[] {
                    new(0, 1),
                    new(1, 1),
                    new(2, 1),
                    new(3, 1)
                };
            case Piece.J:
                return new Vector2Int[] {
                    new(0, 0),
                    new(0, 1),
                    new(1, 1),
                    new(2, 1)
                };
            case Piece.L:
                return new Vector2Int[] {
                    new(0, 1),
                    new(1, 1),
                    new(2, 1),
                    new(2, 0),
                };
            case Piece.O:
                return new Vector2Int[] {
                    new(1, 1),
                    new(2, 1),
                    new(1, 2),
                    new(2, 2)
                };
            case Piece.S:
                return new Vector2Int[] {
                    new(0, 1),
                    new(1, 1),
                    new(1, 0),
                    new(2, 0)
                };
            case Piece.T:
                return new Vector2Int[] {
                    new(1, 0),
                    new(0, 1),
                    new(1, 1),
                    new(2, 1),
                };
            case Piece.Z:
                return new Vector2Int[] {
                    new(0, 0),
                    new(1, 0),
                    new(1, 1),
                    new(2, 1),
                };
            default:
                return new Vector2Int[0];
        }
    }

    /// <summary>
    /// Uses FallingPiece.piece to find the color of the tetromino
    /// <returns>The CellColor of the tetromino</returns>
    /// </summary>
    private CellColor GetPieceColor() {
        switch (piece) {
            case Piece.I:
                return CellColor.Color1;
            case Piece.O:
                return CellColor.Color1;
            case Piece.T:
                return CellColor.Color1;
            case Piece.S:
                return CellColor.Color3;
            case Piece.Z:
                return CellColor.Color2;
            case Piece.J:
                return CellColor.Color3;
            case Piece.L:
                return CellColor.Color2;
            default:
                return CellColor.Color1;
        }
    }
} 
