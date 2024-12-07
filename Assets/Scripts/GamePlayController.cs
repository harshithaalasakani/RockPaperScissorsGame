using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum GameChoices
{
    NONE,
    ROCK,
    PAPER,
    SCISSORS
}

public class GamePlayController : MonoBehaviour
{
    [SerializeField]
    private Sprite rock_Sprite, paper_Sprite, scissors_Sprite;

    [SerializeField]
    private Image playerChoice_Img, opponentChoice_Img;

    [SerializeField]
    private TextMeshProUGUI infoText;

    private GameChoices player_Choice = GameChoices.NONE, opponent_Choice = GameChoices.NONE;
    private AnimationController animationController;

    void Awake()
    {
        animationController = GetComponent<AnimationController>();
    }

    public void SetChoices(GameChoices gameChoices)
    {
        switch (gameChoices)
        {
            case GameChoices.ROCK:
                playerChoice_Img.sprite = rock_Sprite;  // Corrected: set sprite property
                player_Choice = GameChoices.ROCK;
                break;
            case GameChoices.PAPER:
                playerChoice_Img.sprite = paper_Sprite;  // Corrected: set sprite property
                player_Choice = GameChoices.PAPER;
                break;
            case GameChoices.SCISSORS:
                playerChoice_Img.sprite = scissors_Sprite;  // Corrected: set sprite property
                player_Choice = GameChoices.SCISSORS;
                break;
        }
        SetOpponentChoice();
        DetermineWinner();
    }

    void SetOpponentChoice()
    {
        int rnd = Random.Range(0, 3);
        switch (rnd)
        {
            case 0:
                opponent_Choice = GameChoices.ROCK;
                opponentChoice_Img.sprite = rock_Sprite;  // Corrected: set sprite property
                break;
            case 1:
                opponent_Choice = GameChoices.PAPER;
                opponentChoice_Img.sprite = paper_Sprite;  // Corrected: set sprite property
                break;
            case 2:
                opponent_Choice = GameChoices.SCISSORS;
                opponentChoice_Img.sprite = scissors_Sprite;  // Corrected: set sprite property
                break;
        }
    }

    void DetermineWinner()
    {
        // Ensure the infoText is enabled before updating it
        infoText.gameObject.SetActive(true);

        // Determine the result and update the text accordingly
        if (player_Choice == opponent_Choice)
        {
            infoText.text = "It's a Draw!";
        }
        else if (player_Choice == GameChoices.PAPER && opponent_Choice == GameChoices.ROCK)
        {
            infoText.text = "YOU WIN!!!";
        }
        else if (opponent_Choice == GameChoices.PAPER && player_Choice == GameChoices.ROCK)
        {
            infoText.text = "YOU LOSE!!";
        }
        else if (player_Choice == GameChoices.ROCK && opponent_Choice == GameChoices.SCISSORS)
        {
            infoText.text = "YOU WIN!!!";
        }
        else if (opponent_Choice == GameChoices.ROCK && player_Choice == GameChoices.SCISSORS)
        {
            infoText.text = "YOU LOSE!!";
        }
        else if (player_Choice == GameChoices.SCISSORS && opponent_Choice == GameChoices.PAPER)
        {
            infoText.text = "YOU WIN!!!";
        }
        else if (opponent_Choice == GameChoices.SCISSORS && player_Choice == GameChoices.ROCK)
        {
            infoText.text = "YOU LOSE!!";
        }

        // Optionally, force a layout/UI refresh if needed (especially for text components)
        Canvas.ForceUpdateCanvases();

        // Start the coroutine to display text and restart the game
        StartCoroutine(DisplayWinnerAndRestart());
    }

    IEnumerator DisplayWinnerAndRestart()
    {
        yield return new WaitForSeconds(2f);

        infoText.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);

        infoText.gameObject.SetActive(false);

        animationController.ResetAnimations();
    }
}
