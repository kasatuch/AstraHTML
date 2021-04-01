using AstraHTML.Infrastructure.Commands;
using AstraHTML.ViewModels.Base;
using System.Windows;
using System.Windows.Input;

namespace AstraHTML.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {

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
