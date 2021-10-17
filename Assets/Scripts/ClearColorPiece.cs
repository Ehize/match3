using System.Collections;
using UnityEngine;

public class ClearColorPiece : ClearablePiece
{
    private ColorPiece.ColorType color;

    public ColorPiece.ColorType Color
    {
        get => color;
        set => color = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Clear()
    {
        base.Clear();

        piece.GridRef.ClearColor(color);
    }
}
