using IPA.Loader;
using System.Linq;
using Zenject;

namespace VoiceNote.Utilities
{
    public class NoodleChoromaChecker : IInitializable
    {
        public BeatmapLevel Currentmap { get; private set; }
        public BeatmapKey CurrentmapKey { get; private set; }
        public bool IsNoodle { get; private set; }
        public bool IsChroma { get; private set; }

        [Inject]
        public NoodleChoromaChecker(GameplayCoreSceneSetupData gameplayCoreSceneSetupData)
        {
            this.Currentmap = gameplayCoreSceneSetupData.beatmapLevel;
            this.CurrentmapKey = gameplayCoreSceneSetupData.beatmapKey;
        }

        public static bool IsNoodleMap(BeatmapLevel level, BeatmapKey key)
        {
            if (PluginManager.EnabledPlugins.Any(x => x.Name == "NoodleExtensions")) {
                var isIsNoodleMap = SongCore.Collections.RetrieveDifficultyData(level, key)?
                    .additionalDifficultyData?
                    ._requirements?.Any(x => x == "Noodle Extensions") == true;
                return isIsNoodleMap;
            }
            else {
                return false;
            }
        }
        public static bool IsChromaMap(BeatmapLevel level, BeatmapKey key)
        {
            if (PluginManager.EnabledPlugins.Any(x => x.Name == "Chroma")) {
                var isIsNoodleMap = SongCore.Collections.RetrieveDifficultyData(level, key)?
                    .additionalDifficultyData?
                    ._requirements?.Any(x => x == "Chroma") == true;
                isIsNoodleMap = isIsNoodleMap || SongCore.Collections.RetrieveDifficultyData(level, key)?
                    .additionalDifficultyData?
                    ._suggestions?.Any(x => x == "Chroma") == true;
                return isIsNoodleMap;
            }
            else {
                return false;
            }
        }

        public void Initialize()
        {
            this.IsNoodle = IsNoodleMap(this.Currentmap, this.CurrentmapKey);
            this.IsChroma = IsChromaMap(this.Currentmap, this.CurrentmapKey);
        }
    }
}
