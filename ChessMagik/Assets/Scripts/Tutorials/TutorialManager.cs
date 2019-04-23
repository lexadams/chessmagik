using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{

    public List<Tutorial> Tutorials = new List<Tutorial>();

    public Text explanationTxt;
    private bool tutorialsComplete = false;
    private static TutorialManager instance;
    public static TutorialManager Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<TutorialManager>();

            if (instance == null)
                Debug.Log("There is no tutorialmanager");

            return instance;


        }

    }

    private Tutorial currentTutorial;

    // Start is called before the first frame update
    void Start()
    {
        SetNextTutorial(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTutorial)
            currentTutorial.CheckIfHappening();
        if (tutorialsComplete)
        {
            if (Input.GetKeyDown("a"))
                SceneManager.LoadScene("mainMenu");
        }
    }

    public void CompletedTutorial()
    {
        SetNextTutorial(currentTutorial.Order + 1);
    }

    public void SetNextTutorial(int currentOrder)
    {
        currentTutorial = GetTutorialByOrder(currentOrder);

        if (!currentTutorial)
        {
            CompletedAllTutorials();
            return;
        }

        explanationTxt.text = currentTutorial.Explanation;
    }

    public void CompletedAllTutorials()
    {
        explanationTxt.text = "You Completed all the Tutorials, press \"a\" to return home";
        tutorialsComplete = true;
        
        
        
    }

    public Tutorial GetTutorialByOrder(int Order)
    {
        for (int i = 0; i < Tutorials.Count; i++)
        {
            if (Tutorials[i].Order == Order)
                return Tutorials[i];
        }

        return null;
    }
}
