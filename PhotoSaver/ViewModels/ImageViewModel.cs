using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PhotoSaver.ViewModels
{
    public class ImageViewModel : INotifyPropertyChanged
    {

        #region Public Properties

        public ImageSource ImageSource
        {
            get => imageSource;

        }

        public bool ImageSelected
        {
            get => imageSelected;
            set
            {
                if (value != imageSelected)
                {
                    imageSelected = value;
                    OnPropertyChanged(nameof(ImageSelected));
                }
            }
        }

        #endregion

        #region Private Members

        private ImageSource imageSource;

        private bool imageSelected;

        #endregion

        #region Constructors

        public ImageViewModel()
        {
            imageSource = new BitmapImage(new Uri(new FileInfo(Environment.ExpandEnvironmentVariables("%AppData%") + "\\..\\Local\\Packages\\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\\LocalState\\Assets\\944c1cd97389f17384f9ef0511d165279253af51610bee9dfc35db326a9db2cb").FullName));

        }

        public ImageViewModel(Image image)
        {
            imageSource = new BitmapImage(new Uri(image.ImagePath));
            imageSelected = false;

            ImageSelectedCommand = new RelayCommand(param =>
            {
                ((ImageViewModel)param).ImageSelected ^= true;
            });
        }

        #endregion

        #region Commands

        /// <summary>
        /// Toggle ImageSelect value
        /// </summary>
        public ICommand ImageSelectedCommand { get; set; }

        /// <summary>
        /// Displays selected photo in full resolution
        /// </summary>
        public ICommand ShowImageCommand { get; set; }

        #endregion

        #region PropertyChanged Stuff

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
