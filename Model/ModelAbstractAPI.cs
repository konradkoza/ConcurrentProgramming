using Data;
using Logika;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Model
{
    public abstract class ModelAbstractAPI
    {
        public abstract int width { get; }
        public abstract int height { get; }

        public abstract ObservableCollection<IBall> getBalls(); // zmienic !!!

        public abstract void AddBalls(int number);

        public abstract void Start();

        public abstract void Stop();

        public static ModelAbstractAPI CreateApi(int w, int h)
        {
            return new ModelAPI(w, h);
        }
    }

    internal class ModelAPI : ModelAbstractAPI, IDisposable
    {

        public override int width { get; }
        public override int height { get; }
        private LogicAbstractAPI logicAPI;


        public ModelAPI(int w, int h)
        {
            width = w;
            height = h;
            logicAPI = LogicAbstractAPI.CreateAPI(width, height);
        }




        public override void Start()
        {
          
        }



        public override void AddBalls(int number)
        {
            logicAPI.AddBalls(number);
        }

        public override void Stop()
        {
            
            logicAPI.RemoveAllBalls();
                       
        }

        public void Dispose()
        {
            
        }

        public override ObservableCollection<IBall> getBalls() => logicAPI.GetBalls();
    }
}