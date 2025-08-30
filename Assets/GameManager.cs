using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance;
   
   public GameState State;

   private void Awake()
   {
      Instance = this;
   }

   public void UpdateGameState(GameState newState)
   {
      State = newState;

      switch (newState)
      {
         case GameState.SelectBet:
            HandleSelectBet();
            break;
         case GameState.Play:
            HandlePlayState();
            break;
         case GameState.Pause:
            HandlePauseState();
            break;
         case GameState.MainMenu:
            HandleMainMenu();
            break;
         case GameState.Victory:
            HandleVictory();
            break;
         case GameState.Defeat:
            HandleGameOver();
            break;
         default:
            throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
      }
   }

   private void HandleGameOver()
   {
      //Show game over screen and prevent player movement
      //Show total score or levels reached
   }

   private void HandleVictory()
   {
      // Show win screen and prevent player movement
      // Show total score or levels reached

   }

   private void HandleMainMenu()
   {
      //Go to the Mainmenu Scene
   }

   private void HandlePauseState()
   {
      //Prevent Player Movement
      //Show pause panel
   }

   private void HandlePlayState()
   {
      //Enable Player Movement
      //Hide all active panels
   }

   private void HandleSelectBet()
   {
      //Prevent Player Movement
      //Show Bet panel
   }
}

public enum GameState
{
   SelectBet,
   Play,
   Pause,
   MainMenu,
   Victory,
   Defeat,
}
