using SiraUtil.Extras;
using SiraUtil.Objects.Beatmap;
using VoiceNote.Configuration;
using Zenject;

namespace VoiceNote.Installers
{
    internal class VNGameInstaller : Installer
    {
        public override void InstallBindings()
        {
            if (PluginConfig.Instance?.Enable != true) {
                return;
            }
            this.Container.BindInterfacesAndSelfTo<AudioVolumeGetter>().FromNewComponentOnNewGameObject().AsCached();
            this.Container.RegisterRedecorator(new BasicNoteRegistration(this.DecorateNote, 500));
        }

        private GameNoteController DecorateNote(GameNoteController original)
        {
            original.gameObject.AddComponent<VoiceNoteController>();
            return original;
        }
    }
}
