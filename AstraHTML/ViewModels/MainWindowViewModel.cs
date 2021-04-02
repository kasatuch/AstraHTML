using AstraHTML.Infrastructure.Commands;
using AstraHTML.ViewModels.Base;
using AstraHTML.Views.Windows;
using System.Windows;
using System.Windows.Input;

namespace AstraHTML.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {

        #region Команды

        #region Открыть окно регистрации


        public ICommand OpenRegForm { get; }
        private bool CanOpenRegFormCommandExecute(object p) => true;
        public Register register = new Register();
        private void OnOpenRegFormCommandExecuted(object p)
        {
            if(register.IsLoaded == false)
            {
                register.Show();
            }
        }

        #endregion


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

            OpenRegForm = new LambdaCommand(OnOpenRegFormCommandExecuted, CanOpenRegFormCommandExecute);

            #endregion

        }


    }
}
