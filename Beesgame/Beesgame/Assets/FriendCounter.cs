using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendCounter : MonoBehaviour
{
    public static FriendCounter Instance { get; private set; }
    public int count = 0;

    void Awake()
    {
        Instance = this;
    }
}
