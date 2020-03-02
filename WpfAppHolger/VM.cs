using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace WpfAppHolger
{
  public class VM : INotifyPropertyChanged
  {
    public ActionCommand LoadCommand { get; set; }
    public ActionCommand AddCommand { get; set; }

    private ObservableCollection<Task> tasks;

    public ObservableCollection<Task> Tasks
    {
      get { return tasks; }
      set { tasks = value; OnPropertyChanged(); }
    }

    public VM()
    {
      LoadCommand = new ActionCommand(Load);
      AddCommand = new ActionCommand(Add);
    }

    private void Add()
    {
      Tasks?.Add(new Task { Name = "C", Details = "c1" });
    }

    private void Load()
    {
      var t = new List<Task> { new Task { Name = "a", Details = "a1" }, new Task { Name = "b", Details = "b1" } };
      Tasks = new ObservableCollection<Task>(t);
    }

    protected void OnPropertyChanged([CallerMemberName]string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    public event PropertyChangedEventHandler PropertyChanged;
  }
}
