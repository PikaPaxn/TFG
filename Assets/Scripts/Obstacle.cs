﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int score = 1;
    bool _dead;

    void LateUpdate() {
        if (_dead)
            return;

        if (transform.position.x < RunnerManager.Instance.player.transform.position.x) {
            RunnerManager.Instance.AddScore(score);
            _dead = true;
            Destroy(gameObject, 1f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            RunnerManager.Instance.GameOver();
            Destroy(gameObject);
        }
    }
}
