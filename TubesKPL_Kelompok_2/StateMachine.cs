using System;
using System.Collections.Generic;

public enum State
{
    STORE,
    DETAIL,
    CART,
    LIBRARY
}

public enum Input
{
    VIEW_DETAIL,
    ADD_TO_CART,
    BUY_DIRECT,
    BUY_CART,
    REFUND,
    BACK
}

public class StateMachine
{
    public State CurrentState { get; private set; }
    private Dictionary<(State, Input), State> table;

    public StateMachine(State startState, Dictionary<(State, Input), State> table)
    {
        CurrentState = startState;
        this.table = table;
    }

    public void Send(Input input)
    {
        var key = (CurrentState, input);

        if (table.ContainsKey(key))
        {
            CurrentState = table[key];
            Console.WriteLine($"Berpindah ke state: {CurrentState}");
        }
        else
        {
            Console.WriteLine("Aksi tidak valid di state ini");
        }
    }
}