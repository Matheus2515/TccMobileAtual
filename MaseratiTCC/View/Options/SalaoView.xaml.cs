using MaseratiTCC.Models;
using MaseratiTCC.ViewModels.Usuarios;
using System;
using System.Collections.Generic;

namespace MaseratiTCC.View.Options
{
    public partial class SalaoView : ContentPage
    {
        UsuarioViewModel viewModel;
        public List<CarouselItem> CarouselItems { get; set; }
        private StackLayout ratingStackLayout;

        public SalaoView()
        {
            InitializeComponent();
            viewModel = new UsuarioViewModel();
            BindingContext = viewModel;
            CarouselItems = new List<CarouselItem>
        {
            new CarouselItem { ImagePath = "embreve.png", Description = "Em Breve", Avaliacao = 3 },
            new CarouselItem { ImagePath = "embreve.png", Description = "Outra Descrição", Avaliacao = 4 },
            new CarouselItem { ImagePath = "embreve.png", Description = "Alguma Descrição", Avaliacao = 2 }
        };

            carouselView.ItemsSource = CarouselItems;

            ratingStackLayout = new StackLayout();

            for (int i = 0; i < 5; i++)
            {
                Image starImage = new Image();
                ratingStackLayout.Children.Add(starImage);
            }

            carouselView.PositionChanged += CarouselView_PositionChanged;
        }

        private void UpdateRatingStars(double rating)
        {
            for (int i = 0; i < ratingStackLayout.Children.Count; i++)
            {
                if (ratingStackLayout.Children[i] is Image starImage)
                {
                    if (i < Math.Floor(rating))
                    {
                        starImage.Source = "estrela.png";
                    }
                    else if (i == Math.Floor(rating) && rating % 1 != 0)
                    {
                        starImage.Source = "estrela_meia.png";
                    }
                    else
                    {
                        starImage.Source = "estrelan.png";
                    }
                }
            }
        }

        private void CarouselView_PositionChanged(object sender, PositionChangedEventArgs e)
        {
            if (carouselView.Position >= 0 && carouselView.Position < CarouselItems.Count)
            {
                var selectedItem = CarouselItems[carouselView.Position];
                UpdateRatingStars(selectedItem.Avaliacao);
            }
        }

        private void OnImageTapped4(object sender, EventArgs e)
        {
        }

        private void OnPreviousButtonClicked(object sender, EventArgs e)
        {
            carouselView.Position = (carouselView.Position - 1 + CarouselItems.Count) % CarouselItems.Count;
        }

        private void OnNextButtonClicked(object sender, EventArgs e)
        {
            carouselView.Position = (carouselView.Position + 1) % CarouselItems.Count;
        }

        private void OnSearchButtonPressed(object sender, EventArgs e)
        {
        }
    }




}
