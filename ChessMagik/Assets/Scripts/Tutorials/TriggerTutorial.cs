using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTutorial : Tutorial
{
    private bool isCurrentTutorial = false;

    

    

    public override void CheckIfHappening()
    {
        if (Input.GetMouseButtonUp(0))
        {
            TutorialManager.Instance.CompletedTutorial();
            isCurrentTutorial = false;
        }

    }

   
    /*public void OnTriggerEnter(Collider other)
    {
        if (!isCurrentTutorial)
            return;

        if (isMoved)
        {
            TutorialManager.Instance.CompletedTutorial();
            isCurrentTutorial = false;
        }
    }
    */
}
