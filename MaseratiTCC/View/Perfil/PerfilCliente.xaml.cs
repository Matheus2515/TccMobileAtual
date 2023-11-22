using MaseratiTCC.View.Login;
using MaseratiTCC.ViewModels.Usuarios;

namespace MaseratiTCC.View.Perfil;

public partial class PerfilCliente : ContentPage
{
    UsuarioViewModel viewModel;

    public PerfilCliente()
	{
		InitializeComponent();
        viewModel = new UsuarioViewModel();
        BindingContext = viewModel;
    }


    private void btnSair_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new LoginView());
    }

   private async void OnAlterarFotoClicked(object sender, EventArgs e)
    {
        try
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                FileTypes = FilePickerFileType.Images,
                PickerTitle = "Selecione uma imagem"
            });

            if (result != null)
            {
                using (var stream = await result.OpenReadAsync())
                {
                    var bytes = new byte[stream.Length];
                    await stream.ReadAsync(bytes, 0, (int)stream.Length);

                    profileImageButton.Source = ImageSource.FromStream(() => new MemoryStream(bytes));
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao selecionar a imagem: {ex.Message}");
        }
    }


    private void OnEmailImageTapped(object sender, TappedEventArgs e)
    {
        txtExemplo.IsEnabled = true;
    }

    private void OnNumeroImageTapped(object sender, TappedEventArgs e)
    {
        txtNumero.IsEnabled = true;
    }

    private void OnSenhaImageTapped(object sender, TappedEventArgs e)
    {
        txtSenha.IsEnabled = true;
    }
}