using Firebase;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;
using Firebase.Extensions;
using JetBrains.Annotations;
using TMPro;

public class AuthManager : MonoBehaviour
{
    public Text logText;
    public Button signInButton, signUpButton;
    public TMP_InputField email, password;
    public virtual void Start()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            Firebase.DependencyStatus dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {

            }
            else
            {
                Debug.LogError("Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
        });
    }
    public void OnClickSignIn()
    {
        Debug.Log("Clicked SignIn");
        FirebaseAuth.DefaultInstance.SignInWithEmailAndPasswordAsync(email.text, password.text).ContinueWith(task => {
        if (task.IsCanceled)
        {
            Debug.Log("SignIn Canceled");
            Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
            return;
        }
            if (task.IsFaulted)
            {
                Debug.Log("SignIn Failed");
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error:" + task.Exception);
                return;
            }
            Firebase.Auth.FirebaseUser newUser = task.Result.User;
            Debug.LogFormat("User signed in successfully: {0} ({1})", newUser.DisplayName, newUser.UserId);
        });
    }
    public void OnClickSignup()
    {
        Debug.Log("Clicked Signup");
        FirebaseAuth.DefaultInstance.CreateUserWithEmailAndPasswordAsync(email.text, password.text).ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled)
            {
                Debug.Log("Signup Canceled");
                logText.text = "SignInWithEmailAndPasswordAsync was canceled.";
                return;
            }

            if (task.IsFaulted)
            {
                Debug.Log("Signup Failed");
                logText.text = task.Exception.ToString();
                return;
            }

            Debug.Log("Signup Successful");
            Firebase.Auth.FirebaseUser newUser = task.Result.User;
            Debug.LogFormat("User signed in successfully: {0} ({1})", newUser.DisplayName, newUser.UserId);
        });

    }

}
