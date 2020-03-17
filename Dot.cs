using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeProject.Models
{
    class Dot
    {
        (int, int) coordinate;
        (int, int) windowsize;
        int sizeBody;

        public Dot((int, int) windowsize, int sizeBody) 
        {
            this.windowsize = (windowsize.Item1 - sizeBody, windowsize.Item2 - sizeBody);
            this.sizeBody = sizeBody;

            NewCoordinateEat();
        }

        public void NewCoordinateEat() 
        {
            Random ranDom = new Random();

            int randomx = ranDom.Next(0, windowsize.Item1);
            randomx = randomx - (randomx % sizeBody);
            
            int randomy = ranDom.Next(0, windowsize.Item2);
            randomy = randomy - (randomy % sizeBody);
            coordinate = (randomx, randomy);
            
        }

        public (int, int) GetCoordinate() 
        {
            return coordinate;
        }



    }
}
