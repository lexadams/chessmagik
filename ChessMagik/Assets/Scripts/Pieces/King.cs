using UnityEngine;
using UnityEngine.UI;

public class King : BasePiece
{
    private Rook mLeftRook = null;
    private Rook mRightRook = null;

    public override void Setup(Color newTeamColor, Color32 newSpriteColor, PieceManager newPieceManager)
    {
 
    }

    public override void Kill()
    {

    }

    protected override void CheckPathing()
    {

    }

    protected override void Move()
    {

    }

    private bool CanCastle(Rook rook)
    {
        return true;
    }

    private Rook GetRook(int direction, int count)
    {
        return null;
    }
}
