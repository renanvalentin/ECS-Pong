using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class TickSystem : IExecuteSystem
{
    private readonly MetaContext _meta;

    public TickSystem(Contexts contexts)
    {
        _meta = contexts.meta;
    }

    public void Execute()
    {
        _meta.ReplaceDeltaTime(Time.deltaTime);
    }
}