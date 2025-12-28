using BepInEx;
using HutongGames.PlayMaker.Actions;
using System;
using System.IO;
using UnityEngine;

namespace silkmodrecord;

// TODO - adjust the plugin guid as needed
[BepInAutoPlugin(id: "io.github.chloe.silkmodrecord")]
public partial class silkmodrecordPlugin : BaseUnityPlugin
{
    private static HeroController _hc;
    private static GameObject _refKnight;

    internal static silkmodrecordPlugin instance;

    internal static HeroController HC => _hc != null ? _hc : (_hc = HeroController.instance);
    internal static GameObject RefKnight => _refKnight != null ? _refKnight : (_refKnight = HC.gameObject);
    internal static readonly string datapath = Path.Combine(Application.persistentDataPath, "PositionRecordingData");

    internal static void Init()
    {
        var go = new GameObject("SilkModRecorder");

        UnityEngine.Object.DontDestroyOnLoad(go);

        go.AddComponent<mainrecordplugin>();
    }

    private void Awake()
    {
        Init();
        instance = this;
        if (!Directory.Exists(datapath))
        {
            Directory.CreateDirectory(datapath);
        }

        // Put your initialization logic here
        Logger.LogInfo($"Plugin {Name} ({Id}) has loaded!");
    }
    public static void Log(string message)
    {
        instance.Logger.LogInfo(message);
    }
}
