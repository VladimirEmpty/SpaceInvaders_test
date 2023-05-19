using UnityEngine;
using LasyDI;
using BlackGUI;
using BlackGUI.UI;
using BlackGUI.Factory;

using Code.GUI.MainMenu;
using Code.GUI.MainGame;
using Code.GUI;

namespace Code.Installers
{
    public sealed class GUIInstaller : MonoInstaller
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private UIElementsResources _elementsResources;

        public override void OnInstall()
        {
            BlackGUIConnector.Initialize(_canvas, _elementsResources);

            var factory = new BlackGUIWithDIFactory();
            factory.Bind<GameModel>();
            factory.Bind<GameScreenModel>();

            BlackGUIConnector.SetFactory(factory);

            BlackGUIConnector
                .OpenScreen<MainMenuScreen>()
                .AddController<MainMenuScreenController>();
        }

        private void Reset()
        {
            name = nameof(GUIInstaller);
        }
    }
}
