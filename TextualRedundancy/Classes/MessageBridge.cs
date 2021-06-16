using System;

namespace TextualRedundancy.Classes
{
    public class ProgressEventArgs : EventArgs
    {
        public double progress = 0;
    }

    public class InfoEventArgs : EventArgs
    {
        public string message = "";
    }

    class MessageBridge
    {
        public static event EventHandler<ProgressEventArgs> OnProgress;
        public static event EventHandler<InfoEventArgs> OnInfo;

        public static void RaiseProgress(double current)
        {
            OnProgress?.Invoke(null, new ProgressEventArgs() { progress = current });
        }

        public static void Info(string msg)
        {
            OnInfo?.Invoke(null, new InfoEventArgs() { message = msg });
        }
    }
}
