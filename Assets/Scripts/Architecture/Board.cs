using System.Collections.Generic;
using UnityEngine;

namespace Architecture
{
    public class Board : MonoBehaviour
    {
        [SerializeField] int width = 10;
        [SerializeField] int height = 10;
        [SerializeField] private Cell cellPrefab;

        private Cell[,] cells;

        void Awake()
        {
            cells = new Cell[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    cells[x, y] = Instantiate(cellPrefab);
                    cells[x, y].SetPositionCell(new Vector2(x,y));
                }
            }
        }
    }
}