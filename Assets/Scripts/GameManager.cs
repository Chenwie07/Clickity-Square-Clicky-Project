using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField, Tooltip("List of all Levels Making the Game")]
    List<LevelData> levels = new List<LevelData>();

    [SerializeField] IntGameEvent @OnTimeChange; 
    [SerializeField] LevelGameEvent @OnLevelChange;
    [SerializeField] GameEvent @onTimeEnded; 

    [SerializeField] GameObject background; 

    private LevelData currentLevel;

    private void Start()
    {
        // load level 1 I guess. 
        currentLevel = levels[0];
        OnLevelChange.Occurred(currentLevel);
        StartCoroutine(Timer(currentLevel.LevelTime));
    }

    IEnumerator Timer(int maxTime)
    {
        print("Timer started, new max time: " + maxTime); 
        int timer = 0;
        while (timer < maxTime /* && (GameOver || LevelComplete) */ )
        {
            yield return new WaitForSeconds(1);
            timer++;
            OnTimeChange.Occurred(timer); 
        }
        onTimeEnded.Occurred(); 
        yield return null;
    }

    public void LevelWon()
    {
        StopAllCoroutines(); 
        currentLevel = levels[currentLevel.Level]; // go to next level, our level numbering starts at 1, not 0. 
        OnLevelChange.Occurred(currentLevel); 
    }
    public void BeginBattle()
    {
        StartCoroutine(Timer(currentLevel.LevelTime)); 
    }

    public void ChangeBG()
    {
        background.GetComponent<SpriteRenderer>().sprite = currentLevel.Background; 
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0); 
    }
}
