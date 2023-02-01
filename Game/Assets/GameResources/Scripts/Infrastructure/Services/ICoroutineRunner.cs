using System.Collections;
using UnityEngine;

namespace BattleArena.Infrastructure.Services
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}

