using System.Collections;
using System.Collections.ObjectModel;
using Logic;
namespace Model
{
    public abstract class Pmodel
    {
        private readonly AbstractLogicAPI logicAPI;
        private ObservableCollection<ModelAdapter> observableBallCollection = new ObservableCollection<ModelAdapter>();

        public Pmodel(AbstractLogicAPI logicAPI)
        {
            this.logicAPI = logicAPI ?? AbstractLogicAPI.createLogicAPI();
        }

        public ObservableCollection<ModelAdapter> ObservableBallCollection
        {
            get => observableBallCollection;
            set => observableBallCollection = value;
        }

        public AbstractLogicAPI LogicAPI { get; set; }

        public abstract void start();
        public abstract void stop();
        public abstract void createBalls(int numberOfBalls);
        public abstract void addBall();

        public static Pmodel createPmodelAPI()
        {
            return new ModelAPI();
        }
    }
    public class ModelAPI : Pmodel
    {
        public ModelAPI(AbstractLogicAPI logicAPI = null) : base(logicAPI) { }

        public override void start()
        {
            LogicAPI.start();
            foreach (Board b in LogicAPI.GetBalls())
            {
                ObservableBallCollection.Add(new ModelAdapter(b));
            }
        }

        public override void createBalls(int numberOfBalls)
        {
            LogicAPI.createBalls(numberOfBalls);
        }

        public override void stop()
        {
            LogicAPI.stop();
        }

        public override void addBall()
        {
            LogicAPI.createBall();
            ObservableBallCollection.Add(new ModelAdapter(LogicAPI.GetBalls()[LogicAPI.GetBalls().Count - 1]));
        }
    }
}