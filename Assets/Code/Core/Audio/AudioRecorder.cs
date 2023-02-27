
using System;
using Code.Core.AI;
using UnityEngine;
using Input = UnityEngine.Windows.Input;

namespace Code.Core.Audio
{
    public class AudioRecorder : MonoBehaviour
    {
        public int MAX_BUFFER_SIZE = 1024 * 1024;
        public int RECORD_TIME = 4;
        private byte[] buffer;

        private void Update()
        {
        }

        public void Record()
        {
            AIAdapter.GetInstance().sendCommand(AICommand.START_RECORD);
            var clip = Microphone.Start(null, false, RECORD_TIME, AudioSettings.outputSampleRate);
            Debug.Log(clip);
        }
    }
}