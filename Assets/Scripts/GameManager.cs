using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

/// <summary>
/// Manages the entire game
/// </summary>
public class GameManager : MonoBehaviour
{
    public int level;
    public GameObject cellPrefab;

    [HideInInspector] public Vector3 cellSize;

    [SerializeField] private FallingPiece fp;

    private BoardManager bm;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before any of the Update methods are called.
    /// </summary>
    private void Start() {
        bm = GetComponent<BoardManager>();
        // gm runs first so set bm.gm
        bm.gm = this;
        fp.gm = this;
        fp.bm = bm;

        cellSize = cellPrefab.GetComponent<SpriteRenderer>().bounds.size;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update() {
        
    }
}
