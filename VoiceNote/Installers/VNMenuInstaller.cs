using VoiceNote.Views;
using Zenject;

namespace VoiceNote.Installers
{
    public class VNMenuInstaller : Installer
    {
        public override void InstallBindings()
        {
            this.Container.BindInterfacesAndSelfTo<SettingView>().FromNewComponentAsViewController().AsSingle();
        }
    }
}
