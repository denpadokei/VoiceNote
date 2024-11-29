using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Settings;
using BeatSaberMarkupLanguage.ViewControllers;
using System.Collections.Generic;
using UnityEngine;
using VoiceNote.Configuration;
using Zenject;

namespace VoiceNote.Views
{
    [HotReload]
    internal class SettingView : BSMLAutomaticViewController, IInitializable
    {
        public string ResourceName => "VoiceNote.Views.SettingView";

        [UIValue("enable")]
        public bool Enable
        {
            get => PluginConfig.Instance.Enable;
            set => PluginConfig.Instance.Enable = value;
        }

        [UIValue("devices")]
        public List<object> _devices = new List<object>();
        [UIValue("device-name")]
        public string DeviceName
        {
            get => PluginConfig.Instance.MicrophoneDeviceName;
            set => PluginConfig.Instance.MicrophoneDeviceName = value;
        }

        [UIValue("gain")]
        public int Gain
        {
            get => PluginConfig.Instance.Gain;
            set => PluginConfig.Instance.Gain = value;
        }

        public void Initialize()
        {
            BSMLSettings.Instance.AddSettingsMenu("VoiceNote", this.ResourceName, this);
        }

        public SettingView()
        {
            foreach (var device in Microphone.devices) {
                this._devices.Add(device);
            }
        }
    }
}
