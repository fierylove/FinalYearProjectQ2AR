using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;

public class MainFirebaseController : MonoBehaviour {

    string email = "email@email.com";
    string password = "password";

    Firebase.Auth.FirebaseAuth auth;

	// Use this for initialization
	private void Start () {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        RegisterNewAccount();
	}
	
	public void RegisterNewAccount()
    {
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if(task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled");
                return;
            }
            if(task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})", newUser.DisplayName, newUser.UserId);

            newUser.SendEmailVerificationAsync().ContinueWith(t => {
                Debug.Log("Verification Email Sent");
            });
        });
    }
}
