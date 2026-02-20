// Copyright © 2026 ScottishDwarfStudios under licence from mFriesen1024 (mfriesen1024@gmail.com)

using ca.ScottishDwarfStudio.UPooledAudioSystem.Util.Strings;

namespace ca.ScottishDwarfStudio.UPooledAudioSystem.Core.Helpers;

internal class LoadHelper
{
    const string MenuTheme = "menu";
    const string GameplayTheme = "gameplay";
    readonly string[] musicNames = [MenuTheme, GameplayTheme];
    readonly int[] musicIndices = [4, 7];
    readonly int[] soundIndices = [-1,-1,-1,-1,-1,-1,-1,-1,-1,-1];

    string[] manifestData = null!;
    
    public void TryLoadSounds()
    {
        // Make sure drop paths exist where they should.
        Directory.CreateDirectory(PathLib.MusDropPath);
        Directory.CreateDirectory(PathLib.SfxDropPath);

        if (!TryLocalLoad()) TryWebLoad();
    }

    bool TryLocalLoad()
    {
        // I forget if this throws on DirectoryNotFound.
        try
        {
            if (!File.Exists(PathLib.LocalLoadPath)) return false;
        }
        catch (Exception ignored)
        {
            return false;
        }
        
        manifestData = File.ReadAllLines(PathLib.LocalManifestPath);

        foreach (var i in musicIndices)
        {
            LocalGet(i, PathLib.MusDropPath);
        }

        foreach (var i in soundIndices)
        {
            LocalGet(i, PathLib.SfxDropPath);
        }
        
        return true;
    }

    void TryWebLoad()
    {
        
    }

    void LocalGet(int index, string targetPath)
    {
        string name = manifestData[index];
        string meta = name + ".meta";
        string hash = manifestData[index + 1];

        if (!File.Exists(PathLib.LocalLoadPath + name)) return;
        File.Delete(targetPath + name);
        File.Delete(targetPath + meta);
        File.Copy(PathLib.LocalLoadPath + name, targetPath + name);
        File.Copy(PathLib.LocalLoadPath + meta, targetPath + meta);
    }
}