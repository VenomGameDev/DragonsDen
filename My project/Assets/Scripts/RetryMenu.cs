using UnityEngine;
using UnityEngine.SceneManagement;
public class RetryMenu : MonoBehaviour
{
    
    public void RetryGame ()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


    }



}
