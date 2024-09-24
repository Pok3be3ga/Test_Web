using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class LoadSprites : MonoBehaviour
{
    [SerializeField] private string _spriteName;
    private List<GameObject> _spriteRenderers = new List<GameObject>();

    private void Start()
    {
        foreach(Transform child in transform)
        {
            _spriteRenderers.Add(child.gameObject);
        }
    }
    public void LoadSprite()
    {
        for (int i = 0; i < _spriteRenderers.Count; i++)
        {
            StartCoroutine(LoadSprite(_spriteRenderers[i].GetComponent<SpriteRenderer>(), i));
        }
    }

    IEnumerator LoadSprite(SpriteRenderer spriteRenderer, int number)
    {
        var task = Addressables.LoadAssetAsync<Sprite>(_spriteName + (number + 1));
        yield return task;
        spriteRenderer.sprite = task.Result;
    }

}
