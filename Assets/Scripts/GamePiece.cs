using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePiece : MonoBehaviour
{
    public int score;

    private int x;
	private int y;
	
	public int X 
	{
		get {
			return x;
		}
		set {
			if (IsMovable()) {
				x = value;
			}
		}
	}
	
	public int Y
	{
		get {
			return y;
		}
		set {
			if (IsMovable()) {
				y = value;
			}
		}
	}
	
	private Layer.PieceType type;
	
	public Layer.PieceType Type
	{
		get {
			return type;
		}
	}

    //Reference to our layer class
    private Layer grid;
	public Layer GridRef
	{
		get {
			return grid;
		}
	}

	void OnMouseEnter()
	{
		grid.EnterPiece(this);
	}
	
	void OnMouseDown()
	{
		grid.PressPiece(this);
	}
	
	void OnMouseUp()
	{
		grid.ReleasePiece();
	}

    //Reference to the MovablePiece script
    private MovablePiece movableComponent;
	
	public MovablePiece MovableComponent
	{
		get { return movableComponent; }
	}

    //Reference to the ColorPiece script
    private ColorPiece colorComponent;
	
	public ColorPiece ColorComponent
	{
		get { return colorComponent; }
	}

	private ClearablePiece clearableComponent;

    public ClearablePiece ClearableComponent
    {
		get { return clearableComponent; }
	}

    //Check if a gameobject have MovablePiece
    void Awake() 
	{
		movableComponent = GetComponent<MovablePiece>();
        colorComponent = GetComponent<ColorPiece>();
		clearableComponent = GetComponent<ClearablePiece>();
	}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Check if a Piece is movable
    public bool IsMovable() 
	{
		return movableComponent != null;
	}
    
    //Check if a Piece is movable
    public bool IsColored() 
	{
		return colorComponent != null;
	}
    
	//Checks if Piece can be cleared
	public bool IsClearable()
    {
        return clearableComponent != null;
    }

    //Call this function after instantiating the game pieces game object so we can initiliaze x, y, grid & type variables
    public void Init(int _x, int _y, Layer _grid, Layer.PieceType _type)
	{
		x = _x;
		y = _y;
		grid = _grid;
		type = _type;
	}
}
