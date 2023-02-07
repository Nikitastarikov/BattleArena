using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace BattleArena.Infrastructure.Services.Assets
{
    public interface IAssets
    {
        void CleanUp();
        void Initialize();
        Task<GameObject> InstantiateAsync(string address);
        Task<GameObject> InstantiateAsync(string address, Vector3 at);
        Task<T> LoadAsync<T>(AssetReference assetReference) where T : class;
        Task<T> LoadAsync<T>(string address) where T : class;
    }
}
