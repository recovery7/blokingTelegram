using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace blokingTelegram
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true); //Фикс мерцания на экране
            UpdateStyles();
        }

        public Bitmap HanderTexture = Resource1.Handler, TargetTexture = Resource1.Target;
        private Point _targetPosition = Point.Empty;
        private Point _direction = Point.Empty;
        public int _score = 0;                 //Счетчик очков
        private int i = 40;
        Form3 fm = new Form3();


        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Random rand = new Random();
            timer2.Interval = rand.Next(25, 1000);
            _direction.X = rand.Next(-1, 2);
            _direction.Y = rand.Next(-1, 2);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics; //Работа с графикой

            var localPosition = this.PointToClient(Cursor.Position); //Передаем позицию курсора

            _targetPosition.X += _direction.X * 3; //Скорость
            _targetPosition.Y += _direction.Y * 3;

            if (_targetPosition.X < 0 || _targetPosition.X > 1250) { //Границы
                _direction.X *= -1;
            }
            if (_targetPosition.Y < 0 || _targetPosition.Y > 600) {
                _direction.Y *= -1;
            }

            Point between = new Point(localPosition.X - _targetPosition.X, localPosition.Y - _targetPosition.Y); 
            float distance = (float)Math.Sqrt((between.X * between.X) + (between.Y * between.Y));  //Находим расстояние по теореме Пифагора

            if (distance < 15) { //Условие добавления очков (расстояние до цели)
                AddScore(1);
            }

            var handleRect = new Rectangle(localPosition.X - 45, localPosition.Y - 45, 90, 90); //Размеры телеграма
            var targetRect = new Rectangle(_targetPosition.X - 30, _targetPosition.Y - 30, 60, 60); //Размеры кружка

            g.DrawImage(TargetTexture, targetRect); //Отрисовка текстуры телеграма
            g.DrawImage(HanderTexture, handleRect); //Отрисовка текстуры круга
        }
        private void button1_Click(object sender, EventArgs e) //Возврат в меню
        {
            Cursor.Show();
            Form2 mainForm = new Form2();
            mainForm.Show();
            Close();
        }

        public void timer3_Tick(object sender, EventArgs e)
        {
            i--;
            label2.Text = i.ToString();
            if (i == 0)
            {
                i--;
                Cursor.Show();
                Form2 mainForm = new Form2();
                mainForm.Show();
                Close();
                fm.label1.Text = _score.ToString();
                fm.randLabel();
                fm.Show();
            }
        }

        private void AddScore(int score) //Перенос счетчика на Label
        {
            _score += score;
            scoreLabel.Text = _score.ToString();
        }
    }
}