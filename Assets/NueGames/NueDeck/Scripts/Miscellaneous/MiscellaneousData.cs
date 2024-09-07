using UnityEngine;
using NueGames.NueDeck.Scripts.Managers;
[CreateAssetMenu(fileName = "NewMiscellaneousData", menuName = "MiscellaneousData", order = 1)]
public class MiscellaneousData : ScriptableObject
{
    public string Description;
    public Sprite Image;
    public FunctionType SelectedFunction;
    private GameManager GameManager => GameManager.Instance;
    public enum FunctionType
    {
        Well,
        Staircase
    }

    public void InvokeFunction()
    {
        switch (SelectedFunction)
        {
            case FunctionType.Well:
                Well();
                break;
            case FunctionType.Staircase:
                Staircase();
                break;
        }
    }

    private void Well()
    {
        if (GameManager.PersistentGameplayData.AllyHealthDataList.Count > 0)
            GameManager.PersistentGameplayData.AllyHealthDataList[0].CurrentHealth = GameManager.PersistentGameplayData.AllyHealthDataList[0].MaxHealth;
    }

    private void Staircase()
    {
        Debug.Log("Staircase");
    }
}
