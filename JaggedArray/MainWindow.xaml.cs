using System;
using System.IO;
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

namespace JaggedArray
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double avg;
        int highest;
        int lowest;
        int lbllowest, lblhighest;
        string[] section1 = File.ReadAllLines("Section1.txt");
        string[] section2 = File.ReadAllLines("Section2.txt");
        string[] section3 = File.ReadAllLines("Section3.txt");
        int[][] jagged = new int[3][];
        public MainWindow()
        {
            InitializeComponent();                                      // storage the files into a jagged container (array) and convertr it to int
            int[] section1Int = Array.ConvertAll(section1, int.Parse);
            int[] section2Int = Array.ConvertAll(section2, int.Parse);
            int[] section3Int = Array.ConvertAll(section3, int.Parse);

            jagged[0] = section1Int;
            jagged[1] = section2Int;
            jagged[2] = section3Int;

            //get the average for each section

            //double section1AVG = jagged[0].Take(jagged[0].Length).Average();
            //lblavg1.Content = "Average Sect1: "+ section1AVG;

            //double section2AVG = jagged[1].Take(jagged[1].Length).Average();
            //lblavg2.Content = "Average Sect1: " + section2AVG;

            //double section3AVG = jagged[2].Take(jagged[2].Length).Average();
            //lblavg3.Content = "Average Sect1: " + section3AVG;

            double[] test = new double[3];
            string average = " ";
            for (int i = 0; i < 3; i++)
            {
                test[i] = jagged[i].Average();
                average += " Avg of SECTION " + (i + 1) + " is " + test[i] + ".";
            }
            lblavg1.Content = average;


            //populating the listbox

            for (int i = 0; i < jagged[0].Length; i++)
            {
                lsbSect1.Items.Add(jagged[0][i].ToString());
            }
            for (int i = 0; i < jagged[1].Length; i++)
            {
                lsbSect2.Items.Add(jagged[1][i].ToString());
            }
            for (int i = 0; i < jagged[2].Length; i++)
            {
                lsbSect3.Items.Add(jagged[2][i].ToString());
            }

            //Calc Total AVG

            double total = jagged[0].Sum() + jagged[1].Sum() + jagged[2].Sum();
            double count = jagged[0].Length + jagged[1].Length + jagged[2].Length;
            avg = total / count;

            for (int i = 0; i < jagged.Length; i++)
            {
                total += jagged[i].Sum();
                count += jagged[i].Length;
            }
            avg = total / count;

            //calc the highest score 

            int[] sectmax = new int[3];
            int[] sectmax2 = new int[3];
            for (int i = 0; i < jagged.Length; i++)
            {
                sectmax2[i] = jagged[i].Max();
            }

            highest = sectmax2.Max();

            sectmax[0] = jagged[0].Max();
            sectmax[1] = jagged[1].Max();
            sectmax[2] = jagged[2].Max();

            highest = sectmax.Max();

            lblhighest = 1 + (Array.IndexOf(sectmax2, highest));

            //CALC Tthe minimum score

            //int[] sectmin = new int[3];
            // sectmin[0] = jagged[0].Min();
            // sectmin[1] = jagged[1].Min();
            // sectmin[2] = jagged[2].Min();

            //int[] sectmin = new int[3];
            int[] sectmin2 = new int[3];
            for (int i = 0; i < jagged.Length; i++)
            {
                sectmin2[i] = jagged[i].Min();
            }

            lowest = sectmin2.Min();

            lbllowest = 1 + (Array.IndexOf(sectmin2, lowest));



            //      //OUTPUT 

            //      // if (sectmax[0] == highest)
            //      {
            //          //       highestSection = "Section 1";
            //      }
            //      // else if (sectmax[1] == highest)
            //      {
            //          //      highestSection = "Section 2";
            //      }
            //      //  else
            //      //      highestSection = "Section 3";

            //      //output the lowest section-score

            //      //  if (sectmin[0] == lowest)
            //      {
            //          //       lowestSection = "Section 1";
            //      }
            //      //   else if (sectmin[1] == lowest)
            //      {
            //          //        lowestSection = "Section 2";
            //      }
            //      //    else
            //  // lowestSection = "Section 3";

        }
        private void btnAVG_Click(object sender, RoutedEventArgs e)
        {
            lblAvgAll.Content = Math.Round(avg,2);
        }

        private void btnHigst_Click(object sender, RoutedEventArgs e)
        {
            lblHighest.Content = highest + "- SECTION " + lblhighest;
        }

        private void btnLwst_Click(object sender, RoutedEventArgs e)
        {
            lblLowest.Content = lowest +  "-" +lbllowest;
        }
    }
}
