using System.Collections;
using _Scripts.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.Services
{
    public class SceneLoader
    {
        /*public void LoadSceneAsync(int sceneIndex)
        {
            if (sceneIndex >= 0 && sceneIndex < SceneManager.sceneCountInBuildSettings)
                CoroutineStarter.Instance.StartRoutine(SceneLoadProgressRoutine(sceneIndex));
        }

        private IEnumerator SceneLoadProgressRoutine(int index)
        {
            var waitFading = true;
            Fader.Instance.FadeIn(() => waitFading = false);

            while (waitFading)
                yield return null;
            
            var asyncOperation = SceneManager.LoadSceneAsync(index);
            asyncOperation.allowSceneActivation = false;
                
            while (!asyncOperation.isDone)
                yield return null;

            asyncOperation.allowSceneActivation = true;
            
            yield return new WaitForSeconds(0.5f);
            
            waitFading = true;
            Fader.Instance.FadeOut(() => waitFading = false);

            while (waitFading)
                yield return null;
        }*/
    }
}