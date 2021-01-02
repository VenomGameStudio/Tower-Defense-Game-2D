using UnityEngine;

public class TowerManager : Singleton<TowerManager>
{
    private TowerBtn towerBtnPressed;

    public void SelectedTower(TowerBtn towerSelected)
    {
        towerBtnPressed = towerSelected;
        Debug.Log("Pressed : " + towerBtnPressed);
    }
}
