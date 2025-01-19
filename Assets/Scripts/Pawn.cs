using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Pawn 
{
    public GameObject go;
    public Vector2Int startPos;
    public PawnType pawnType;
    public bool pawnLock;
    public int pawnSteps;
    public bool pawnPlay;
    public Vector2Int currentPos;
    public Pawn(GameObject pawn,Vector2Int index,PawnType color,bool pawnlock)
    {
        this.go = pawn;
        this.startPos = index;
        this.pawnLock = pawnlock;
        this.pawnType = color;
        this.pawnSteps = 0;
        this.pawnPlay = false;
        go.AddComponent<Button>().onClick.AddListener(() => {
           
            if (this.pawnLock)
                UnlockPawn();
            else
                movePawn();
        });

    }
    public void movePawn() {
        if (!this.pawnPlay)
        {
            Debug.Log("paw play value is false for type " + this.pawnType);
            return;
        }
        int step = BoardManager.instance.diceValue;
        
        Debug.Log("move pawn to " + pawnSteps);
        List<Vector2Int> ls = new List<Vector2Int>() ;
        if (this.pawnType == PawnType.Red)
            ls = BoardManager.instance.RedPath;
        if (this.pawnType == PawnType.Blue)
            ls = BoardManager.instance.BluePath;
        if (this.pawnType == PawnType.Yellow)
            ls = new List<Vector2Int>(BoardManager.instance.YellowPath);
        if (this.pawnType == PawnType.Green)
            ls = new List<Vector2Int>(BoardManager.instance.GreenPath);
        Debug.Log(ls.Count+" path list count");
        if (pawnSteps+step < ls.Count)
        {
            pawnSteps += step;
            Vector2Int ind = ls[pawnSteps];
            Debug.Log("move pawn to " + ind);
            go.transform.position = BoardManager.instance.grid[ind.x, ind.y].tile.transform.position;
            this.currentPos = new Vector2Int(ind.x, ind.y);
            BoardManager.instance.deletePawn(this.pawnType, this.currentPos);
        }
        this.pawnPlay = false;

    }
    public void UnlockPawn()
    {
        int value = BoardManager.instance.diceValue;
        if (value == 6 && this.pawnPlay)
        {
            Debug.Log(this.pawnType + " pawn type");
            go.transform.position = BoardManager.instance.grid[startPos.x, startPos.y].tile.transform.position;
            this.currentPos = new Vector2Int(startPos.x, startPos.y);
            this.pawnLock = false;
        }
        
        this.pawnPlay = false;
    }


}
