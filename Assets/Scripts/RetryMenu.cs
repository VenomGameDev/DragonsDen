using UnityEngine;
using UnityEngine.SceneManagement;
public class RetryMenu : MonoBehaviour
{
    
    public void RetryGame ()
    {

        Debug.Log("????????");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


    }



}
