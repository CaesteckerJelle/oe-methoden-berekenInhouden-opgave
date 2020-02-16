using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BerekenInhouden.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const double Getal_Pi = Math.PI;

        public MainWindow()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            VerbergGrids();
        }

        #region Methods
        private void VerbergGrids()
        {
            grdBalk.Visibility = Visibility.Hidden;
            grdCilinder.Visibility = Visibility.Hidden;
        }
        private void ToonGrid(Grid welkeGrid)
        {
            grdHoogte.Visibility = Visibility.Visible;
            welkeGrid.Visibility = Visibility.Visible;
            welkeGrid.Margin = new Thickness(10, 133, 0, 0);
            if (welkeGrid == grdBalk)
            {
                grdCilinder.Visibility = Visibility.Hidden;
            }
            else
            {
                grdBalk.Visibility = Visibility.Hidden;
            }
        }
        private void WisInputEnBerekeningen()
        {
            txtBreedte.Text = "";
            txtDiameter.Text = "";
            txtHoogte.Text = "";
            txtLengte.Text = "";
            tbkBerekeningBalk.Text = "";
            tbkBerekeningCilinder.Text = "";
        }
        private int GeefInhoudBalk(int hoogte, int breedte, int lengte)
        {
            int inhoudBalk;
            inhoudBalk = hoogte * breedte * lengte;
            return inhoudBalk;
        }
        private float GeefInhoudCilinder(int hoogte, double diameter)
        {
            float inhoudCilinder;
            inhoudCilinder = (float)(hoogte * Math.Pow((diameter / 2), 2) * Getal_Pi);
            return inhoudCilinder;
        }
        #endregion

        #region EventHandlers
        private void btnBalk_Click(object sender, RoutedEventArgs e)
        {
            ToonGrid(grdBalk);
            WisInputEnBerekeningen();
        }
        private void btnBerekenBalk_Click(object sender, RoutedEventArgs e)
        {
            int hoogte;
            int breedte;
            int lengte;
            hoogte = int.Parse(txtHoogte.Text);
            breedte = int.Parse(txtBreedte.Text);
            lengte = int.Parse(txtLengte.Text);

            int inhoudBalk = GeefInhoudBalk(hoogte, breedte, lengte);
            tbkBerekeningBalk.Text = $"De inhoud van de balk is {inhoudBalk}.";
        }
        private void btnCilinder_Click(object sender, RoutedEventArgs e)
        {
            ToonGrid(grdCilinder);
            WisInputEnBerekeningen();
        }
        private void btnBerekenCilinder_Click(object sender, RoutedEventArgs e)
        {
            int hoogte;
            double diameter;
            hoogte = int.Parse(txtHoogte.Text);
            diameter = double.Parse(txtDiameter.Text);

            float inhoudCilinder = GeefInhoudCilinder(hoogte, diameter);
            tbkBerekeningCilinder.Text = $"De inhoud van de cilinder is {inhoudCilinder}.";
        }
        #endregion
    }
}
