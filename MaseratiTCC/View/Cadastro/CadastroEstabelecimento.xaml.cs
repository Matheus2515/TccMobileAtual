namespace MaseratiTCC.View.Cadastro;

public partial class CadastroEstabelecimento : ContentPage
{
	public CadastroEstabelecimento()
	{
		InitializeComponent();
	}

    private void btnVoltar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new TipoCadastro());
    }

    private void btnAvancar_Clicked(object sender, EventArgs e)
    {

    }
}