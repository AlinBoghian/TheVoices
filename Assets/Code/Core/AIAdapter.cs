
using System;
using System.Diagnostics;
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
        aiProcess.StartInfo.FileName = AIPath;
        aiProcess.StartInfo.RedirectStandardInput = true;
        aiProcess.StartInfo.RedirectStandardOutput = true;
        aiProcess.StartInfo.UseShellExecute = false;
        aiProcess.StartInfo.CreateNoWindow = false;
        try
        {
            aiProcess.Start();
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    public void startRecord()
    {
        if (aiProcess.HasExited)
        {
            Debug.Log("py process stopped unexpectedly");
            return;
        }
        Debug.Log("writing");
        aiProcess.StandardInput.WriteLine("record");
        Debug.Log("reading");
        Debug.Log(aiProcess.StandardOutput.ReadLine());
    }
    
    public void stopRecord()
    {
        
        if (aiProcess.HasExited)
        {
            Debug.Log("py process stopped unexpectedly");
            return;
        }
        Debug.Log("writing");
        aiProcess.StandardInput.WriteLine("stop");
        Debug.Log("reading");
        Debug.Log(aiProcess.StandardOutput.ReadLine());
    }
}
