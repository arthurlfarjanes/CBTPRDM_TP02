using System.Collections.ObjectModel;
using TarefasApp.Models;

namespace TarefasApp;

public partial class AddPage : ContentPage
{
    private ObservableCollection<Tarefa> _tarefas;

    // Recebe a lista para passagem de dados[cite: 5]
    public AddPage(ObservableCollection<Tarefa> tarefas)
    {
        InitializeComponent();
        _tarefas = tarefas;
        PrioridadePicker.SelectedIndex = 1; // Média por padrão
    }

    private async void OnSalvarClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TituloEntry.Text))
        {
            await DisplayAlert("Erro", "O título é obrigatório.", "OK");
            return;
        }

        var novaTarefa = new Tarefa
        {
            Titulo = TituloEntry.Text,
            Descricao = DescricaoEditor.Text,
            DataCriacao = DateTime.Now,
            Prioridade = PrioridadePicker.SelectedItem?.ToString() ?? "Média"
        };

        _tarefas.Add(novaTarefa);
        await Navigation.PopModalAsync();
    }

    private async void OnCancelarClicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}