using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllScore : MonoBehaviour
{
    public bool Scene01;
    public bool Scene02;
    public bool Scene03;
    
    public void LoadScene01()
    {
        SceneManager.LoadScene("Score01");
    }
    
    public void LoadScene02()
    {
        SceneManager.LoadScene("Score02");
    }
    
    public void LoadScene03()
    {
        SceneManager.LoadScene("Score03");
    }
}
