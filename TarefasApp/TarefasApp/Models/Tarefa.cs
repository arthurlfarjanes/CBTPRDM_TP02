using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TarefasApp.Models;

public class Tarefa : INotifyPropertyChanged
{
    private string _titulo;
    private string _descricao;
    private DateTime _dataCriacao;
    private string _prioridade;

    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string Titulo
    {
        get => _titulo;
        set { _titulo = value; OnPropertyChanged(); }
    }

    public string Descricao
    {
        get => _descricao;
        set { _descricao = value; OnPropertyChanged(); }
    }

    public DateTime DataCriacao
    {
        get => _dataCriacao;
        set { _dataCriacao = value; OnPropertyChanged(); }
    }

    public string Prioridade
    {
        get => _prioridade;
        set { _prioridade = value; OnPropertyChanged(); }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}