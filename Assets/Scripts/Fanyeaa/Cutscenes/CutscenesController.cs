using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CutscenesController : MonoBehaviour
{
    [Header("Objects")]
    public Cutscenes_SObj cutscenesData;
    public Image firstScene;
    public Image secondScene;
    public Animator fadeAnimator;

    [Header("Vars")]
    public int scene1Index = 0;
    public int scene2Index = 1;
    private bool onTransition = false;
    private bool scene1Displayed = true;
    private bool isFinished = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        firstScene.sprite = cutscenesData.scenes[scene1Index];
        secondScene.sprite = cutscenesData.scenes[scene2Index];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !onTransition)
        {
            Debug.Log(isFinished);
            if (isFinished == false)
            {
                StartCoroutine(FadeImages());
            }
            else
            {
                Debug.Log("LoadScene Here!");
            }
        } 
    }

    private IEnumerator FadeImages()
    {
        onTransition = true;

        if (scene1Displayed == true)
        {
            fadeAnimator.SetTrigger("ShowScene2");
            yield return new WaitForSeconds(1f);

            int nextIndex = (scene2Index + 1) % cutscenesData.scenes.Count;
            if (nextIndex == 0)
            {
                isFinished = true;
                Debug.Log("It's donee!");
                onTransition = false;
                yield break;
            }

            scene1Index = nextIndex;

            Debug.Log(scene1Index);
            Debug.Log(scene2Index);

            firstScene.sprite = cutscenesData.scenes[scene1Index];
            secondScene.sprite = cutscenesData.scenes[scene2Index];
        }
        else
        {
            fadeAnimator.SetTrigger("ShowScene1");
            yield return new WaitForSeconds(1f);


            int nextIndex = (scene1Index + 1) % cutscenesData.scenes.Count;
            if (nextIndex == 0)
            {
                Debug.Log("LoadScene!");
                onTransition = false;
                yield break;
            }
            scene2Index = nextIndex;

            Debug.Log(scene1Index);
            Debug.Log(scene2Index);

            secondScene.sprite = cutscenesData.scenes[scene2Index];
        }

        scene1Displayed = !scene1Displayed;
        onTransition = false;

    }
}
