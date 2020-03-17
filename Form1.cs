using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SnakeProject.Models;


namespace SnakeProject
{
    public partial class Form1 : Form
    {
        
        private Timer timer = new Timer();
        private Snake snake;
        private Dot dot;
        private GameField gameField;
        

        public Form1()
        {
            InitializeComponent();
            snake = new Snake(Direction.Right, (100, 100), 20, 2);
            gameField = new GameField((this.Width, this.Height), snake.GetSize());
            timer.Interval = 80;
            timer.Tick += new EventHandler(TimerTick);
            timer.Start();
            
            
           
            
        }

        public void TimerTick(object obj, EventArgs e) 
        {
            this.snake.ChangeCoordinate();
            this.snake.Eating(gameField.GetDot());
            this.ClearForm();
            DrawDot();
            for (int i = 0; i < snake.GetCountBody(); i++)
            {
                if (i != 0) 
                {
                    if (snake.bodies.First().Getx() == snake.bodies[i].Getx() &&
                        snake.bodies.First().Gety() == snake.bodies[i].Gety()) 
                    {
                        timer.Stop();
                        MessageBox.Show("Конец Игры");
                        this.Close();
                        break;
                    }
                }
                this.DrawRect(snake.bodies[i].Getx(), snake.bodies[i].Gety());
            }
        }

        private void DrawRect(int x, int y)
        {
            Graphics graphics = base.CreateGraphics();
            Pen pen = new Pen(Color.Red);
            Rectangle rectangle = new Rectangle(x, y, snake.GetSize(), snake.GetSize()); 
            graphics.DrawRectangle(pen, rectangle);
            
        }

        private void DrawDot() 
        {
            Graphics graphics = base.CreateGraphics();
            Pen pen = new Pen(Color.Green);
            Rectangle rec = new Rectangle(gameField.GetDot().GetCoordinate().Item1, gameField.GetDot().GetCoordinate().Item2, 20, 20);
            graphics.DrawRectangle(pen, rec);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ClearForm()
        {
            Graphics graphics = base.CreateGraphics();
            graphics.Clear(this.BackColor);
        }

       private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
 


           
            switch (e.KeyValue)
            {
                case 37:
                    snake.direction = Direction.Left;
                    break;
                case 40:
                    snake.direction = Direction.Down;
                    break;
                case 39:
                    snake.direction = Direction.Right;
                    break;
                case 38:
                    snake.direction = Direction.Up;
                    break;

            }
            
        }

       
    }
}
