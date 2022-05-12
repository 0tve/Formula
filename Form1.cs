namespace Lab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //Функция для подсчета факториала
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

        //Функция, которая срабатывает при нажатии на кнопку
        private void button1_Click(object sender, EventArgs e)
        {
            //Обнуляем значение label2
            label2.Text = "";

            //Объявляем переменные
            double S; //Конечное значение
            double sum_outer = 0; //Первая сумма (внешняя)
            double sum_inner = 0; //Вторая сумма (внутри первой суммы)
            double precision;
            int round_length; //Количество знаков после запятой

            //Проверяем правильность ввода
            bool check_textbox = int.TryParse(textBox1.Text, out round_length);

            if (check_textbox == false)
            {
                label2.Text = "Неверный ввод";
                return;
            }
            else if (round_length < 0)
            {
                label2.Text = "Неверный ввод";
                return;
            }

            //Создаем переменную, с помощью которой отбрасываются ненужные значения (меньше указанной точности)
            precision = 1 / Math.Pow(10, round_length);


            //Находим первую сумму
            for (int i = 1; i < 9; i++)
            { 
                double increment_inner; //Значение внутри второй суммы при заданном j
                int j = 1;
                //Находим вторую сумму
                do
                {
                    increment_inner = Math.Pow(Math.E, -i * j) / (Math.Pow(i, 3) + Factorial(Math.Pow(j, 2)));
                    sum_inner += increment_inner;
                    j++;
                }
                while (increment_inner > precision);

                sum_outer += Math.Pow(10, -i) * sum_inner;

            }

            //Проверка на допустимое количество знаков после запятой
            try
            {
                //Округление
                S = Math.Round((1.4 * sum_outer), round_length);
            }
            //Обрабатываем исключение, если оно возникло (неправильное количество знаков после запятой)
            catch
            {
                S = Math.Round((1.4 * sum_outer), 15); //Берем максимально допустимое значение
                label2.Text = "Принято значение 15";
            }

            //Выводим ответ на экран
            label1.Text = S.ToString();
        }

        //Функция, которая срабатывает при загрузке формы
        private void Form1_Load(object sender, EventArgs e)
        {
            //Устанавливаем значение количества знаков после запятой по умолчанию
            textBox1.Text = "4";
        }
    }
}