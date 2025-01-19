using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public int gridSize = 15; // Define the grid size (simplified to 15x15 for now)
    public GameObject tilePrefab;
    public GameObject gridParent;
    public Tile[,] grid;
    List<Pair> redPath = new List<Pair>();
    void Start()
    {
        InitializeBoard();
    }

    void InitializeBoard()
    {

        grid = new Tile[gridSize, gridSize];
        // Loop through the grid and instantiate tiles
        for (int i = 0; i < gridSize * gridSize; i++) // Total 15x15 tiles = 225 tiles
        {
            // Instantiate the tile and set its parent
            GameObject tile = Instantiate(tilePrefab, gridParent.transform);
            tile.name = $"Tile_{i}"; // Name the tile based on its index
            
            
            // Customize tile appearance based on linear index (i)
            CustomizeTile(tile, i);
        }
        
    }
    List<int> listx = new List<int> { 6, 7, 8 };
    List<int> listy = new List<int> { 6, 7, 8 };
    
    void CustomizeTile(GameObject tile, int i)
    {
        // You can assign different colors or types to tiles based on their position
        // Example: setting colors or assigning types for paths
        int x = i % gridSize;
        int y = i / gridSize;
        
        if (listx.Contains(x) && listy.Contains(y))
        {
            // Center tile (where all paths meet)
            grid[x, y] = Tile.Pass;
            tile.GetComponent<UnityEngine.UI.Image>().color = Color.gray;
        }
        else
        {
            // Assign path colors based on position (for example, red for red path)
            if ((y>=1 && y<=5 && x ==8) || (x>=9 && x<=14 && y ==6) || (x==14 && y<=8))
                tile.GetComponent<UnityEngine.UI.Image>().color = Color.red;
            else if ((y >= 6 && y <= 8 && x == 14) || (y == 8 && x <=14 && x >= 9))
                tile.GetComponent<UnityEngine.UI.Image>().color = Color.blue;
            else if ((y >= 6 && y <= 8 && x == 0) || (y == 6 && x >= 0 && x <= 5))
                tile.GetComponent<UnityEngine.UI.Image>().color = Color.green;
            else if ((x >= 6 && x <= 8 && y == 14) || (x == 6 && y <= 14 && y >= 9))
                tile.GetComponent<UnityEngine.UI.Image>().color = Color.yellow;
        }
        if((x==7 && y>=1 && y<=13 && !listy.Contains(y)) || (y ==7 && x>=1 && x<=13 && !listx.Contains(x)))
        {
            tile.GetComponent<UnityEngine.UI.Image>().color = Color.black;
        }
        if((x<=5 && y<=5) || (x>=9 && y<=5) || (x>=9 && y>=9) || (x<=5 && y>=9))
        {
            grid[x, y] = Tile.Home;
            tile.GetComponent<UnityEngine.UI.Image>().color = Color.magenta;
        }
    }
}

public class Pair
{
    int x;
    int y;
    public Pair(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}
