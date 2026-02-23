// Copyright © 2026 ScottishDwarfStudios under licence from mFriesen1024 (mfriesen1024@gmail.com)

using System.Net;
using ca.ScottishDwarfStudio.UPooledAudioSystem.Util.Strings;

namespace ca.ScottishDwarfStudio.UPooledAudioSystem.Core.Helpers;

internal class LoadHelper
{
    const string MetaExtension = ".meta";

    readonly int[] musicIndices = [4, 7];
    // TODO: yeah i should just calculate these from offset instead of hardcoding...
    readonly int[] soundIndices = [13, 16, 19, 22, 25, 28, 31, 34, 37, 40, 43, 46 ,49];

    WebClient webClient = null!;
    string[] manifestData = null!;
    string version = string.Empty;

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
        webClient ??= new WebClient();

        // I'm too lazy to parse WebClient.DownloadString()
        var tempFile = Path.GetTempFileName();
        var tempMetaFile = Path.GetTempFileName();
        webClient.DownloadFile(PathLib.WebManifestUrl, tempFile);
        string[] manifest = File.ReadAllLines(tempFile);
        File.Delete(tempFile);

        version = manifest[1];
        
        for (int i = 0; i < musicIndices.Length; i++)
        {
            int index = musicIndices[i];
            string name = SfxNameLib.MusicNames[i];
            string webName = manifest[index];
            WebGet(name, webName, tempFile, tempMetaFile);
        }

        for (int i = 0; i < soundIndices.Length; i++)
        {
            int index = soundIndices[i];
            string name = SfxNameLib.SoundNames[i];
            string webName = manifest[index];
            WebGet(name, webName, tempFile, tempMetaFile);
        }
        
        File.Delete(tempFile);
        File.Delete(tempMetaFile);
    }

    void WebGet(string name, string webName, string tempFile, string tempMetaFile)
    {
        string extension = Path.GetExtension(webName);
        string location =
            $"https://github.com/mfriesen1024/DwarfMusic/releases/download/{version}/{webName}";
        string metaLocation = location + MetaExtension;

        webClient.DownloadFile(location, tempFile);
        string target = PathLib.MusDropPath + name + extension;
        File.Delete(target);
        File.Move(tempFile, target);
        webClient.DownloadFile(metaLocation, tempMetaFile);
        target += MetaExtension;
        File.Delete(target);
        File.Move(tempMetaFile, target);
    }

    void LocalGet(int index, string targetPath)
    {
        string name = manifestData[index];
        string meta = name + ".meta";
        //string hash = manifestData[index + 1];

        if (!File.Exists(PathLib.LocalLoadPath + name)) return;
        File.Delete(targetPath + name);
        File.Copy(PathLib.LocalLoadPath + name, targetPath + name);
        File.Delete(targetPath + meta);
        File.Copy(PathLib.LocalLoadPath + meta, targetPath + meta);
    }
}