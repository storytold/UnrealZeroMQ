// Copyright 1998-2018 Epic Games, Inc. All Rights Reserved.

using UnrealBuildTool;
using System;
using System.IO;
using System.Diagnostics;

public class ZeroMQ : ModuleRules
{
    private string ThirdPartyPath
    {
        get { return Path.GetFullPath(Path.Combine(ModuleDirectory, "..", "..", "ThirdParty")); }
    }

    private string ZeroMQRootPath
    {
        get { return Path.GetFullPath(Path.Combine(ThirdPartyPath, "libzmq_4.3.1")); }
    }

    public void AddZeroMQ(ReadOnlyTargetRules Target)
    {
        // add headers
        PublicIncludePaths.Add(Path.Combine(ZeroMQRootPath, "include"));

        // tell library that it is statically linked
        PublicDefinitions.Add("ZMQ_STATIC");

        // NB(bt): This isn't compiling for Unreal Engine 4.25:
        // Error CS0151
        // A switch expression or case label must be a bool, char, string, integral, enum, or corresponding nullable type
        // c:\Users\echel\OneDrive\Documents\Unreal Projects\AzureKinect\Plugins\UnrealZeroMQ\Source\ZeroMQ\ZeroMQ.Build.cs	29
        //
        // I'll hardcode the results for Windows x64 for now.
        // Sorry for being a bad citizen to other platforms, especially Linux. :(

        string staticLibrary = Path.Combine(ZeroMQRootPath, "Windows", "x64", "libzmq-v141-mt-s-4_3_2.lib");

        /*
        string staticLibrary = "";

        switch (Target.Platform)
        {
            case UnrealTargetPlatform.Win64:
                staticLibrary = Path.Combine(ZeroMQRootPath, "Windows", "x64", "libzmq-v141-mt-s-4_3_2.lib");
                break;
            case UnrealTargetPlatform.Win32:
                staticLibrary = Path.Combine(ZeroMQRootPath, "Windows", "x86", "libzmq-v141-mt-s-4_3_2.lib");
                break;
            case UnrealTargetPlatform.Linux:
                staticLibrary = Path.Combine(ZeroMQRootPath, "Linux", "libzmq.so");
                PublicAdditionalLibraries.Add("stdc++");
                break;
            case UnrealTargetPlatform.Mac:
                staticLibrary = Path.Combine(ZeroMQRootPath, "MacOS", "libzmq.a");
                break;
            default:
                Console.WriteLine("unsupported target platform: %s", Target.Platform);
                Debug.Assert(false);
                break;
        }*/

        bEnableExceptions = true;

        Console.WriteLine("Using ZeroMQ static library: {0}", staticLibrary);
        PublicAdditionalLibraries.Add(staticLibrary);
    }


    public ZeroMQ(ReadOnlyTargetRules Target) : base(Target)
    {
        PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;
        PublicDependencyModuleNames.AddRange(new string[] { "Core" });
        AddZeroMQ(Target);

    }
}
