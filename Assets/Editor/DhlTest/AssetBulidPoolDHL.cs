using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
/// <summary>
/// 1,怎么根据配置文件打包的
/// 2，怎么根据资源名加载预设的和图片的，需要提供ab名吗
/// 3，打包的压缩方式
/// 4，加载是根据ResourceWebRequester里面的api 
/// 5，每个加载都有一个加载器
/// 6，卸载的时候是怎么卸载的资源
/// </summary>
public class AssetBulidPoolDHL : Editor
{
    [MenuItem("AssetsBundle/Build AssetBundles")]
    static void BuildAllAssetBundles()//进行打包
    {
        string dir = Application.dataPath + "/.." + "/TestAssetBundles";
        //判断该目录是否存在
        if (Directory.Exists(dir) == false)
        {
            Directory.CreateDirectory(dir);//在工程下创建AssetBundles目录
        }
        string filePath = "Assets/AssetsPackage/UI/Prefabs/View/UIBoardNPC.prefab";
        AssetBundleBuild[] ss = new AssetBundleBuild[1];
        AssetBundleBuild build = new AssetBundleBuild();
        build.assetBundleName = "UIBoardNPC.ab";
        build.assetBundleVariant = string.Empty;
        build.assetNames = new string[] { filePath.Replace("\\", "/") };


        // AssetBundleBuild[] ss = new AssetBundleBuild[10];
        // AssetBundleBuild b1 = new AssetBundleBuild();
        // b1.assetBundleName = "www";
        // b1.addressableNames[0] = "";
        // // 摘要:
        // //     AssetBundle variant.
        // b1.assetBundleVariant = "ss";
        //参数一为打包到哪个路径，参数二压缩选项  参数三 平台的目标
        //只要setname 的资源都会按照设计的名字打包
        BuildPipeline.BuildAssetBundles(dir, ss, BuildAssetBundleOptions.DeterministicAssetBundle | BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.Android);
        //BuildPipeline.BuildAssetBundles(dir, BuildAssetBundleOptions.DeterministicAssetBundle | BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.Android);
    }
}
