using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private HUD hud;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private MutantSpawner mutantSpawner;
    [SerializeField] private SphereSpawner sphereSpawner;

    private int score = 0;
    void Start()
    {
        mutantSpawner.Init(GameMode.Play, AddScore, SphereSpawn);
        SetPlayer();
    }

    private void SetPlayer()
    {
        playerController.GameMode = GameMode.Play;
        playerController.playerDestructable.OnPlayerDie += GameOver;
        playerController.playerDestructable.OnHealth += GetHit;
    }
    public void AddScore()
    {
        score++;
        hud.SetScore(score);
    }
    public void GameOver()
    {
        mutantSpawner.GameMode = GameMode.None;
        hud.SetGameOverPanel(score);
    }
    public void GetHit(int health)
    {
        hud.Sethealth(health);
    }
    public void SphereSpawn(Vector3 position)
    {
        sphereSpawner.SphereCreate(position);
    }
}

public enum GameMode
{
    None,
    Play
}