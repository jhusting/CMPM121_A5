using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherStats : EntityHealth
{

    [SerializeField]
    public float energy;

    private void Awake()
    {
        health = 0f;
        energy = 0f;
    }

    public void blockDamage(float val)
    {
        energy = Mathf.Clamp(energy - val, 0f, 100f);
    }
}
