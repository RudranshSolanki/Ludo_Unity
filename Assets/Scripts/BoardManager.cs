using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardManager : MonoBehaviour
{
    public int gridSize = 15; // Define the grid size (simplified to 15x15 for now)
    public GameObject tilePrefab;
    public GameObject gridParent;
    public Tile[,] grid;
    public GameObject redPawn;
    public GameObject bluePawn;
    public static BoardManager instance;
    public List<Vector2Int> RedPath = new List<Vector2Int>();
    public List<Vector2Int> BluePath = new List<Vector2Int>();
    public List<Vector2Int> GreenPath = new List<Vector2Int>();
    public List<Vector2Int> YellowPath = new List<Vector2Int>();
    public List<Vector2Int> redHomePos = new List<Vector2Int>();
    public List<Vector2Int> blueHomePos = new List<Vector2Int>();
    public List<Pawn> redPawns = new List<Pawn>();
    public List<Pawn> bluePawns = new List<Pawn>();
    public Transform pawnParent;
    Pawn rp1;
    Pawn bp1;
    void Start()
    {
        InitializeBoard();
        
        instance = this;
    }

    void InitializeBoard()
    {

        grid = new Tile[gridSize, gridSize];
        // Loop through the grid and instantiate tiles
        for(int i = 0; i < 15; i++)
        {
            for(int j = 0;j<15; j++)
            {
                
                GameObject go = Instantiate(tilePrefab, gridParent.transform);
                go.name = "Tile_" + i + "_" + j;
                CustomizeTile(i, j, go);
            }
        }
        redPath();
        bluePath();
        

    }
    public void redPath() {

        redHomePos.Add(new Vector2Int(440, 568));
        redHomePos.Add(new Vector2Int(689, 563));
        redHomePos.Add(new Vector2Int(565, 688));
        redHomePos.Add(new Vector2Int(565, 445));
        for(int i = 0; i < redHomePos.Count; i++)
        {
            GameObject go = Instantiate(redPawn, pawnParent);
            go.name = "REDPAWN" + (i + 1);
            go.GetComponent<RectTransform>().anchoredPosition = redHomePos[i];
            Pawn rp = new Pawn(go,redHomePos[i], new Vector2Int(8, 1), PawnType.Red, true);
            redPawns.Add(rp);
        }
        // Start at (8, 1) and move upwards
        RedPath.Add(new Vector2Int(8, 1));
        RedPath.Add(new Vector2Int(8, 2));
        RedPath.Add(new Vector2Int(8, 3));
        RedPath.Add(new Vector2Int(8, 4));
        RedPath.Add(new Vector2Int(8, 5));

        // Turn right to (9, 6) and continue the path
        RedPath.Add(new Vector2Int(9, 6));
        RedPath.Add(new Vector2Int(10, 6));
        RedPath.Add(new Vector2Int(11, 6));
        RedPath.Add(new Vector2Int(12, 6));
        RedPath.Add(new Vector2Int(13, 6));
        RedPath.Add(new Vector2Int(14, 6));

        // Move upwards along the right edge
        RedPath.Add(new Vector2Int(14, 7));
        RedPath.Add(new Vector2Int(14, 8));
        RedPath.Add(new Vector2Int(13, 8));
        RedPath.Add(new Vector2Int(12, 8));
        RedPath.Add(new Vector2Int(11, 8));
        RedPath.Add(new Vector2Int(10, 8));
        RedPath.Add(new Vector2Int(9, 8));

        // move down
        RedPath.Add(new Vector2Int(8, 9));
        RedPath.Add(new Vector2Int(8, 10));
        RedPath.Add(new Vector2Int(8, 11));
        RedPath.Add(new Vector2Int(8, 12));
        RedPath.Add(new Vector2Int(8, 13));
        RedPath.Add(new Vector2Int(8, 14));
        RedPath.Add(new Vector2Int(7, 14));
        RedPath.Add(new Vector2Int(6, 14));


        //move up

        RedPath.Add(new Vector2Int(6, 13));
        RedPath.Add(new Vector2Int(6, 12));
        RedPath.Add(new Vector2Int(6, 11));
        RedPath.Add(new Vector2Int(6, 10));
        RedPath.Add(new Vector2Int(6, 9));


        // Move left along the top edge
        RedPath.Add(new Vector2Int(5, 8));
        RedPath.Add(new Vector2Int(4, 8));
        RedPath.Add(new Vector2Int(3, 8));
        RedPath.Add(new Vector2Int(2, 8));
        RedPath.Add(new Vector2Int(1, 8));
        RedPath.Add(new Vector2Int(0, 8));

        //move upward
        RedPath.Add(new Vector2Int(0, 7));
        RedPath.Add(new Vector2Int(0, 6));

        // Move downward on the left edge
        RedPath.Add(new Vector2Int(1, 6));
        RedPath.Add(new Vector2Int(2, 6));
        RedPath.Add(new Vector2Int(3, 6));
        RedPath.Add(new Vector2Int(4, 6));
        RedPath.Add(new Vector2Int(5, 6));

        //move up
        RedPath.Add(new Vector2Int(6, 5));
        RedPath.Add(new Vector2Int(6, 4));
        RedPath.Add(new Vector2Int(6, 3));
        RedPath.Add(new Vector2Int(6, 2));
        RedPath.Add(new Vector2Int(6, 1));
        RedPath.Add(new Vector2Int(6, 0));
        RedPath.Add(new Vector2Int(7, 0));


        //color area
        RedPath.Add(new Vector2Int(7, 1));
        RedPath.Add(new Vector2Int(7, 2));
        RedPath.Add(new Vector2Int(7, 3));
        RedPath.Add(new Vector2Int(7, 4));
        RedPath.Add(new Vector2Int(7, 5));
        RedPath.Add(new Vector2Int(7, 6));
    }
    public void bluePath()
    {
        blueHomePos.Add(new Vector2Int(440, -566));
        blueHomePos.Add(new Vector2Int(567, -437));
        blueHomePos.Add(new Vector2Int(692, -564));
        blueHomePos.Add(new Vector2Int(568, -691));
        for (int i = 0; i < blueHomePos.Count; i++)
        {
            GameObject go = Instantiate(bluePawn, pawnParent);
            go.name = "BLUEPAWN" + (i + 1);
            go.GetComponent<RectTransform>().anchoredPosition = blueHomePos[i];
            Pawn bp = new Pawn(go,blueHomePos[i], new Vector2Int(13, 8), PawnType.Blue, true);
            bluePawns.Add(bp);
        }

        //start position
        BluePath.Add(new Vector2Int(13, 8));
        BluePath.Add(new Vector2Int(12, 8));
        BluePath.Add(new Vector2Int(11, 8));
        BluePath.Add(new Vector2Int(10, 8));
        BluePath.Add(new Vector2Int(9, 8));

        // move down
        BluePath.Add(new Vector2Int(8, 9));
        BluePath.Add(new Vector2Int(8, 10));
        BluePath.Add(new Vector2Int(8, 11));
        BluePath.Add(new Vector2Int(8, 12));
        BluePath.Add(new Vector2Int(8, 13));
        BluePath.Add(new Vector2Int(8, 14));
        BluePath.Add(new Vector2Int(7, 14));
        BluePath.Add(new Vector2Int(6, 14));


        //move up

        BluePath.Add(new Vector2Int(6, 13));
        BluePath.Add(new Vector2Int(6, 12));
        BluePath.Add(new Vector2Int(6, 11));
        BluePath.Add(new Vector2Int(6, 10));
        BluePath.Add(new Vector2Int(6, 9));


        // Move left along the top edge
        BluePath.Add(new Vector2Int(5, 8));
        BluePath.Add(new Vector2Int(4, 8));
        BluePath.Add(new Vector2Int(3, 8));
        BluePath.Add(new Vector2Int(2, 8));
        BluePath.Add(new Vector2Int(1, 8));
        BluePath.Add(new Vector2Int(0, 8));

        //move upward
        BluePath.Add(new Vector2Int(0, 7));
        BluePath.Add(new Vector2Int(0, 6));

        // Move downward on the left edge
        BluePath.Add(new Vector2Int(1, 6));
        BluePath.Add(new Vector2Int(2, 6));
        BluePath.Add(new Vector2Int(3, 6));
        BluePath.Add(new Vector2Int(4, 6));
        BluePath.Add(new Vector2Int(5, 6));

        //move up
        BluePath.Add(new Vector2Int(6, 5));
        BluePath.Add(new Vector2Int(6, 4));
        BluePath.Add(new Vector2Int(6, 3));
        BluePath.Add(new Vector2Int(6, 2));
        BluePath.Add(new Vector2Int(6, 1));
        BluePath.Add(new Vector2Int(6, 0));
        BluePath.Add(new Vector2Int(7, 0));


        BluePath.Add(new Vector2Int(8, 0));

        BluePath.Add(new Vector2Int(8, 1));
        BluePath.Add(new Vector2Int(8, 2));
        BluePath.Add(new Vector2Int(8, 3));
        BluePath.Add(new Vector2Int(8, 4));
        BluePath.Add(new Vector2Int(8, 5));

        // Turn right to (9, 6) and continue the path
        BluePath.Add(new Vector2Int(9, 6));
        BluePath.Add(new Vector2Int(10, 6));
        BluePath.Add(new Vector2Int(11, 6));
        BluePath.Add(new Vector2Int(12, 6));
        BluePath.Add(new Vector2Int(13, 6));
        BluePath.Add(new Vector2Int(14, 6));

        // Move upwards along the right edge
        BluePath.Add(new Vector2Int(14, 7));


        //color area
        BluePath.Add(new Vector2Int(13, 7));
        BluePath.Add(new Vector2Int(12, 7));
        BluePath.Add(new Vector2Int(11, 7));
        BluePath.Add(new Vector2Int(10, 7));
        BluePath.Add(new Vector2Int(9, 7));
        BluePath.Add(new Vector2Int(8, 7));

    }

    public void greenPath()
    {

    }
    public void yellowPath()
    {

    }
    List<int> listx = new List<int> { 6, 7, 8 };
    List<int> listy = new List<int> { 6, 7, 8 };
    
    
    public int diceValue = 1;
    int count = 0;
    public void diceRoll()
    {
        int randomNumber = Random.Range(1, 7);
        Debug.Log("Dice Number "+randomNumber);
        diceValue = randomNumber;
        if (count % 2 == 0)
        {
            Debug.Log("red chance");
            for(int i = 0; i < 4; i++) {
                redPawns[i].pawnPlay = true;
                bluePawns[i].pawnPlay = false;
            }

            
        }
        else
        {
            Debug.Log("blue chance");
            for (int i = 0; i < 4; i++)
            {
                redPawns[i].pawnPlay = false;
                bluePawns[i].pawnPlay = true;
            }
            
        }
        count++;
    }

    void CustomizeTile(int y, int x, GameObject tile)
    {
        // You can assign different colors or types to tiles based on their position
        // Example: setting colors or assigning types for paths
        grid[x, y] = new Tile();
        grid[x, y].tile = tile;
        if (listx.Contains(x) && listy.Contains(y))
        {
            // Center tile (where all paths meet)
            //tile.GetComponent<UnityEngine.UI.Image>().color = Color.gray;
            grid[x, y].tile = tile;
            grid[x, y].type = TileType.Pass;

        }
        else
        {

        }
        if ((x == 7 && y >= 1 && y <= 13 && !listy.Contains(y)) || (y == 7 && x >= 1 && x <= 13 && !listx.Contains(x)))
        {
            //tile.GetComponent<UnityEngine.UI.Image>().color = Color.black;
            grid[x, y].tile = tile;
            grid[x, y].type = TileType.ColorArea;
        }
        if ((x <= 5 && y <= 5) || (x >= 9 && y <= 5) || (x >= 9 && y >= 9) || (x <= 5 && y >= 9))
        {

            //tile.GetComponent<UnityEngine.UI.Image>().color = Color.magenta;
            grid[x, y].tile = tile;
            grid[x, y].type = TileType.Home;
        }
    }

    public void deletePawn(PawnType currentType, Vector2Int destPost)
    {
        Debug.Log("checking for deleteingffd");
        if (currentType == PawnType.Blue)
        {
            for(int i =0;i<redPawns.Count;i++)
            {
                if (redPawns[i].currentPos.x == destPost.x && redPawns[i].currentPos.y == destPost.y)
                {
                    redPawns[i].go.GetComponent<RectTransform>().anchoredPosition = redPawns[i].blockPosition;
                    redPawns[i].pawnLock = true;
                    redPawns[i].pawnSteps = 0;
                    redPawns[i].pawnPlay = false;
                }
            }
        }
        else
        {
            for (int i = 0; i < bluePawns.Count; i++)
            {
                if (bluePawns[i].currentPos.x == destPost.x && bluePawns[i].currentPos.y == destPost.y)
                {
                    bluePawns[i].go.GetComponent<RectTransform>().anchoredPosition = bluePawns[i].blockPosition;
                    bluePawns[i].pawnLock = true;
                    bluePawns[i].pawnSteps = 0;
                    bluePawns[i].pawnPlay = false;
                }
            }
        }
    }

   

}


public class Tile
{
    public GameObject tile;
    public TileType type;
}
public class TwoPawnChance
{
    public bool redChance;
    public bool blueChance;
}
