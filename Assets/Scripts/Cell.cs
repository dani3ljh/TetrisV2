using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a cell's state of either empty, color1, color2, or color3
/// </summary>
public enum CellColor {
    Color1,
    Color2,
    Color3
}

/// <summary>
///
/// </summary>
public class Cell : MonoBehaviour
{
    public CellColor color;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before any of the Update methods are called.
    /// </summary>
    private void Start() {
        
    }

    /// <summary>
    /// Update is called every fram, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update() {
        
    }
}
