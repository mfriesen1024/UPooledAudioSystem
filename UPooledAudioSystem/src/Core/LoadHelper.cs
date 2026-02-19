// Copyright © 2026 ScottishDwarfStudios under licence from mFriesen1024 (mfriesen1024@gmail.com)

namespace ca.ScottishDwarfStudio.UPooledAudioSystem.Core;

internal class LoadHelper
{
    const string WebManifestUrl = "https://raw.githubusercontent.com/mfriesen1024/DwarfMusic/refs/heads/DwarfMenu/manifest";
        
    const string LocalLoadPath = "../DwarfMusic/Output/";
    const string LocalManifestPath = "../DwarfMusic/manifest";
    
    const string MusDropPath = "./Assets/Sound/Music/";
    const string SfxDropPath = "./Assets/Sound/SFX/";

    const string MenuTheme = "menu";
    const string GameplayTheme = "gameplay";
    readonly string[] musicNames = [MenuTheme, GameplayTheme];
    readonly int[] musicIndices = [4, 7];
    readonly int[] soundIndices = [-1,-1,-1,-1,-1,-1,-1,-1,-1,-1];

    string[] manifestData = null!;
    
    public void TryLoadSounds()
    {
        // Make sure drop paths exist where they should.
        Directory.CreateDirectory(MusDropPath);
        Directory.CreateDirectory(SfxDropPath);

        if (!TryLocalLoad()) TryWebLoad();
    }

    bool TryLocalLoad()
    {
        // I forget if this throws on DirectoryNotFound.
        try
        {
            if (!File.Exists(LocalLoadPath)) return false;
        }
        catch (Exception ignored)
        {
            return false;
        }
        
        manifestData = File.ReadAllLines(LocalManifestPath);

        foreach (var i in musicIndices)
        {
            LocalGet(i,MusDropPath);
        }

        foreach (var i in soundIndices)
        {
            LocalGet(i,SfxDropPath);
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

        if (!File.Exists(LocalLoadPath + name)) return;
        File.Delete(targetPath + name);
        File.Delete(targetPath + meta);
        File.Copy(LocalLoadPath + name, targetPath + name);
        File.Copy(LocalLoadPath + meta, targetPath + meta);
    }
}