using System.Collections.ObjectModel;
using TarefasApp.Models;

namespace TarefasApp;

public partial class MainPage : ContentPage
{
    public ObservableCollection<Tarefa> Tarefas { get; set; }

    public MainPage()
    {
        InitializeComponent();
        Tarefas = new ObservableCollection<Tarefa>();
        TarefasCollection.ItemsSource = Tarefas;
    }

    // Navegação hierárquica passando o objeto Tarefa
    private async void OnTarefaSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Tarefa tarefaSelecionada)
        {
            await Navigation.PushAsync(new DetailsPage(tarefaSelecionada, Tarefas));
            TarefasCollection.SelectedItem = null; // Remove a seleção
        }
    }

    // Adição de tarefas abrindo um modal e passando a lista para ser preenchida
    private async void OnAdicionarClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new AddPage(Tarefas));
    }
}