using UnityEngine;
using UnityEngine.UI;

public class ButtonUI : MonoBehaviour
{
    private Animator _animator;
    private Button _button;
    private LoadSprites _loadSprites;
    private void Start()
    {
        _button = GetComponent<Button>();
        _animator = GetComponent<Animator>();
        _loadSprites = FindObjectOfType<LoadSprites>();

        _button.onClick.AddListener(OnButtonClick);
    }
    private void OnButtonClick()
    {
        _animator.SetBool("Blink", true);
        _loadSprites.LoadSprite();
    }
}
