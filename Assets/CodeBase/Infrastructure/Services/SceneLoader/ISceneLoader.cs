using System;
using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.Services.SceneLoader
{
    public interface ISceneLoader
    {
        UniTask Load(string name, Action onLoaded = null);
    }
}