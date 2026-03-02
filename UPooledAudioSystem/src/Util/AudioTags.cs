// Copyright © 2026 ScottishDwarfStudios under licence from mFriesen1024 (mfriesen1024@gmail.com)

namespace ca.ScottishDwarfStudio.UPooledAudioSystem.Util
{
    public static class AudioTags
    {
        public enum Tag
        {
            Default,
            BGM,
            Static,
        }

        public const string DefaultTag = "Default";
        public const string BGMTag = "BGM";
        public const string StaticTag = "Static";

        static string[] strings = {
            DefaultTag,
            BGMTag,
            StaticTag,
        };

        // May be an antipattern but i don't care atm.
        internal static string TagToString(Tag tag) => strings[(int)tag];
    }
}