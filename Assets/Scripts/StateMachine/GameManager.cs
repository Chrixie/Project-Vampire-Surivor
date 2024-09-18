using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : StateMachine
{
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        SwitchState<PlayingState>();
    }
    private void Update()
    {
        UpdateStateMachine();
    }
}
