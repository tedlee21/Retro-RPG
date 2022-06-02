using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState { FreeRoam, Dialogue, Menu}

public class GameController : MonoBehaviour
{

    [SerializeField] BasicMovement playerController;
    GameState state;

    private void Start()
    {
        DialogueManager.Instance.OnShowDialogue += () =>
        {
            state = GameState.Dialogue;
        };

        DialogueManager.Instance.OnCloseDialogue += () =>
        {
            if (state == GameState.Dialogue)
            {
                state = GameState.FreeRoam;
            }
            
        };
    }


    private void Update()
    {
        if (state == GameState.FreeRoam)
        {
            playerController.HandleUpdate();
        }
        else if (state == GameState.Dialogue )
        {
            DialogueManager.Instance.HandleUpdate();
        }
    }
    

    
}