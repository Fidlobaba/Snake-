using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeProject.Models
{
    class SnakeBody
    {
        private int x;
        private int y;
        private double speed;
        public SnakeBody(int x, int y) 
        {
            this.x = x;
            this.y = y;
        }

        public int Getx() 
        {
            return x;
        }

        public int Gety() 
        {
            return y;
        }

        public void Setx(int x) 
        {
            this.x = x;
        }

        public void Sety(int y) 
        {
            this.y = y;
        }

        
    }
}
