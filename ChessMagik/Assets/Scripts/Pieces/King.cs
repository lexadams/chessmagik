using UnityEngine;
using UnityEngine.UI;

public class King : BasePiece
{
    private Rook mLeftRook = null;
    private Rook mRightRook = null;

    public override void Setup(Color newTeamColor, Color32 newSpriteColor, PieceManager newPieceManager)
    {
        base.Setup(newTeamColor, newSpriteColor, newPieceManager);

        mMovement = new Vector3Int(1, 1, 1);
        GetComponent<Image>().sprite = Resources.Load<Sprite>("king_light");
    }

    public override void Kill()
    {
        Reset();
        mIsFirstMove = true;
    }

    protected override void CheckPathing()
    {
        base.CheckPathing();

        //right rook
        mRightRook = GetRook(1, 3);
        //left rook
        mLeftRook = GetRook(-1, 4);
    }

    protected override void Move()
    {
        base.Move();

        if (CanCastle(mLeftRook))
            mLeftRook.Castle();

        if (CanCastle(mRightRook))
            mRightRook.Castle();
    }

    private bool CanCastle(Rook rook)
    {
        if (rook == null)
            return false;

        if (rook.mCastleTriggerCell != mCurrentCell)
            return false;

        return true;
    }

    private Rook GetRook(int direction, int count)
    {
        //has king moved?
        if (!mIsFirstMove)
            return null;

        int currentX = mCurrentCell.mBoardPosition.x;
        int currentY = mCurrentCell.mBoardPosition.y;
        //position

        //check cells
        for(int i =1; i < count; i++)
        {
            int offsetX = currentX + (i * direction);
            CellState cellState = mCurrentCell.mBoard.ValidateCell(offsetX, currentY, this);

            if (cellState != CellState.Free)
                return null;
        }
        //get rook
        Cell rookCell = mCurrentCell.mBoard.mAllCells[currentX + (count * direction), currentY];
        Rook rook = null;

        //cast
        if (rookCell.mCurrentPiece != null)
        {
            if (rookCell.mCurrentPiece is Rook)
                rook = (Rook)rookCell.mCurrentPiece;
        }
        //return if no rook
        if (rook == null)
            return null;
        //check color/movement
        if(rook.mColor != mColor || !rook.mIsFirstMove)
            return null;
        //add castle trigger

        mHighlightedCells.Add(rook.mCastleTriggerCell);

        return rook;
    }
}
