using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeProject.Models
{
    class Snake
    {
        public Direction direction = Direction.Right;
        public Direction oldDirection = Direction.Right;  
        
        private int size = 100;
        public List<SnakeBody> bodies = new List<SnakeBody>();
        private SnakeBody tailsnake;
        public int countbody;

        public Snake(Direction direction, (int, int) coordinate, int size, int countbody) 
        {
            this.direction = direction;
            this.oldDirection = direction;
            this.size = size;
            this.countbody = countbody;
            InitBody(countbody, coordinate);
        }

        private void InitBody(int countbody, (int, int) coordinate) 
        {
            int x = coordinate.Item1;
            int y = coordinate.Item2;

            for (int i = 0; i < countbody; i++)
            {
                SnakeBody sn = new SnakeBody(x, y);
                bodies.Add(sn);
                x -= size;
            }
        }

        public void ChangeCoordinate() 
        {
            SnakeBody sn = bodies.First();
            int x = sn.Getx();
            int y = sn.Gety();
            switch (direction) 
            {
                case Direction.Down:
                    if (oldDirection == Direction.Up)
                    {
                        direction = oldDirection;
                        y -= size;
                        break;
                    }
                    else
                    {
                        oldDirection = direction;
                        y += size;
                        break;
                    }
                case Direction.Left:
                    if (oldDirection == Direction.Right) 
                    {
                        direction = oldDirection;
                        x += size;
                        break;
                    }
                    else 
                    {
                        x -= size;
                        oldDirection = direction;
                        break;
                    }
                    
                case Direction.Right:
                    if (oldDirection == Direction.Left) 
                    {
                        x -= size;
                        direction = oldDirection;
                        break;
                    } 
                    else 
                    {
                        oldDirection = direction;
                        x += size;
                        break;
                    }
                case Direction.Up:
                    if (oldDirection == Direction.Down)
                    {
                        direction = oldDirection;
                        y += size;
                        break;
                    }
                    else 
                    {
                        oldDirection = direction;
                        y -= size;
                        break;
                    }
            }

            SnakeBody tail = new SnakeBody(x,y);
            tailsnake = bodies.Last();
            bodies.Remove(bodies.Last());
            bodies.Insert(0, tail);
        }

        public int GetSize() 
        {
            return size;
        }

        public int GetCountBody() 
        {
            return bodies.Count;
        }

        public bool Eating(Dot dot) 
        {
            SnakeBody head = bodies[0];
            if (dot.GetCoordinate().Item1 == head.Getx() && dot.GetCoordinate().Item2 == head.Gety())
            {
                bodies.Add(tailsnake);
                dot.NewCoordinateEat();
                return true;
                
            }
            else 
            {
                return false;
            }

            
        }
        
    }

    enum Direction 
    {
        Left,
        Right,
        Up,
        Down
    }
}
