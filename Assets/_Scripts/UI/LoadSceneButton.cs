using _Scripts.Services.SceneLoadService;
using Zenject;

namespace _Scripts.UI
{
    public class LoadSceneButton : ButtonBase
    {
        private ISceneLoadService _sceneLoadService;

        [Inject]
        private void Construct(ISceneLoadService sceneLoadService)
        {
            _sceneLoadService = sceneLoadService;
        }
        
        protected override void OnClick()
        {
            _sceneLoadService.Load("GameScene");
        }
    }
}