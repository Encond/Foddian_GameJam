using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out Player.Player player))
            {
                SceneManager.LoadScene("Wins");
            }
        }
}
