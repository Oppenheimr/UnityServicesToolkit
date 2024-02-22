using Firebase.Analytics;
using UnityUtils.BaseClasses;

namespace UnityServicesToolkit.Services.GoogleServices
{
    public class Analytics : Singleton<Analytics>
    {

        public static void Initialize()
        {
            FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
        }
    }
}