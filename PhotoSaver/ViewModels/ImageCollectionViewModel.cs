using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace PhotoSaver.ViewModels
{
    public class ImageCollectionViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ImageViewModel> ImagesCollection
        {
            get => imageCollection;
            set
            {
                if (value == imageCollection) return;

                imageCollection = value;
                OnPropertyChanged(nameof(ImageCollection));
            }
        }

        private ObservableCollection<ImageViewModel> imageCollection;


        public ImageCollectionViewModel()
        {
            imageCollection = new ObservableCollection<ImageViewModel>(
                new ImageCollection(ImageSeeker.GetImagesFromAppData()).Images.Select(
                    image => new ImageViewModel(image)));


            SaveButtonClickedCommand = new RelayCommand(
                param =>
                {
                    List<ImageViewModel> imgs = imageCollection.Where((p,q) => p.ImageSelected == true).ToList();
                    imgs.ForEach(p=>p.ImageSelected=false);

                    FileSaver.SavePhotos(imgs, "");
                });
        }




        public ICommand SaveButtonClickedCommand { get; set; }





        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
