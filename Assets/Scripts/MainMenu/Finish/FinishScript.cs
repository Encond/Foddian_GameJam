using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour
{
    public void GoToMainManu(){
        SceneManager.LoadScene("Menu");
        
    }
}
