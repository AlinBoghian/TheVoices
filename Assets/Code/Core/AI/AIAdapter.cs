
using System;
using System.Diagnostics;
using Code.Core.AI;
using Debug = UnityEngine.Debug;

public class AIAdapter
{
    private static AIAdapter _instance;
    private Process aiProcess;
    private static string AIPath = "Assets/Code/TheVoicesSpeechAnalysis/dist/main.exe";
    public static AIAdapter GetInstance()
    {
        if (_instance == null)
        {
            _instance = new AIAdapter();
        }

        return _instance;
    }

    private AIAdapter()
    {
        aiProcess = new Process();
        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = "Assets/Code/TheVoicesSpeechAnalysis/dist/main.exe",
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };
        startInfo.EnvironmentVariables["PYTHONUNBUFFERED"] = "1";
        aiProcess.StartInfo = startInfo;
        try
        {
            aiProcess.Start();
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }


    public void sendCommand(AICommand command)
    {
        sendLine(command.Payload);
    }

    private void sendLine(String msg)
    {
        if (aiProcess.HasExited)
        {
            Debug.Log("py process stopped unexpectedly");
            return;
        }
        aiProcess.StandardInput.WriteLine(msg);
        aiProcess.StandardInput.Flush();
    }
}
