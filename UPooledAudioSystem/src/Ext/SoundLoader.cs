// Copyright © 2026 ScottishDwarfStudios under licence from mFriesen1024 (mfriesen1024@gmail.com)

using System;
using System.IO;
using System.Net;
using UnityEngine;

// ReSharper disable once CheckNamespace
public class SoundLoader : MonoBehaviour
{
    // Don't waste memory on this in release mode.
#if UNITY_EDITOR
    [SerializeField] bool forceWeb;
    [SerializeField] bool restartOnWebUpdate = true;
    
    const string DepName = "UPooledAudioSystem.dll";
    const string SymbolsName = "UPooledAudioSystem.pdb";
    const string MetaName = "UPooledAudioSystem.dll.meta";
    
    const string DepDirName = "UPooledAudioSystem/UPooledAudioSystem/bin/Debug/netstandard2.1/";
    const string MainDepPath = "../"+DepDirName;
    const string AltDepPath = "../../../RiderProjects/"+DepDirName;
    const string TempVersionPath = "./obj/Debug/";
    const string TempVersionFile = TempVersionPath + "soundVersion";

    const string TargetDirName = "./Assets/ExternalAssemblies/";
    
    const string VersionUrl =
        "https://raw.githubusercontent.com/ScottishDwarfStudio/UPooledAudioSystem/refs/heads/stable/versioninfo";
    
    
    void OnValidate()
    {
        byte foundPath;
        if (forceWeb) { foundPath = 2;}
        else if (Directory.Exists(MainDepPath) && File.Exists(MainDepPath+DepName)){foundPath=0;}
        else if (Directory.Exists(AltDepPath) && File.Exists(AltDepPath + DepName)) { foundPath = 1;}
        else {foundPath=2;}
        
        if (!Directory.Exists(TargetDirName)) { Directory.CreateDirectory(TargetDirName);}
        if(File.Exists(TargetDirName+SymbolsName)) File.Delete(TargetDirName+SymbolsName);
        if(foundPath!=2) File.Delete(TargetDirName+DepName);

        // bla
        switch (foundPath)
        {
            case 0:
                File.Copy(MainDepPath+DepName,TargetDirName+DepName);
                File.Copy(MainDepPath+SymbolsName,TargetDirName+SymbolsName);
                if(File.Exists(MainDepPath+MetaName)&&!File.Exists(TargetDirName+MetaName)) 
                    File.Copy(MainDepPath+MetaName,TargetDirName+MetaName);
                Debug.Log("Successfully updated from main path.");
                break;
            case 1:
                File.Copy(AltDepPath+DepName,TargetDirName+DepName);
                File.Copy(AltDepPath+SymbolsName,TargetDirName+SymbolsName);
                if(File.Exists(AltDepPath+MetaName)&&!File.Exists(TargetDirName+MetaName)) 
                    File.Copy(AltDepPath+MetaName,TargetDirName+MetaName);
                Debug.Log("Successfully updated from alt path.");
                break;
            case 2:
                using (var client = new WebClient())
                {
                    string oldVersion = $"v{float.NaN}";
                    Directory.CreateDirectory(TempVersionPath);
                    if(File.Exists(TempVersionFile)) oldVersion = File.ReadAllText(TempVersionFile);
                    client.DownloadFile(VersionUrl, TempVersionFile);
                    string version = File.ReadAllText(TempVersionFile);

                    if (oldVersion == version && File.Exists(TargetDirName+DepName))
                    {
                        // Debug.Log($"Successfully verified sound system. Running version {version}");
                        return;
                    }
                    
                    string releaseURL =
                        $"https://github.com/ScottishDwarfStudio/UPooledAudioSystem/releases/download/{version}/";
                    
                    client.DownloadFile(releaseURL + DepName, TargetDirName+DepName);
                    client.DownloadFile(releaseURL + MetaName, TargetDirName+MetaName);

                    // Debug.Log($"Successfully updated sound system to {version}.");
                }

                if (restartOnWebUpdate) new GameObject().AddComponent(typeof(UnityRestarter));
                break;
        }
    }

    void Start()
    {
        OnValidate();
    }

    class UnityRestarter : MonoBehaviour
    {
        [SerializeField] Component restarter;

        void OnValidate()
        {
            restarter = new GameObject().AddComponent(typeof(UnityRestarter)) as UnityRestarter;
        }
    }
#endif
}