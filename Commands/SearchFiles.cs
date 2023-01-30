using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Analyzer_CV.Commands
{
    public class SearchFiles : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        public MainModel mainModel { get; set; }
        public SearchFiles(MainModel mainModel) {
            this.mainModel = mainModel;
        }
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (Directory.Exists(mainModel.Path))
            {
                mainModel.Files = Directory.GetFiles(mainModel.Path);
            }
        }
    }
}
