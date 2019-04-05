using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// New
public enum CellState
{
    None,
    Friendly,
    Enemy,
    Free,
    OutOfBounds
}

public class Board : MonoBehaviour
{
    public GameObject mCellPrefab;

    [HideInInspector]
    public Cell[,] mAllCells = new Cell[8, 8];

    public void Create()
    {
        #region Create
        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                //Create Cell
                GameObject newCell = Instantiate(mCellPrefab, transform);

                //Position
                RectTransform rectTransform = newCell.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = new Vector2((x*100) + 50, (y * 100) + 50);

                //Setup
                mAllCells[x, y] = newCell.GetComponent<Cell>();
                mAllCells[x, y].Setup(new Vector2Int(x, y), this); 
            }
        }
        #endregion

        #region Color
        for (int x = 0; x < 8; x += 2)
        {
            for(int y = 0; y < 8; y++)
            {
                //Offset every other line
                int offset = (y % 2 != 0) ? 0 : 1;
                int finalX = x + offset;

                //Color
                mAllCells[finalX, y].GetComponent<Image>().color = new Color32(230, 220, 187, 255);
            }
        }
        #endregion
    }

    public CellState ValidateCell(int targetX, int targetY, BasePiece checkingPiece)
    {
        //Bound check
        if (targetX < 0 || targetX > 7)
            return CellState.OutOfBounds;

        if (targetY < 0 || targetY > 7)
            return CellState.OutOfBounds;

        Cell targetCell = mAllCells[targetX, targetY];

        if (targetCell.mCurrentPiece != null)
        {
            if (checkingPiece.mColor == targetCell.mCurrentPiece.mColor)
                return CellState.Friendly;

            if (checkingPiece.mColor != targetCell.mCurrentPiece.mColor)
                return CellState.Enemy;
        }
        return CellState.Free;
    }
}
