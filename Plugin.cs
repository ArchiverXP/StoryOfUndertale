using BepInEx;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
namespace SOU
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        void Start()
        {

           
        }

        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            GameObject camera = GameObject.Find("Main Camera");
            var storyPlayer = camera.AddComponent<VideoPlayer>();
            var audioPlayer = gameObject.AddComponent<AudioSource>();
            //storyPlayer.Prepare();
            storyPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;
            storyPlayer.targetCameraAlpha = 0.5F;
            storyPlayer.source = VideoSource.Url;
            storyPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
            storyPlayer.controlledAudioTrackCount = 1;
            storyPlayer.EnableAudioTrack(0, true);
            storyPlayer.SetTargetAudioSource(0, audioPlayer);
            storyPlayer.isLooping = true;
            audioPlayer.volume = 0.5f;
            storyPlayer.url = Path.Combine(Paths.PluginPath, "StoryOfUndertale/Assets/sou.mp4");
            storyPlayer.Play();
        }
    }
}
