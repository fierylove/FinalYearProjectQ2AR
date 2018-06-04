using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainFirebaseController : MonoBehaviour {

    string email = "email@email.com";
    string password = "password";

    Firebase.Auth.FirebaseAuth auth;

	// Use this for initialization
	private void Start () {
        auth = Firebase.Auth.FirebaseAuth.Defaultinstance;
        RegisterNewAccount();
	}
	
	public void egisterNewAccount()
    {
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if(task.isCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled");
                return;
            }
            if(task.isFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            Firebase.Auth.FirebaseUser newUser = task.Result;
            debug.LogFormat("Firebase user created successfully: {0} ({1})", newUser.DisplayName, newUser.UserId);

            newUser.SendEmailVerificationAsync().ContinueWith(task => {
                Debug.Log("Verification Email Sent");
            });
        });
    }
}
