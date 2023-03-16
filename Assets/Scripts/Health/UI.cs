using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private Image _life;
    
    /// <summary>
    /// Update life bar in UI
    /// </summary>
    public void UpdateLife()
    {
        if (!_playerHealth)
            return;
        
        _life.fillAmount = _playerHealth.GetHealth / _playerHealth.MaxHealth;
    }
}
