﻿using UnityEngine;
using UnityEngine.UI;

public class Knight : BasePiece
{
    public override void Setup(Color newTeamColor, Color32 newSpriteColor, PieceManager newPieceManager)
    {
        base.Setup(newTeamColor, newSpriteColor, newPieceManager);

        GetComponent<Image>().sprite = Resources.Load<Sprite>("knight_light");
  
    }

    private void CreateCellPath(int flipper)
    {
        int currentX = mCurrentCell.mBoardPosition.x;
        int currentY = mCurrentCell.mBoardPosition.y;

        //left
        MatchesState(currentX - 2, currentY + (1 * flipper));
        //upper left
        MatchesState(currentX - 1, currentY + (2 * flipper));

        //upper right
        MatchesState(currentX + 1, currentY + (2 * flipper));

        //right
        MatchesState(currentX + 2, currentY + (1 * flipper));
    }

    protected override void CheckPathing()
    {
        //draw top half
        CreateCellPath(1);

        //draw bottom half
        CreateCellPath(-1);
    }

    private void MatchesState(int targetX, int targetY)
    {
        CellState cellState = CellState.None;
        cellState = mCurrentCell.mBoard.ValidateCell(targetX, targetY, this);

        if (cellState != CellState.Friendly && cellState != CellState.OutOfBounds)
            mHighlightedCells.Add(mCurrentCell.mBoard.mAllCells[targetX, targetY]);
    }
}
