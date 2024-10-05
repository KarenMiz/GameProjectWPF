using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GameProjectWPF
{
    /// <summary>
    /// Interaction logic for CountriesData.xaml
    /// </summary>
    public partial class CountriesData : Window
    {
        public ObservableCollection<Country> Countries { get; set; } = new ObservableCollection<Country>();
        private ObservableCollection<Country> _allCountries = new ObservableCollection<Country>();

        public static HttpClient client = new HttpClient();
        public CountriesData()
        {
            InitializeComponent();
            LoadCountriesDataAsync();
        }
        private async Task LoadCountriesDataAsync()
        {
            try
            {
                string json = await client.GetStringAsync("https://restcountries.com/v3.1/all");

                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                // Deserialize the JSON into the ObservableCollection
                Countries = JsonSerializer.Deserialize<ObservableCollection<Country>>(json, options);

                if (Countries != null)
                {
                    foreach (Country c in Countries)
                    {
                        _allCountries.Add(c);
                    }

                    // Set the DataGrid's ItemSource
                    CountriesDataGrid.ItemsSource = Countries;
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the data fetching and deserialization process
                MessageBox.Show("Error loading countries data: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();
            List<Country> filteredCountries = _allCountries
                .Where(c => c.Name.Common.ToLower().Contains(searchText))
                .ToList();

            UpdateCountriesCollection(filteredCountries);
        }

        private void RegionFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedRegion = (RegionFilterComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            if (selectedRegion == "All Regions")
            {
                UpdateCountriesCollection(_allCountries.ToList());
            }
            else
            {
                List<Country> filteredCountries = _allCountries
                    .Where(c => c.Region.ToLower() == selectedRegion.ToLower())
                    .ToList();

                UpdateCountriesCollection(filteredCountries);
            }
        }



        private void UpdateCountriesCollection(List<Country> countries)
        {
            Countries.Clear();
            foreach (Country country in countries)
            {
                Countries.Add(country);
            }
        }

      
    }
}