using MaseratiTCC.Models;
using MaseratiTCC.ViewModels.Usuarios;

namespace MaseratiTCC.View.Options;

public partial class ManicureView : ContentPage
{
    UsuarioViewModel viewModel;
    public List<CarouselItem> CarouselItems { get; set; }
    public ManicureView()
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

    private void Label_SizeChanged(object sender, EventArgs e)
    {

    }

    private async void OnImageTapped2(object sender, EventArgs e)
    {
        var clickedImage = sender as ImageButton;
        if (clickedImage != null)
        {
            var clickedItem = clickedImage.BindingContext as CarouselItem;
            if (clickedItem != null && clickedItem.DestinationPage != null)
            {
                var destinationPage = (Page)Activator.CreateInstance(clickedItem.DestinationPage);
                await Navigation.PushAsync(destinationPage);
            }
        }
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