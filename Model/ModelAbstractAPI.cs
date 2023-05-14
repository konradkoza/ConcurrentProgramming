using Data;
using Logika;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;

namespace Model
{
    public abstract class ModelAbstractAPI
    {
        public abstract int width { get; }
        public abstract int height { get; }

        public abstract ObservableCollection<IBall> getBalls(); // zmienic !!!

        public abstract void AddBalls(int number);

        public abstract void Stop();
        public ObservableCollection<BallModel> Balls { get; set; }
        public static ModelAbstractAPI CreateApi(int w, int h)
        {
            return new ModelAPI(w, h);
        }
    }

    internal class ModelAPI : ModelAbstractAPI
    {

        public override int width { get; }
        public override int height { get; }
        private LogicAbstractAPI logicAPI;


        public ModelAPI(int w, int h)
        {
            width = w;
            height = h;
            logicAPI = LogicAbstractAPI.CreateAPI(width, height);       
            Balls = new ObservableCollection<BallModel>();
            logicAPI.LogicLayerEvent += UpdateBall;
        }



        public override void AddBalls(int number)
        {
            logicAPI.AddBalls(number);
            for (int i = 0; i < number; i++)
            {
                BallModel ballModel = new BallModel(logicAPI.GetBall(i).X, logicAPI.GetBall(i).Y, logicAPI.GetBall(i).Diameter);
                Balls.Add(ballModel);
            }
        }

        public override void Stop()
        {
            
            logicAPI.RemoveAllBalls();
            Balls.Clear();
                       
        }

        private void UpdateBall(object? sender, BallChangedEventArgs args)
        {

            Debug.WriteLine("Ball" + args.Ball.Id + " updated");
            if(args.Ball.Id > Balls.Count)
            {
                return;
            }
            Balls[args.Ball.Id].Move(args.Ball.X, args.Ball.Y);
         
        }
       
        public override ObservableCollection<IBall> getBalls() => logicAPI.GetBalls();
    }
}