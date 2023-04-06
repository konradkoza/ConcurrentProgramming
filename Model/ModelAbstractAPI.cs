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

        public static ModelAbstractAPI CreateApi()
        {
            return new ModelAPI();
        }
    }

    public class ModelAPI : ModelAbstractAPI
    {
        private LogicAbstractAPI logicAPI;

        public ModelAPI()
        {
            logicAPI = LogicAbstractAPI.createAPI();
        }

        public override List<BallModel> BallModels { get; } = new List<BallModel>();

        public override void addModelBalls()
        {
          
            foreach (Ball ball in logicAPI.getBalls())
            {
                BallModels.Add(new BallModel(ball));
            }
       
        }

        public override void addBalls(int number)
        {
            for(int i = 0; i < number; i++)
            {
                logicAPI.addBall();
                
            }
        }


    }
}