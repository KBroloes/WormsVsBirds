﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIDirector : MonoBehaviour {

    [Header("Enemy variants to spawn")]
    public List<Enemy> EnemyUnits;

    [Header("Frequency of enemies")]
    public int spawnRate = 5;

    [Header("Lanes to spawn in (i.e. training maps)")]
    public int minLane = 0;
    public int maxLane = 4;

    [Header("Debug only")]
    public int enemies = 0;
    public float deltaTime;
    public bool spawnEnemy = false;

    System.Random rng;

    void Start()
    {
        rng = new System.Random();
    }

    void FixedUpdate()
    {
        deltaTime += Time.fixedDeltaTime;
        if(deltaTime > spawnRate)
        {
            spawnEnemy = true;
            deltaTime = 0;
        }
    }

    void Update()
    {
        if (spawnEnemy)
        {
            int lane = rng.Next(minLane, maxLane);
            int enemyIndex = rng.Next(0, EnemyUnits.Count);
            spawnEnemy = false;

            Enemy enemy = EnemyUnits[enemyIndex];
            GameManager.instance.SpawnEnemy(enemy, new Vector2(8, lane));
            enemies++;
        }

    }
}