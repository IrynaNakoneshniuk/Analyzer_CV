using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using Analyzer_CV.Commands;

public class MainModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
    private string[] _files;
    private string[] _selectedItem;
    private string _tbContext;
    public ResumeItems resumeItems = new ResumeItems();
    public FixedDocument fixedDocument;
    public ICommand loadAllResume { get; set; }
    public ICommand searchFiles { get; set; }
    public ICommand selectResult { get; set; }

    public MainModel()
    {
        loadAllResume = new LoadAllResume(this);
        searchFiles = new SearchFiles(this);
        selectResult = new SelectResult(this);
        Resume = new string[10];
        fixedDocument = new FixedDocument();
    }

    private string _path;
    public string Path
    {
        get { 
            return _path; ;
        }
        set {
            _path= value; 
            OnPropertyChanged(nameof(Path));
        } 
    }
    
    public FixedDocument FixedDocument
    {
        get { return fixedDocument; }
        set { fixedDocument = value; OnPropertyChanged(nameof(FixedDocument)); }
    }
    public string[] Resume { get; set; }
    public string TbContext
    {
        get { return _tbContext; }
        set
        {
            _tbContext= value;
            OnPropertyChanged(nameof(TbContext));
        }
    }
    public string[] Files
    {
        get { return _files; }
        set { _files = value; 
        OnPropertyChanged(nameof(Files));}
    }
    public string[] SelectedItem
    {
        get
        {
            return _selectedItem;
        }
        set
        {
            _selectedItem = value;
            OnPropertyChanged(nameof(SelectedItem));
        }
    }
   
}
