using AstraHTML.Infrastructure.Commands;
using AstraHTML.ViewModels.Base;
using System.Windows;
using System.Windows.Input;

namespace AstraHTML.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region Заголовок окна
        /// <summary>Заголовок окна</summary>
        private string _Title = "Анализ статистики CV19";

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
        #endregion

        #region Статус программы
        /// <summary>Статус программы<summary>
        private string _Status = "Готов!";

        public string Status
        {
            get => _Status; //Возращение значение поля свойства
            set => Set(ref _Status, value); //Передача ссылки на поле Status значения value
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
