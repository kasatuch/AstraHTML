using AstraHTML.Infrastructure.Commands;
using AstraHTML.ViewModels.Base;
using System.Windows;
using System.Windows.Input;

namespace AstraHTML.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region Картинка с будильником
        private string _ImageSource = "/Resources/Images/Time.png";

        public string ImageSource
        {
            get => _ImageSource;
            set => Set(ref _ImageSource, value);

        }
        
        #endregion

        #region Команды

        #region CloseApplicationCommand
        public ICommand CloseApplicationCommand { get; }
        private bool CanCloseApplicationCommandExecute(object p) => true;
        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown(); //Логика команды
        }
        #endregion

        #endregion
        public MainWindowViewModel()
        {
            #region Команды

            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);

            #endregion

        }


    }
}
