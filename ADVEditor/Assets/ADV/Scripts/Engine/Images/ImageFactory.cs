using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;


namespace HarapekoADV.Images
{
    public class ImageFactory
    {

        public static ImagePresenter Create(string address, string name, ImageType type, Transform parent)
        {
            GameObject obj = null;
            ImagePresenter presenter = null;
            AsyncOperationHandle<GameObject> handle = Addressables.InstantiateAsync(ENV_CONFIG.IMG_PREFAB_ADDRESS, parent);
            handle.WaitForCompletion();
            if (handle.Status == AsyncOperationStatus.Failed)
            {
                Debugger.Err("Image Generation Error : failed creation Prefab");
                return null;
            }
            else if (handle.Status == AsyncOperationStatus.None)
            {
                Debugger.Err("Image Generation Error : not found Prefab");
                return null;
            }
            obj = handle.Result;
            Debugger.Log(obj.name);
            presenter = obj.GetComponent<ImagePresenter>();


            if (presenter == null)
            {
                Debugger.Err("Image Generation Error : not found Presenter Component");
                return null;
            }
            presenter.Initialise(address, name, type);

            return presenter;
        }

    }
}