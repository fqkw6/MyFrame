
using UnityEngine;
using UnityEngine.U2D;
using System.Collections;
using AssetBundles;
public class AtlasLoader : MonoSingleton<AtlasLoader>
{

    private void OnEnable()
    {
        SpriteAtlasManager.atlasRequested += RequestAtlas;
    }


    void OnDisable()
    {
        SpriteAtlasManager.atlasRequested -= RequestAtlas;
    }

    void RequestAtlas(string tag, System.Action<SpriteAtlas> callback)
    {
        StartCoroutine(LoadAtlas(tag, callback));
    }

    /// <summary>
    /// 为了跨场景不销毁
    /// </summary>
    public void Inint()
    {

    }

    /// <summary>
    /// 加载图集依赖，用到多次不会重复加载
    /// </summary>
    /// <param name="tag"></param>
    /// <param name="callback"></param>
    /// <returns></returns>
    IEnumerator LoadAtlas(string tag, System.Action<SpriteAtlas> callback)
    {
        Debug.Log("加载图集==========");
        var loader = AssetBundleManager.Instance.LoadAssetAsync("UI/SpriteAtlas/" + tag + ".spriteatlas", typeof(UnityEngine.U2D.SpriteAtlas));
        yield return loader;
        UnityEngine.U2D.SpriteAtlas atlas = loader.asset as UnityEngine.U2D.SpriteAtlas;
        callback(atlas);
        loader.Dispose();
        yield break;
    }
}
