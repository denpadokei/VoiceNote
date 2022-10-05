using SiraUtil.Extras;
using SiraUtil.Objects.Beatmap;
using VoiceNote.Configuration;
using VoiceNote.Utilities;
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
            this.Container.BindInterfacesAndSelfTo<NoodleChoromaChecker>().AsCached();
            this.Container.BindInterfacesAndSelfTo<AudioVolumeGetter>().FromNewComponentOnNewGameObject().AsCached();
            this.Container.RegisterRedecorator(new BasicNoteRegistration(this.DecorateNote, 500));
            this.Container.RegisterRedecorator(new BurstSliderHeadNoteRegistration(this.DecorateNote, 500));
            this.Container.RegisterRedecorator(new BurstSliderNoteRegistration(this.DecorateNote, 500));
        }

        /// <summary>
        /// <see cref="NoteController"/>作成時に実行されます。
        /// </summary>
        /// <typeparam name="T"><see cref="NoteController"/></typeparam>
        /// <param name="original"></param>
        /// <returns></returns>
        private T DecorateNote<T>(T original)
            where T : NoteController
        {
            original.gameObject.AddComponent<VoiceNoteController>();
            return original;
        }
    }
}
