namespace Lab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //������� ��� �������� ����������
        double Factorial(double value)
        {
            double result = value;
            while (value > 1)
            {
                value -= 1;
                result *= value;
            }
            return result;
        }

        //�������, ������� ����������� ��� ������� �� ������
        private void button1_Click(object sender, EventArgs e)
        {
            //�������� �������� label2
            label2.Text = "";

            //��������� ����������
            double S; //�������� ��������
            double sum_outer = 0; //������ ����� (�������)
            double sum_inner = 0; //������ ����� (������ ������ �����)
            double precision;
            int round_length; //���������� ������ ����� �������

            //��������� ������������ �����
            bool check_textbox = int.TryParse(textBox1.Text, out round_length);

            if (check_textbox == false)
            {
                label2.Text = "�������� ����";
                return;
            }
            else if (round_length < 0)
            {
                label2.Text = "�������� ����";
                return;
            }

            //������� ����������, � ������� ������� ������������� �������� �������� (������ ��������� ��������)
            precision = 1 / Math.Pow(10, round_length);


            //������� ������ �����
            for (int i = 1; i < 9; i++)
            { 
                double increment_inner; //�������� ������ ������ ����� ��� �������� j
                int j = 1;
                //������� ������ �����
                do
                {
                    increment_inner = Math.Pow(Math.E, -i * j) / (Math.Pow(i, 3) + Factorial(Math.Pow(j, 2)));
                    sum_inner += increment_inner;
                    j++;
                }
                while (increment_inner > precision);

                sum_outer += Math.Pow(10, -i) * sum_inner;

            }

            //�������� �� ���������� ���������� ������ ����� �������
            try
            {
                //����������
                S = Math.Round((1.4 * sum_outer), round_length);
            }
            //������������ ����������, ���� ��� �������� (������������ ���������� ������ ����� �������)
            catch
            {
                S = Math.Round((1.4 * sum_outer), 15); //����� ����������� ���������� ��������
                label2.Text = "������� �������� 15";
            }

            //������� ����� �� �����
            label1.Text = S.ToString();
        }

        //�������, ������� ����������� ��� �������� �����
        private void Form1_Load(object sender, EventArgs e)
        {
            //������������� �������� ���������� ������ ����� ������� �� ���������
            textBox1.Text = "4";
        }
    }
}