using UnityEngine;
using UnityEngine.UI;

public class Pawn : BasePiece
{
    public override void Setup(Color newTeamColor, Color32 newSpriteColor, PieceManager newPieceManager)
    {
  
    }

    protected override void Move()
    {
  
    }

    private bool MatchesState(int targetX, int targetY, CellState targetState)
    {    
        return false;
    }

    private void CheckForPromotion()
    {
   
    }

    protected override void CheckPathing()
    {
    
    }
}
