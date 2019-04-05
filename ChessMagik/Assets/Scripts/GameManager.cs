using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public Board mBoard;
    public PieceManager mPieceManager;

    void Start()
    {
        #region First
        //create Board
        mBoard.Create();

        mPieceManager.Setup(mBoard);
        #endregion
    }
}
