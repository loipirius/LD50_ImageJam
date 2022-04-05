using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalOnlyOne : MonoBehaviour
{
    private static portalOnlyOne _instance;
    public static portalOnlyOne Instance {
        get { return _instance; }
        set {
            if (_instance == null) {
                _instance = value;
            } else {
                Destroy(value.gameObject);
            }
        }
    }
    private void Awake () {
        Instance = this;
    }
}
