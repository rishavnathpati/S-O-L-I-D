using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages the game state and scene loading.
/// </summary>
public class GameManager : MonoBehaviour
{
    private const string PREMADE_LEVEL_SCENE = "PremadeLevel";

    // Start is called before the first frame update
    private void Start() => SceneManager.LoadScene(PREMADE_LEVEL_SCENE, LoadSceneMode.Additive);
}
