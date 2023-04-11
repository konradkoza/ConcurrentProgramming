using Logika;
using System.Collections.Generic;
using System.ComponentModel;

namespace Model
{
    public abstract class ModelAbstractAPI
    {
        public abstract List<BallModel> BallModels { get; }

        public abstract void addModelBalls();

        public abstract void addBalls(int number);

        public abstract void Start();

        public static ModelAbstractAPI CreateApi()
        {
            return new ModelAPI();
        }
    }

    internal class ModelAPI : ModelAbstractAPI, IDisposable
    {
        private LogicAbstractAPI logicAPI;

        private Timer timer;

        public ModelAPI()
        {
            
            logicAPI = LogicAbstractAPI.createAPI();
        }

        public override List<BallModel> BallModels { get; } = new List<BallModel>();

        public override void addModelBalls()
        {
          
            foreach (var ball in logicAPI.getBalls())
            {
                BallModels.Add(new BallModel(ball.X, ball.Y, ball.Diameter));
            }
       
        }

        public override void Start()
        {
          timer = new Timer(move, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(10));
        }

        private void move(object? state)
        {
            logicAPI.MoveBalls();
            for(int i = 0; i < BallModels.Count; i++)
            {
                BallModels[i].X = logicAPI.getBalls()[i].X;
                BallModels[i].Y = logicAPI.getBalls()[i].Y;
            }
        }

        public override void addBalls(int number)
        {
            for(int i = 0; i < number; i++)
            {
                logicAPI.addBall();
                
            }
        }

        public void Dispose()
        {
            timer.Dispose();
        }

    }
}