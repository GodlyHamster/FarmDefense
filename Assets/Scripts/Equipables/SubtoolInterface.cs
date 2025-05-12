using UnityEngine;
using System.Collections.Generic;

public interface SubtoolInterface
{
    [SerializeField]
    public List<CropScriptableObject> subtoolItems { get; }

    public void NextTool();
    public void PreviousTool();
}
