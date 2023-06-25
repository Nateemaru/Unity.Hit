using System;
using System.Threading.Tasks;

namespace _Scripts.UI
{
    public interface IFadeScreen
    {
        public void FadeIn(Action callback = null);
        public void FadeOut(Action callback = null);
    }
}