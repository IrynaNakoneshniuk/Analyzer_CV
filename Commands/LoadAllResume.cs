using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Analyzer_CV.Commands
{
    public class LoadAllResume : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        public MainModel mainModel { get; set; }
        public LoadAllResume(MainModel mainModel)
        {
            this.mainModel = mainModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
        {
            try
            {
                int counter = 0;
                await Task.Run(async () => {
                    foreach (string s in mainModel.Files)
                    {
                        mainModel.Resume[counter] = await File.ReadAllTextAsync(s);
                        string[] tmp = mainModel.Resume[counter].Split('\r', '\n', ' ');
                        int indexExp = tmp.ToList().FindIndex(i => i.Equals("Expirient:"));
                        if (indexExp >= 0)
                        {
                            mainModel.resumeItems.Expirient.Add(Convert.ToInt32(tmp[indexExp + 1]));
                        }
                        int indexSalary = tmp.ToList().FindIndex(i => i.Equals("Salary:"));
                        if (indexSalary >= 0)
                        {
                            mainModel.resumeItems.Salary.Add(Convert.ToInt32(tmp[indexSalary + 1]));
                        }
                        if (tmp.ToList().FindIndex(i => i.Equals("Sity:")) >= 0)
                        {
                            mainModel.resumeItems.Sity.Add(tmp[tmp.ToList().FindIndex(i => i.Equals("Sity:")) + 1]);
                        }
                        counter++;
                    }
                });
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
