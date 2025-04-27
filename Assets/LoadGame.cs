using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Gọi hàm này từ Button (Inspector)
    public void LoadSceneByName(string Gameplay)
    {
        SceneManager.LoadScene(Gameplay);
    }

}
