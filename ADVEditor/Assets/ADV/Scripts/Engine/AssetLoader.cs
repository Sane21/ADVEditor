using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace HarapekoADV
{
    public class AssetLoader
    {
        public static T Load<T>(string address)
        {
            AsyncOperationHandle<T> handle = Addressables.LoadAssetAsync<T>(address);
            handle.WaitForCompletion();
            return handle.Result;
        }
    }
}
