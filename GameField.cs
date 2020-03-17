using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeProject.Models
{
    class GameField
    {
        private Dot eat;
        public GameField((int, int) windowsize, int sizebody) 
        {
            eat = new Dot(windowsize: windowsize, sizeBody: sizebody);
        }

        public Dot GetDot() 
        {
            return this.eat;
        }

        
    }
}
