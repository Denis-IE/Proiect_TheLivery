using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
using AutoLotModel;

namespace TheLiveryDesktop2._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    enum ActionState
    {
        New,
        Delete,
        Nothing
    }
    public partial class MainWindow : Window
    {
        ActionState action = ActionState.Nothing;
        AutoLotEntitiesModel ctx = new AutoLotEntitiesModel();
        CollectionViewSource curieriVSource;
        CollectionViewSource firmaVSource;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void richTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnAddCurieri_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.New;
            SaveCurieri();
        }

        private void btnAddFirma_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.New;
            SaveFirma();
        }

        private void btnDeleteCurieri_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.Delete;
            SaveCurieri();
        }

        private void btnDeleteFirma_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.Delete;
            SaveFirma();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            curieriVSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("curieriViewSource")));
            curieriVSource.Source = ctx.Curieris.Local;
            ctx.Curieris.Load();

            firmaVSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("firmaViewSource")));
            firmaVSource.Source = ctx.Firmas.Local;
            ctx.Firmas.Load();
            System.Windows.Data.CollectionViewSource curieriViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("curieriViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // curieriViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource firmaViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("firmaViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // firmaViewSource.Source = [generic data source]
        }

        private void SaveCurieri()
        {
            Curieri curier = null;
            if (action == ActionState.New)
            {
                try
                {
                    //instantiem Customer entity
                    curier = new Curieri()
                    {
                        Id = int.Parse(idCurierBox.Text),
                        Nume_complet = numeCurierBox.Text.Trim(),
                        Parola = passwordBox.Text.Trim(),
                        Email = emailCurierBox.Text.Trim(),
                        Telefon = int.Parse(telefonCurierBox.Text),
                        Locatie = locatieCurierBox.Text.Trim()
                    };
                    //adaugam entitatea nou creata in context
                    ctx.Curieris.Add(curier);
                    curieriVSource.View.Refresh();
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                //using System.Data;
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    curier = (Curieri)curieriDataGrid.SelectedItem;
                    ctx.Curieris.Remove(curier);
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                curieriVSource.View.Refresh();
            }
        }
        private void SaveFirma()
        {
            Firma firma = null;
            if (action == ActionState.New)
            {
                try
                {
                    //instantiem Customer entity
                    firma = new Firma()
                    {
                        Id = int.Parse(idFirmaBox.Text),
                        Nume = numeFirmaBox.Text.Trim(),
                        Adresa = locatieFirmaBox.Text.Trim(),
                    };
                    //adaugam entitatea nou creata in context
                    ctx.Firmas.Add(firma);
                    firmaVSource.View.Refresh();
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                //using System.Data;
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    firma = (Firma)firmaDataGrid.SelectedItem;
                    ctx.Firmas.Remove(firma);
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                firmaVSource.View.Refresh();
            }

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}
