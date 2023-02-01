using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace BattleArena.Infrastructure.Services.Assets
{
    public interface IAssets
    {
        void CleanUp();
        void Initialize();
        Task<GameObject> Instantiate(string address);
        Task<GameObject> Instantiate(string address, Vector3 at);
        Task<T> Load<T>(AssetReference assetReference) where T : class;
        Task<T> Load<T>(string address) where T : class;
    }
}
