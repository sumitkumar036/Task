using UnityEngine;
using UnityEditor;
using UnityEditor.Build.Reporting;
using System.IO;

public class GenerateBuild
{
    [MenuItem("Build_Pipeline/BuildWithAppSigningKey")]
    public static void BuildWithAppSigningKey()
    {

        AppSigning("123456");
        Pipeline();
    }

    [MenuItem("Build_Pipeline/SimpleBuild")]
    public static void SimpleBuild()
    {
        Pipeline();
    }

    #region PIPELINE CODE
    private static void Pipeline()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[]
        {
            "Assets/Application/Scenes/Main.unity",
        };

        buildPlayerOptions.locationPathName = $"C:/Users/SUMIT KUMAR/Desktop/JENKINS/Pipeline Build/{Application.productName}/" + $"{Application.productName}.apk";
        buildPlayerOptions.target = BuildTarget.Android;
        buildPlayerOptions.options = BuildOptions.None;

        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            Debug.LogError("Build Succeeded : " + summary.totalSize + "bytes");
        }
        else
        {
            Debug.LogError("Build Failed");
        }
    }

    #endregion

    #region APP SIGNING PART
    private static void AppSigning(string password)
    {
        PlayerSettings.Android.useCustomKeystore = true;

        PlayerSettings.Android.keystoreName = $"C:/keystore/{Application.productName}.keystore";
        PlayerSettings.keystorePass = password;

        PlayerSettings.Android.keyaliasName = "hp";
        PlayerSettings.keyaliasPass = password;
    }
    #endregion
}
