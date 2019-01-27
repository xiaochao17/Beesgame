using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeeHealth : MonoBehaviour
{
    [SerializeField] private GameObject healthBar;
    [SerializeField] private int maxValue;
    private int _value;
    private readonly Cooldown _damageCooldown = new Cooldown(1);
    private readonly Dictionary<string, int> _tagToDelta = new Dictionary<string, int>
    {
        {"Enemy", -1}
    }; 

    void Start()
    {
        Add(maxValue);
    }

    void Update()
    {
        _damageCooldown.AddRemainingSeconds(-Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        AddBasedOnTag(other.tag);
        CheckForDeath();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        AddBasedOnTag(other.transform.tag);
        CheckForDeath();
    }

    private void AddBasedOnTag(string otherTag)
    {
        if (_tagToDelta.ContainsKey(otherTag))
        {
            var delta = _tagToDelta[otherTag];
            Add(delta);
        }
    }
    
    private void Add(int value)
    {
        if (value < 0 && !_damageCooldown.TryUse())
        {
            return;
        }
        
        _value += value;
        _value = Mathf.Clamp(_value, 0, maxValue);
        healthBar.transform.localScale = new Vector3((float) _value / maxValue, 1f, 1f);
    }

    private void CheckForDeath()
    {
        if (_value == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
