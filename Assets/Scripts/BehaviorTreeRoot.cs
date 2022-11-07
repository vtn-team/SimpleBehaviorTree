using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class BehaviorTreeRoot : MonoBehaviour
{
    [SerializeField, SerializeReference, SubclassSelector] IBehavior RootNode;
    [SerializeField] GameObject Player;

    Environment _env = new Environment();

    void Start()
    {
        _env.mySelf = this.gameObject;
        _env.target = Player;
    }

    void Update()
    {
        RootNode.Action(_env);
    }
}