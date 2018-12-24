using System.Runtime.CompilerServices;
using JapaneseCrossword.Core.Rules;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

/// <summary>
/// Needs to have a border on top level and a nested base for color.
/// </summary>
public class GameBoardTile : MonoBehaviour, IMonochrome
{

    private SpriteRenderer _renderer;
    
    public float VisualWidth { get; private set; }
    public float VisualHeight { get; private set; }

    void Awake ()
    {
        SetRenderer();
        var bounds = _renderer.bounds;
        VisualWidth = bounds.size.x;
        VisualHeight = bounds.size.y;
    }

    private void SetRenderer()
    {
        var borderHolder = transform.GetChild(0);
        var baseHolder = borderHolder.GetChild(0);
        _renderer = baseHolder.GetComponent<SpriteRenderer>();
    }


    public void InvertColor()
    {
        IsFilled = !IsFilled;
        _renderer.color = IsFilled ? Color.black : Color.white;
    }

    public bool IsFilled { get; private set; }

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
            InvertColor();
    }
}
