using TarefasApp.Models;

namespace TarefasApp;

public partial class EditPage : ContentPage
{
    private Tarefa _tarefa;

    // Passagem de dados para o modal preencher os campos de edição
    public EditPage(Tarefa tarefa)
    {
        InitializeComponent();
        _tarefa = tarefa;

        // Preenche os dados atuais
        TituloEntry.Text = _tarefa.Titulo;
        DescricaoEditor.Text = _tarefa.Descricao;
        PrioridadePicker.SelectedItem = _tarefa.Prioridade;
    }

    private async void OnSalvarClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TituloEntry.Text))
        {
            await DisplayAlert("Erro", "O título não pode ficar vazio.", "OK");
            return;
        }

        // Atualiza os valores do objeto instanciado
        _tarefa.Titulo = TituloEntry.Text;
        _tarefa.Descricao = DescricaoEditor.Text;
        _tarefa.Prioridade = PrioridadePicker.SelectedItem?.ToString();

        await Navigation.PopModalAsync();
    }

    private async void OnCancelarClicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}