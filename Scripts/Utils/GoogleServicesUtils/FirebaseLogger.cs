using System.Diagnostics;
using Firebase.Analytics;
using Unity.VisualScripting;

namespace UnityServicesToolkit.Utils.GoogleServicesUtils
{
    public static class FirebaseLogger
    {
        public static bool NullCheckAndLog(this object value, string header = "")
        {
            if (value != null && !value.IsUnityNull())
                return true;

            // En. Getting error details and stack traces
            // Tr. Hata detayları ve geri izleme (stack trace) alınması
            StackTrace stackTrace = new StackTrace();
            StackFrame frame = stackTrace.GetFrame(1);

            string methodName = frame.GetMethod().Name;
            string className = frame.GetMethod().DeclaringType?.Name;

            string errorMessage = $"{header}{(string.IsNullOrEmpty(header) ? "" : " / ")} " +
                                  $"NullCheckAndLog : {className}.{methodName}: {nameof(value)} is null";
            
            //Logging...
            UnityEngine.Debug.LogError(errorMessage);
            FirebaseAnalytics.LogEvent("NullCheckAndLog", new Parameter("errorMessage", errorMessage));
            
            return false;
        }

    }
}