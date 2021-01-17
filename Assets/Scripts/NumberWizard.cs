using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour
{
    private int guess;

    [SerializeField] private int min;
    [SerializeField] private int max;
    [SerializeField] private Text guessTextComponent;

    private List<int> alreadyGuessedNumber;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        max++;

        guess                   = Random.Range(min, max);
        guessTextComponent.text = guess.ToString();

        alreadyGuessedNumber = new List<int>
        {
            guess
        };
    }

    public void OnClickHigher()
    {
        GetNewGuess(min = guess, max);
    }

    public void OnClickLower()
    {
        GetNewGuess(min, max = guess);
    }

    private void GetNewGuess(int min, int max)
    {
        GetNotRepeatedGuess();
        AddGuessToList();
        guessTextComponent.text = guess.ToString();
    }

    private void GetNotRepeatedGuess()
    {
        guess = Random.Range(min, max);
        while (alreadyGuessedNumber.Contains(guess) && guess != max)
        {
            guess = Random.Range(min, max);
            Debug.Log(guess);
        }
    }

    private void AddGuessToList()
    {
        if (!alreadyGuessedNumber.Contains(guess))
        {
            alreadyGuessedNumber.Add(guess);
        }
    }
}
