using System;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private int _jumpCounter;
    [SerializeField] TextMeshProUGUI _countDownText;

    public static event Action<bool> PreventJump;
    public static event Action<bool> EnableJump;
    void Start()
    {
        _jumpCounter = 10;
        _countDownText.text = _jumpCounter.ToString();
        PlayerMovement.OnJump += DecreaseJumpCounter;
    }

    private void DecreaseJumpCounter()
    {
        _jumpCounter--;
        _countDownText.text = _jumpCounter.ToString();
        if (_jumpCounter <= 0)
        {
            //Prevent Player from jumping
            Debug.Log("Sorry Can't Jump Again");
            PreventJump?.Invoke(false);
            
        }
    }

    public void AddJumps(int amount)
    {
        _jumpCounter = amount;
        _countDownText.text = _jumpCounter.ToString();
        EnableJump?.Invoke(true);
        
    }
}
