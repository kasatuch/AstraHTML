using AstraHTML.Infrastructure.Commands;
using AstraHTML.Infrastructure.Commands.Base;
using AstraHTML.ViewModels.Base;
using AstraHTML.Views.Windows;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace AstraHTML.ViewModels
{
    class RegisterViewModel : ViewModel
    {
        #region Команды

        #region Регистрация


        public ICommand Registration { get; }
        private bool CanRegistration(object p) => true;
        public Action CloseAction { get; set; }
        private void OnRegistration(object p)
        {

        }
        #endregion
        #endregion

        public RegisterViewModel()
        {
            
            #region Команды

            Registration = new LambdaCommand(OnRegistration, CanRegistration);

            #endregion

        }
    }
}
