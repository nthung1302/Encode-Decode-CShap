using System;
using System.Windows;
using System.Windows.Controls;

namespace EnDeCode_RSA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int P, Q, E;

        public MainWindow()
        {
            InitializeComponent();

            mess("🔐 Ứng dụng minh họa Mã hóa RSA cho doanh nghiệp vừa và nhỏ");
            write("👉 RSA là một hệ mật mã khóa công khai.");
            write("👉 Ý tưởng chính: Dựa vào bài toán phân tích số nguyên lớn.");
            write("👉 Các bước thực hiện:");
            write("   1. Chọn 2 số nguyên tố P và Q.");
            write("   2. Tính N = P × Q.");
            write("   3. Tính φ(N) = (P - 1)(Q - 1).");
            write("   4. Chọn số E sao cho 1 < E < φ(N) và gcd(E, φ(N)) = 1.");
            write("   5. Tìm D là nghịch đảo modular của E theo φ(N).");
            write("   6. Khóa công khai: (E, N). Khóa bí mật: (D, N).");
            write("👉 Bạn hãy nhập P, Q, E và nhấn 'Create Key' để sinh khóa.");
            write(new string('-', 100));

        }


        private void CreateKey_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                P = Convert.ToInt32(TBoxP.Text.Trim());
                Q = Convert.ToInt32(TBoxQ.Text.Trim());
                E = Convert.ToInt32(TBoxE.Text.Trim());

                mess($"Ban vua nhap: P = ${P.ToString()}, Q = {Q.ToString()}, E = {E.ToString()}");

            } catch (FormatException)
            {
                mess("Vui lòng nhập đúng định dạng số nguyên cho P, Q, E.");
                return;
            }
            catch (OverflowException)
            {
                mess("Giá trị P, Q, E quá lớn. Vui lòng nhập số nhỏ hơn.");
                return;
            }

        }

        private void Encode_Click(object sender, RoutedEventArgs e)
        {
            mess("Encode");
        }

        private void Decode_Click(object sender, RoutedEventArgs e)
        {
            mess("Decode");
        }

        private void SignKey_Click(object sender, RoutedEventArgs e)
        {
            mess("Sign Key");
        }

        private void VeryfileKey_Click(object sender, RoutedEventArgs e)
        {
            mess("Verify Key");
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            clearData();
        }

        private void timkhoa(int P, int Q, int E)
        {
            
        }


        private void clearData()
        {
            TBoxE.Clear();
            TBoxP.Clear();
            TBoxQ.Clear();
            tbKetQua.Text = string.Empty;
            txtMessage.Text = string.Empty;
        }
        private bool IsPrime(int n)
        {
            if (n <= 1) return false;
            if (n <= 3) return true;
            if (n % 2 == 0 || n % 3 == 0) return false;

            for (int i = 5; i * i <= n; i += 6)
            {
                if (n % i == 0 || n % (i + 2) == 0)
                    return false;
            }
            return true;
        }

        private void write(string text)
        {
            tbKetQua.Text += text + Environment.NewLine;
        }

        private void mess(string text)
        {
            txtMessage.Text = text;
        }
    }
}
