using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;
public class playerAnimatorSetter : MonoBehaviour
{
    public BoolVariable isPlayerWalking;
    private Animator controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        controller.SetBool("IsPlayerWalking", isPlayerWalking.Value);
    }
}
