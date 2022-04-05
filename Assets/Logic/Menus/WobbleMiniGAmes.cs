using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WobbleMiniGAmes : MonoBehaviour
{
    public TMP_Text textComponent;
    public float myAlpha;
    private Color myColor;
    [SerializeField]
    public bool fader = false;
    public bool blinker;
    private GameManager myGameManager;
    private GameObject gameManager;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        myGameManager = gameManager.GetComponent<GameManager>();
        textComponent = GetComponent<TMP_Text>();
        myColor = textComponent.color;
        myAlpha = myColor.a;
        textComponent.text = "You played " + myGameManager.minigameCount + " Minigames!";

    }

    // Update is called once per frame
    void Update()
    {
        if (blinker)
        {
            Invoke("FadeUp", 3);
        }
        if (fader)
        {
            myAlpha -=Time.deltaTime;
            textComponent.color = new Color(myColor.r,myColor.g, myColor.b, myAlpha);
            if (myAlpha <= 0)
            {
                gameObject.SetActive(false);
            }
        }
        
        textComponent.ForceMeshUpdate();
        var textInfo = textComponent.textInfo;

        for (int i = 0; i < textInfo.characterCount; i++)
        {
            var charInfo = textInfo.characterInfo[i];

            if (!charInfo.isVisible)
            {
                continue;
            }

            var verts = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;

            for (int j = 0; j < 4; j++)
            {
                var orig = verts[charInfo.vertexIndex + j];
                verts[charInfo.vertexIndex + j] = orig + new Vector3(0, Mathf.Sin(Time.time * 2f + orig.x*0.01f) * 10f, 0);
            }
        }

        for (int i = 0; i < textInfo.meshInfo.Length; i++)
        {
            var meshInfo = textInfo.meshInfo[i];
            meshInfo.mesh.vertices = meshInfo.vertices;
            textComponent.UpdateGeometry(meshInfo.mesh, i);
        }
    }

    private void FadeUp()
    {
        fader = true;
    }
    
}
