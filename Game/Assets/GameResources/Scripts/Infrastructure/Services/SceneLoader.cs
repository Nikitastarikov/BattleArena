using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BattleArena.Infrastructure.Services
{
    public class SceneLoader
    {
        public async void LoadSceneAsync(string name, Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name.Equals(name))
            {
                onLoaded?.Invoke();
                return;
            }

            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(name);

            while (!waitNextScene.isDone)
                await Task.Yield();

            onLoaded?.Invoke();
        }
    }
}
