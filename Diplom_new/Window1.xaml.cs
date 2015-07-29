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
using System.Windows.Shapes;

namespace Diplom_new
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Calculate();
        }

        private void Calculate()
        {



            double k_t = 0;
            double f_max = 0;
            double f_min = 0;
            double A = 0;
            double k_et = 0;
            int N = 0;

            try
            {
                f_max = Convert.ToDouble(tb_fmax.Text);
                f_min = Convert.ToDouble(tb_fmin.Text);
                A = Convert.ToDouble(tb_A.Text);
                k_et = Convert.ToDouble(tb_Ket.Text);
            }
            catch
            {
                f_max = 0;
                f_min = 0;
                A = 0;
                k_et = 0;
            }

            double f_min_i = 0;
            double f_max_i = 0;

            #region variant 1
            if (cb_variant.SelectedIndex == 0)
            {
                k_t = f_max/f_min;

                try
                {
                    N = Convert.ToInt16(Math.Log10(k_t)/Math.Log10(k_et)) + 1;
                }
                catch
                {
                    N = 0;
                }

                for (int i = 1; i <= N; i++)
                {
                    f_min_i = (f_min/A)*Math.Pow(k_et, i - 1);
                    f_max_i = A*f_min*Math.Pow(k_et, i);
                    
                    var row = new ResultRow();

                    row.i = i.ToString();
                    row.f_max_i = Math.Round(f_max_i, 2).ToString("N");
                    row.f_min_i = Math.Round(f_min_i, 2).ToString("N");

                    dg_results.Items.Add(row);
                }

                
            }

            #endregion

            #region variant 2
            double m_df_et;

            //if (comboBox1.SelectedIndex == 1)
            //{
            //    m_df_et = (m_k_et - 1) * m_f_min;
            //    try
            //    {
            //        m_N = Convert.ToInt16((m_f_max - m_f_min) / m_df_et);
            //    }
            //    catch
            //    {

            //    }
            //    m_f_p = 0.04;
            //    for (int i = 1; i <= m_N; i++)
            //    {
            //        m_f_min_i = m_f_min + (i - 1) * m_df_et - m_f_p;
            //        m_f_max_i = m_f_min + i * m_df_et + m_f_p;
            //        m_datatable.Rows.Add(i.ToString(), Math.Round(m_f_min_i, 2).ToString(), Math.Round(m_f_max_i, 2).ToString());
            //    }
            //}

            if (cb_variant.SelectedIndex == 0)
            {
                m_df_et = (k_et - 1)*f_min;
            }

            #endregion

        }
    }

    public class ResultRow
    {
        public string i { get; set; }
        public string f_min_i { get; set; }
        public string f_max_i { get; set; }
    }
}
