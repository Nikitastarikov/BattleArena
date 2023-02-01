using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace BattleArena.Infrastructure.Services
{
    public class SceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;

        [Inject]
        public SceneLoader(ICoroutineRunner coroutineRunner) =>
            _coroutineRunner = coroutineRunner;

        public void Load(string name, Action onLoaded = null) =>
            _coroutineRunner.StartCoroutine(LoadScene(name, onLoaded));

        public IEnumerator LoadScene(string name, Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name.Equals(name))
            {
                onLoaded?.Invoke();
                yield break;
            }

            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(name);

            while (!waitNextScene.isDone)
                yield return null;

            onLoaded?.Invoke();
        }
    }
}
