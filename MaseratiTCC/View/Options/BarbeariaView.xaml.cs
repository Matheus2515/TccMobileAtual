using MaseratiTCC.Models;
using MaseratiTCC.ViewModels.Usuarios;

namespace MaseratiTCC.View.Options;

public partial class BarbeariaView : ContentPage
{

    UsuarioViewModel viewModel;
    public List<CarouselItem> CarouselItems { get; set; }
    public BarbeariaView()
	{
		InitializeComponent();
        viewModel = new UsuarioViewModel();
        BindingContext = viewModel;
        CarouselItems = new List<CarouselItem>
        {
            new CarouselItem { ImagePath = "embreve.png", Description = "Em Breve",},
            new CarouselItem { ImagePath = "embreve.png", Description = "Em Breve",},
            new CarouselItem { ImagePath = "embreve.png", Description = "Em Breve",}
        };

        carouselView.ItemsSource = CarouselItems;

    }
   
    private void OnImageTapped3(object sender, EventArgs e)
    {

    }

    private int currentIndex = 0;
    private void OnPreviousButtonClicked(object sender, EventArgs e)
    {
        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = CarouselItems.Count - 1;
        }
        carouselView.Position = currentIndex;
    }

    private void OnNextButtonClicked(object sender, EventArgs e)
    {
        currentIndex++;
        if (currentIndex >= CarouselItems.Count)
        {
            currentIndex = 0;
        }
        carouselView.Position = currentIndex;
    }

    private void OnSearchButtonPressed(object sender, EventArgs e)
    {

    }
}