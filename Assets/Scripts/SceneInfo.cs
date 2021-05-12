using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SceneInfo{

    private static GameObject prefabName;

    public static GameObject Prefab
    {
        get
        {
            return prefabName;
        }
        set
        {
            prefabName = value;
        }
    }
}
