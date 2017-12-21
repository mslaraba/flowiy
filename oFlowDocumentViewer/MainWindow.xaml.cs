using CodeReason.Reports;
using Optim.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Xps.Packaging;

namespace oFlowDocumentViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Loaded += MainWindow_Loaded;
            ww = new WaitWorker(UpdatePreview, 0.5);
            tb_source.TextChanged += Tb_source_TextChanged;
            Closed += MainWindow_Closed;
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            File.WriteAllText(Tools.GetLocalFile("save.txt"), tb_source.Text);
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                tb_source.Text = File.ReadAllText(Tools.GetLocalFile("save.txt"));
            }
            catch
            {

            }
        }

        private void Tb_source_TextChanged(object sender, TextChangedEventArgs e)
        {
            ww.DoEvent();
        }

        WaitWorker ww;
        private void UpdatePreview()
        {

            try
            {

                ReportDocument reportDocument = new ReportDocument();

                reportDocument.XamlData = tb_source.Text;

                DateTime dateTimeStart = DateTime.Now; // start time measure here

                List<ReportData> listData = new List<ReportData>();

                ReportData data = new ReportData();


                listData.Add(data);


                XpsDocument xps = reportDocument.CreateXpsDocument(listData);
                fdViewer.Document = xps.GetFixedDocumentSequence();
                t_error.Text = "";
            }
            catch (Exception ex)
            {
                t_error.Text = ex.Message + Environment.NewLine + ex.StackTrace;
            }

        }

    }
}
