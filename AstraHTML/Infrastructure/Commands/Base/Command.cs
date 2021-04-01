using System;
using System.Windows.Input;

namespace AstraHTML.Infrastructure.Commands.Base
{
    internal abstract class Command : ICommand
    {

        //Событие вызывается тогда, когда значения CanExecute меняется.
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        //Если эта функция возвращает false, то элемент,
        //к которому привязана эта команда отключается автоматически

        public abstract bool CanExecute(object parameter);


        //То, что должно быть выполнено самой командой.
        //Основная логика команды, которую она должна выполнять.
        public abstract void Execute(object parameter);

    }
}
