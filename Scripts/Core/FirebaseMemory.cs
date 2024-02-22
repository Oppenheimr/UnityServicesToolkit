using System.Threading.Tasks;
using Firebase;
using Firebase.Crashlytics;
using Firebase.Extensions;
using UnityEngine;
using UnityServicesToolkit.Services.GoogleServices;
using UnityUtils.BaseClasses;

namespace UnityServicesToolkit.Core
{
    public class FirebaseMemory : Singleton<FirebaseMemory>
    {
        public static DependencyStatus dependencyStatus = DependencyStatus.UnavailableOther;
        public static FirebaseApp App;
        public static bool firebaseInitialized = false;
        
        public static async Task Initialize()
        {
            await FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
            {
                dependencyStatus = task.Result;
                if (dependencyStatus == DependencyStatus.Available)
                {
                    App = FirebaseApp.DefaultInstance;

                    // When this property is set to true, Crashlytics will report all
                    // uncaught exceptions as fatal events. This is the recommended behavior.
                    Crashlytics.ReportUncaughtExceptionsAsFatal = true;

                    //Database.Initialize();
                    //Messaging.Initialize();
                    //RemoteConfig.Initialize();
                    //Functions.Initialize();
                    //Crashlytics.Initialize();
                    //Storage.Initialize();
                    //AppCheck.Initialize();
                    //Firestore.Initialize();
                    //Auth.Initialize();
                    //DynamicLinks.Initialize();
                    Analytics.Initialize();
                    //Installations.Initialize();

                    firebaseInitialized = true;
                }
                else
                {
                    Debug.LogError("Could not resolve all Firebase dependencies: " + dependencyStatus);
                }
            });
        }
    }
}