using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private AnimationController animationController;
    private GamePlayController gamePlayController; // Ensure correct name casing

    private string playersChoice;

    void Awake()
    {
        animationController = GetComponent<AnimationController>();
        gamePlayController = GetComponent<GamePlayController>(); // Ensure correct name casing
    }

    public void GetChoice()
    {
        string choiceName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        
        GameChoices selectedChoice = GameChoices.NONE;

        switch (choiceName)
        {
            case "Rock":
                selectedChoice = GameChoices.ROCK;
                break;
            case "Paper":
                selectedChoice = GameChoices.PAPER;
                break;
            case "Scissors":
                selectedChoice = GameChoices.SCISSORS;
                break;
        }
        // Uncomment and implement this method in GamePlayController
        gamePlayController.SetChoices(selectedChoice);
        animationController.PlayerMadeChoice();
    }

    void Start() { }

    void Update() { }
}
