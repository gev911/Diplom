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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void btn_calculate_Click(object sender, RoutedEventArgs e)
        {
            double m_f_max, m_P, m_D_hay, m_Q_0, m_Q_mh, m_q, m_a, m_fi;
            double m_Q_rh, m_f1, m_f2;

            m_f_max = Convert.ToDouble(tb_fmax.Text);
            m_P = Convert.ToDouble(tb_P.Text);
            m_D_hay = Convert.ToDouble(tb_D_hay.Text);
            m_Q_0 = Convert.ToDouble(tb_Q_0.Text);
            m_Q_mh = Convert.ToDouble(tb_Q_mh.Text);
            m_q = Convert.ToDouble(tb_q.Text);
            m_a = Convert.ToDouble(tb_a.Text);
            m_fi = Convert.ToDouble(tb_fi.Text);
            
            //hahsvark
            m_Q_rh = (m_Q_0 / m_q);
            m_f1 = ((m_f_max * Math.Sqrt((1 + (m_a * m_a)) * m_D_hay)) / ((4 * m_Q_0)/m_q));
            m_f2 = (m_P * m_Q_mh * m_fi) / 100;

            //output
            m_Q_rh = Math.Round(m_Q_rh, 2);
            m_f1 = Math.Round(m_f1, 2);
            m_f2 = Math.Round(m_f2, 2);

            tb_Q_rh.Text = m_Q_rh.ToString();
            tb_f1.Text = m_f1.ToString();
            tb_f2.Text = m_f2.ToString();

            if (m_f1 >= m_f2)
            {
                lb_type.Content = "Ընտրել կրկնակի հաճախության փոխակերպումով սխեմա";
            }
            else
            {
                lb_type.Content = "Ընտրել մեկ հաճախության փոխակերպումով սխեմա";
            }

        }
    }
}
