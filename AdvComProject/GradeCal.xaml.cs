using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace AdvComProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GradeCal : Page
    {
        public GradeCal()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }

        private void grade1_click(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (grade1.SelectedItem == Item1)
                {
                    equiv1.Text = "4.0";
                }
                if (grade1.SelectedItem == Item2)
                {
                    equiv1.Text = "3.5";
                }
                if (grade1.SelectedItem == Item3)
                {
                    equiv1.Text = "3.0";
                }
                if (grade1.SelectedItem == Item4)
                {
                    equiv1.Text = "2.5";
                }
                if (grade1.SelectedItem == Item5)
                {
                    equiv1.Text = "2.0";
                }
                if (grade1.SelectedItem == Item6)
                {
                    equiv1.Text = "1.5";
                }
                if (grade1.SelectedItem == Item7)
                {
                    equiv1.Text = "1.0";
                }
                if (grade1.SelectedItem == Item8)
                {
                    equiv1.Text = "0.0";
                }

            }
            catch (NullReferenceException)
            {

            }

        }

        private void grade2_click(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (grade2.SelectedItem == Item11)
                {
                    equiv2.Text = "4.0";
                }
                if (grade2.SelectedItem == Item12)
                {
                    equiv2.Text = "3.5";
                }
                if (grade2.SelectedItem == Item13)
                {
                    equiv2.Text = "3.0";
                }
                if (grade2.SelectedItem == Item14)
                {
                    equiv2.Text = "2.5";
                }
                if (grade2.SelectedItem == Item15)
                {
                    equiv2.Text = "2.0";
                }
                if (grade2.SelectedItem == Item16)
                {
                    equiv2.Text = "1.5";
                }
                if (grade2.SelectedItem == Item17)
                {
                    equiv2.Text = "1.0";
                }
                if (grade2.SelectedItem == Item18)
                {
                    equiv2.Text = "0.0";
                }

            }
            catch (NullReferenceException)
            {

            }
        }

        private void grade3_click(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (grade3.SelectedItem == Item21)
                {
                    equiv3.Text = "4.0";
                }
                if (grade3.SelectedItem == Item22)
                {
                    equiv3.Text = "3.5";
                }
                if (grade3.SelectedItem == Item23)
                {
                    equiv3.Text = "3.0";
                }
                if (grade3.SelectedItem == Item24)
                {
                    equiv3.Text = "2.5";
                }
                if (grade3.SelectedItem == Item25)
                {
                    equiv3.Text = "2.0";
                }
                if (grade3.SelectedItem == Item26)
                {
                    equiv3.Text = "1.5";
                }
                if (grade3.SelectedItem == Item27)
                {
                    equiv3.Text = "1.0";
                }
                if (grade3.SelectedItem == Item28)
                {
                    equiv3.Text = "0.0";
                }

            }
            catch (NullReferenceException)
            {

            }
        }

        private void grade4_click(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (grade4.SelectedItem == Item31)
                {
                    equiv4.Text = "4.0";
                }
                if (grade4.SelectedItem == Item32)
                {
                    equiv4.Text = "3.5";
                }
                if (grade4.SelectedItem == Item33)
                {
                    equiv4.Text = "3.0";
                }
                if (grade4.SelectedItem == Item34)
                {
                    equiv4.Text = "2.5";
                }
                if (grade4.SelectedItem == Item35)
                {
                    equiv4.Text = "2.0";
                }
                if (grade4.SelectedItem == Item36)
                {
                    equiv4.Text = "1.5";
                }
                if (grade4.SelectedItem == Item37)
                {
                    equiv4.Text = "1.0";
                }
                if (grade4.SelectedItem == Item38)
                {
                    equiv4.Text = "0.0";
                }

            }
            catch (NullReferenceException)
            {

            }
        }

        private void grade5_click(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (grade5.SelectedItem == Item41)
                {
                    equiv5.Text = "4.0";
                }
                if (grade5.SelectedItem == Item42)
                {
                    equiv5.Text = "3.5";
                }
                if (grade5.SelectedItem == Item43)
                {
                    equiv5.Text = "3.0";
                }
                if (grade5.SelectedItem == Item44)
                {
                    equiv5.Text = "2.5";
                }
                if (grade5.SelectedItem == Item45)
                {
                    equiv5.Text = "2.0";
                }
                if (grade5.SelectedItem == Item46)
                {
                    equiv5.Text = "1.5";
                }
                if (grade5.SelectedItem == Item47)
                {
                    equiv5.Text = "1.0";
                }
                if (grade5.SelectedItem == Item48)
                {
                    equiv5.Text = "0.0";
                }

            }
            catch (NullReferenceException)
            {

            }
        }

        private void grade6_click(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (grade6.SelectedItem == Item51)
                {
                    equiv6.Text = "4.0";
                }
                if (grade6.SelectedItem == Item52)
                {
                    equiv6.Text = "3.5";
                }
                if (grade6.SelectedItem == Item53)
                {
                    equiv6.Text = "3.0";
                }
                if (grade6.SelectedItem == Item54)
                {
                    equiv6.Text = "2.5";
                }
                if (grade6.SelectedItem == Item55)
                {
                    equiv6.Text = "2.0";
                }
                if (grade6.SelectedItem == Item56)
                {
                    equiv6.Text = "1.5";
                }
                if (grade6.SelectedItem == Item57)
                {
                    equiv6.Text = "1.0";
                }
                if (grade6.SelectedItem == Item58)
                {
                    equiv6.Text = "0.0";
                }

            }
            catch (NullReferenceException)
            {

            }
        }

        private void addsubject1_textchange(object sender, TextChangedEventArgs e)
        {
            addsubject2.Visibility = Visibility.Visible;
            equiv6.Visibility = Visibility.Visible;
            credit6.Visibility = Visibility.Visible;
            grade6.Visibility = Visibility.Visible;
        }

        private void calculate_click(object sender, RoutedEventArgs e)
        {
            calculates();


        }



        private void grade7_click(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (grade7.SelectedItem == Item61)
                {
                    equiv7.Text = "4.0";
                }
                if (grade7.SelectedItem == Item62)
                {
                    equiv7.Text = "3.5";
                }
                if (grade7.SelectedItem == Item63)
                {
                    equiv7.Text = "3.0";
                }
                if (grade7.SelectedItem == Item64)
                {
                    equiv7.Text = "2.5";
                }
                if (grade7.SelectedItem == Item65)
                {
                    equiv7.Text = "2.0";
                }
                if (grade7.SelectedItem == Item66)
                {
                    equiv7.Text = "1.5";
                }
                if (grade7.SelectedItem == Item67)
                {
                    equiv7.Text = "1.0";
                }
                if (grade7.SelectedItem == Item68)
                {
                    equiv7.Text = "0.0";
                }

            }
            catch (NullReferenceException)
            {

            }
        }

        private void addsubject2_textchange(object sender, TextChangedEventArgs e)
        {
            addsubject3.Visibility = Visibility.Visible;
            equiv7.Visibility = Visibility.Visible;
            grade7.Visibility = Visibility.Visible;
            credit7.Visibility = Visibility.Visible;
        }
        private void calculates()
        {
            int count = 0;
            if (equiv1.Visibility == Visibility.Visible)
            {
                count += 1;
            } if (equiv2.Visibility == Visibility.Visible)
            {
                count += 1;
            } if (equiv3.Visibility == Visibility.Visible)
            {
                count += 1;
            } if (equiv4.Visibility == Visibility.Visible)
            {
                count += 1;
            } if (equiv5.Visibility == Visibility.Visible)
            {
                count += 1;
            } if (equiv6.Visibility == Visibility.Visible)
            {
                count += 1;
            } if (equiv7.Visibility == Visibility.Visible)
            {
                count += 1;
            } if (count == 1)
            {
                double x = double.Parse(equiv1.Text, CultureInfo.InvariantCulture);
                int xx = int.Parse(((ComboBoxItem)credit1.SelectedItem).Content.ToString());

                double result = (x * xx) / (xx);
                avggrade.Text = result.ToString();
            }
            if (count == 2)
            {
                double x = double.Parse(equiv1.Text, CultureInfo.InvariantCulture);
                double y = double.Parse(equiv2.Text, CultureInfo.InvariantCulture);
                int xx = int.Parse(((ComboBoxItem)credit1.SelectedItem).Content.ToString());
                int yy = int.Parse(((ComboBoxItem)credit2.SelectedItem).Content.ToString());

                double result = ((x * xx) + (y * yy)) / (xx + yy);
                avggrade.Text = result.ToString();
            }
            if (count == 3)
            {
                double x = double.Parse(equiv1.Text, CultureInfo.InvariantCulture);
                double y = double.Parse(equiv2.Text, CultureInfo.InvariantCulture);
                double z = double.Parse(equiv3.Text, CultureInfo.InvariantCulture);
                //Debug.WriteLine(((ComboBoxItem)credit1.SelectedItem).Content.ToString());
                int xx = int.Parse(((ComboBoxItem)credit1.SelectedItem).Content.ToString());
                int yy = int.Parse(((ComboBoxItem)credit2.SelectedItem).Content.ToString());
                int zz = int.Parse(((ComboBoxItem)credit3.SelectedItem).Content.ToString());

                double result = (((x * xx) + (y * yy) + (z * zz)) / (xx + yy + zz));

                avggrade.Text = result.ToString();
            }
            if (count == 4)
            {

                double x = double.Parse(equiv1.Text, CultureInfo.InvariantCulture);
                double y = double.Parse(equiv2.Text, CultureInfo.InvariantCulture);
                double z = double.Parse(equiv3.Text, CultureInfo.InvariantCulture);
                double a = double.Parse(equiv4.Text, CultureInfo.InvariantCulture);

                int xx = int.Parse(((ComboBoxItem)credit1.SelectedItem).Content.ToString());
                int yy = int.Parse(((ComboBoxItem)credit2.SelectedItem).Content.ToString());
                int zz = int.Parse(((ComboBoxItem)credit3.SelectedItem).Content.ToString());
                int aa = int.Parse(((ComboBoxItem)credit4.SelectedItem).Content.ToString());

                double result = ((x * xx) + (y * yy) + (z * zz) + (a * aa)) / (xx + yy + zz + aa);
                avggrade.Text = result.ToString();
            } if (count == 5)
            {
                double x = double.Parse(equiv1.Text, CultureInfo.InvariantCulture);
                double y = double.Parse(equiv2.Text, CultureInfo.InvariantCulture);
                double z = double.Parse(equiv3.Text, CultureInfo.InvariantCulture);
                double a = double.Parse(equiv4.Text, CultureInfo.InvariantCulture);
                double b = double.Parse(equiv5.Text, CultureInfo.InvariantCulture);

                int xx = int.Parse(((ComboBoxItem)credit1.SelectedItem).Content.ToString());
                int yy = int.Parse(((ComboBoxItem)credit2.SelectedItem).Content.ToString());
                int zz = int.Parse(((ComboBoxItem)credit3.SelectedItem).Content.ToString());
                int aa = int.Parse(((ComboBoxItem)credit4.SelectedItem).Content.ToString());
                int bb = int.Parse(((ComboBoxItem)credit5.SelectedItem).Content.ToString());

                double result = ((x * xx) + (y * yy) + (z * zz) + (a * aa) + (b * bb)) / (xx + yy + zz + aa + bb);
                avggrade.Text = result.ToString();


            } if (count == 6)
            {
                double x = double.Parse(equiv1.Text, CultureInfo.InvariantCulture);
                double y = double.Parse(equiv2.Text, CultureInfo.InvariantCulture);
                double z = double.Parse(equiv3.Text, CultureInfo.InvariantCulture);
                double a = double.Parse(equiv4.Text, CultureInfo.InvariantCulture);
                double b = double.Parse(equiv5.Text, CultureInfo.InvariantCulture);
                double c = double.Parse(equiv6.Text, CultureInfo.InvariantCulture);

                int xx = int.Parse(((ComboBoxItem)credit1.SelectedItem).Content.ToString());
                int yy = int.Parse(((ComboBoxItem)credit2.SelectedItem).Content.ToString());
                int zz = int.Parse(((ComboBoxItem)credit3.SelectedItem).Content.ToString());
                int aa = int.Parse(((ComboBoxItem)credit4.SelectedItem).Content.ToString());
                int bb = int.Parse(((ComboBoxItem)credit5.SelectedItem).Content.ToString());
                int cc = int.Parse(((ComboBoxItem)credit6.SelectedItem).Content.ToString());

                double result = (((x * xx) + (y * yy) + (z * zz) + (a * aa) + (b * bb) + (c * cc))) / (xx + yy + zz + aa + bb + cc);
                avggrade.Text = result.ToString();
            } if (count == 7)
            {
                double x = double.Parse(equiv1.Text, CultureInfo.InvariantCulture);
                double y = double.Parse(equiv2.Text, CultureInfo.InvariantCulture);
                double z = double.Parse(equiv3.Text, CultureInfo.InvariantCulture);
                double a = double.Parse(equiv4.Text, CultureInfo.InvariantCulture);
                double b = double.Parse(equiv5.Text, CultureInfo.InvariantCulture);
                double c = double.Parse(equiv6.Text, CultureInfo.InvariantCulture);
                double d = double.Parse(equiv7.Text, CultureInfo.InvariantCulture);

                int xx = int.Parse(((ComboBoxItem)credit1.SelectedItem).Content.ToString());
                int yy = int.Parse(((ComboBoxItem)credit2.SelectedItem).Content.ToString());
                int zz = int.Parse(((ComboBoxItem)credit3.SelectedItem).Content.ToString());
                int aa = int.Parse(((ComboBoxItem)credit4.SelectedItem).Content.ToString());
                int bb = int.Parse(((ComboBoxItem)credit5.SelectedItem).Content.ToString());
                int cc = int.Parse(((ComboBoxItem)credit6.SelectedItem).Content.ToString());
                int dd = int.Parse(((ComboBoxItem)credit7.SelectedItem).Content.ToString());

                double result = ((x * xx) + (y * yy) + (z * zz) + (a * aa) + (b * bb) + (c * cc) + (d * dd)) / (xx + yy + zz + aa + bb + cc + dd);
                avggrade.Text = result.ToString();
            }
        }

        private void subject1_textchange(object sender, TextChangedEventArgs e)
        {

            subject2.Visibility = Visibility.Visible;
            credit2.Visibility = Visibility.Visible;
            grade2.Visibility = Visibility.Visible;
            equiv2.Visibility = Visibility.Visible;
        }



        private void subject2_textchange(object sender, TextChangedEventArgs e)
        {
            subject3.Visibility = Visibility.Visible;
            credit3.Visibility = Visibility.Visible;
            grade3.Visibility = Visibility.Visible;
            equiv3.Visibility = Visibility.Visible;
        }

        private void subject3_textchange(object sender, TextChangedEventArgs e)
        {
            subject4.Visibility = Visibility.Visible;
            credit4.Visibility = Visibility.Visible;
            grade4.Visibility = Visibility.Visible;
            equiv4.Visibility = Visibility.Visible;

        }

        private void subject4_textchange(object sender, TextChangedEventArgs e)
        {
            addsubject1.Visibility = Visibility.Visible;
            credit5.Visibility = Visibility.Visible;
            grade5.Visibility = Visibility.Visible;
            equiv5.Visibility = Visibility.Visible;
        }

        private void back_button(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(HubPage));
        }
    }
}
