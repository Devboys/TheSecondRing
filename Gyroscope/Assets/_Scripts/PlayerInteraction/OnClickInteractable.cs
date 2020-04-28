using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickInteractable : MonoBehaviour
{
    public event Action OnInteractEvent;

    private MeshRenderer _renderer;

    public Color highlightedColor;
    private Color normalColor;

    private bool isHighlighted;
    private bool wasHighlighted;

    public void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
    }

    public void Update()
    {
        //super bad way of highlighting, but this was just for test purposes
        if (!wasHighlighted && isHighlighted)
        {
            normalColor = _renderer.material.GetColor("_BaseColor");
            _renderer.material.SetColor("_BaseColor", highlightedColor);
        }
        else if (wasHighlighted && !isHighlighted)
        {
            _renderer.material.SetColor("_BaseColor", normalColor);
        }

        wasHighlighted = isHighlighted;
        isHighlighted = false;
    }

    public virtual void HandleInteract(GameObject sender) {
        OnInteractEvent?.Invoke();
    }

    public virtual void OnHighlight(GameObject sender) {
        isHighlighted = true;
    }

}
