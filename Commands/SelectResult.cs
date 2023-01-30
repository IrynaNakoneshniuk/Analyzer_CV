using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.IO.Packaging;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Xps.Packaging;
using System.Threading;
using System.Windows;

namespace Analyzer_CV.Commands
{
    public class SelectResult : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        public MainModel mainModel { get; set; }
        public bool CanExecute(object? parameter)
        {
            return true;
        }
        public SelectResult(MainModel mainModel)
        {
            this.mainModel = mainModel;
        }

        public async void Execute(object? parameter)
        {
            try
            {
                PageContent pageContent = new PageContent();
                FixedPage fixedPage = new FixedPage();
                TextBlock tb = new TextBlock();
                List<string> tmp = new List<string>();
                foreach (string item in mainModel.Resume)
                {
                    if (item != null)
                    {
                        item.Replace('\n', ' ');
                        item.Replace('\r', ' ');
                        tmp.Add(item);
                    }
                }
                if (parameter.ToString() == "rbExp")
                {
                    tb.Text = (from i in tmp.AsParallel()
                               where i.Contains(mainModel.resumeItems.Expirient.Min().ToString())
                               select i).FirstOrDefault();
                }
                else if (parameter.ToString() == "rbLowExp")
                {
                    tb.Text = (from i in tmp.AsParallel()
                               where i.Contains(mainModel.resumeItems.Expirient.Max().ToString())
                               select i).FirstOrDefault();
                }
                else if (parameter.ToString() == "rbHSalary")
                {

                    tb.Text = (from i in tmp.AsParallel()
                               where i.Contains(mainModel.resumeItems.Salary.Max().ToString())
                               select i).FirstOrDefault();

                }
                else if (parameter.ToString() == "rbLSalary")
                {
                    tb.Text = (from i in tmp.AsParallel()
                               where i.Contains(mainModel.resumeItems.Salary.Min().ToString())
                               select i).FirstOrDefault();
                }
                      ((IAddChild)fixedPage).AddChild(tb);
                ((IAddChild)pageContent).AddChild(fixedPage);
                ((IAddChild)mainModel.FixedDocument).AddChild(pageContent);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
