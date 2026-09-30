using System.Collections.ObjectModel;
using TarefasApp.Models;

namespace TarefasApp;

public partial class DetailsPage : ContentPage
{
    private Tarefa _tarefa;
    private ObservableCollection<Tarefa> _tarefas;

    // Recebe a tarefa selecionada e a lista completa (para exclusão)
    public DetailsPage(Tarefa tarefa, ObservableCollection<Tarefa> tarefas)
    {
        InitializeComponent();
        _tarefa = tarefa;
        _tarefas = tarefas;
        BindingContext = _tarefa; // Vincula os dados para a interface
    }

    // Modal de edição
    private async void OnEditarClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new EditPage(_tarefa));
    }

    // Diálogo de confirmação para excluir
    private async void OnExcluirClicked(object sender, EventArgs e)
    {
        bool confirmacao = await DisplayAlert("Excluir Tarefa", "Você realmente deseja excluir esta tarefa?", "Sim", "Não");
        if (confirmacao)
        {
            _tarefas.Remove(_tarefa);
            await Navigation.PopAsync(); // Volta para a MainPage
        }
    }
}